using Root.Assets._Scripts.Gameplay;
using Root.Assets._Scripts.General;
using Root.Assets._Scripts.GUI.Buttons;
using Root.Assets._Scripts.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Root.Assets._Scripts.GUI
{
    public class UIGameOver : MonoBehaviour
    {
        [SerializeField] private UIBaseButton _btnRestart;
        [SerializeField] private Text _txtCurrentScore;
        [SerializeField] private Text _txtLastScore;

        private LevelData _levelData;
        private GameConfig _gameConfig;
        
        public void Init(GameConfig gameConfig, LevelData levelData)
        {
            _levelData = levelData;
            _gameConfig = gameConfig;

            _btnRestart.AddListenerOnClick(() =>
            {
                SceneLoader.Load(IDScenes.GAME_SCENE);
            });
        }

        public void UpdateUI()
        {
            _txtLastScore.text = _gameConfig.CountScore.ToString();
            _txtCurrentScore.text = _levelData.Score.ToString();
        }
    }
}