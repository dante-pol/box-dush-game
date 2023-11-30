using Root.Assets._Scripts.Actors;
using Root.Assets._Scripts.Gameplay.Currency;
using Root.Assets._Scripts.Gameplay.Inputs;
using Root.Assets._Scripts.Gameplay.Styles;
using Root.Assets._Scripts.General;
using Root.Assets._Scripts.GUI;
using Root.Assets._Scripts.Tools;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay
{
    public class Game: MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private CurrencyGenerator _currencyGenerator;
        [SerializeField] private EnemyGenerator _enemyGenerator;
        [SerializeField] private GUIManager _guiManager;

        private GameBootstrap _gameBootstrap;
        private IInputSystem _inputSystem;
        private GameBackgroundController _backgroundController;
        private LevelData _levelData;
        
        public bool IsGameActive { get; private set; }

        private void Awake()
        {
            if (NeedGameBootstrap()) 
            {
                SceneLoader.Load(IDScenes.INIT_SCENE);
                return;
            }

            InitComponentsGameSystem();
        }

        private bool NeedGameBootstrap()
            => (_gameBootstrap = GameBootstrap.Instance) == null ? true : false;

        private void InitComponentsGameSystem()
        {
            _levelData = new LevelData();
            _inputSystem = new BaseInputSystem();
            _backgroundController = new GameBackgroundController();

            _guiManager.Init(this, _gameBootstrap.Config, _levelData, _player);
            _player.Init(this, _inputSystem);
            _backgroundController.Init();
            _currencyGenerator.Init(_backgroundController, _levelData);
            _enemyGenerator.Init();

            IsGameActive = false;

            _backgroundController.Change();
            AddListenersForEvents();
        }

        private void AddListenersForEvents()
            => _player.AddListenerToDead(Save);

        public void Run()
        {
            IsGameActive = true;

            _currencyGenerator.Run();
            _enemyGenerator.Run();
        }

        private void Save()
        {
            UpdateConfig();
            SaveLoader.Save(_gameBootstrap.Config);
        }

        private void UpdateConfig()
        {
            Debug.Log("LEVELDATA:SCORE:" + _levelData.Score);
            Debug.Log("GAMECONFIG:SCORE:" + _gameBootstrap.Config.CountScore);
            if (_levelData.Score > _gameBootstrap.Config.CountScore)
                _gameBootstrap.Config.SetNewScore(_levelData.Score);
        }
    }
}
