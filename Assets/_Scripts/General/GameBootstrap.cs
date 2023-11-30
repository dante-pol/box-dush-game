using Root.Assets._Scripts.Tools;
using UnityEngine;

namespace Root.Assets._Scripts.General
{
    public class GameBootstrap : MonoBehaviour
    {
        public static GameBootstrap Instance { get; private set; }
        public GameConfig Config { get; private set; }

        private void Start()
        {
            if (IsGameConfig()) return;
            
            DontDestroyOnLoad(gameObject);

            LoadConfig();
            LoadGame();
        }

        private bool IsGameConfig()
            => Instance == null ? !(Instance = this) : false;

        private void LoadConfig()
            => Config = SaveLoader.Load();

        private void LoadGame()
            => SceneLoader.Load(IDScenes.GAME_SCENE);
    }
}
