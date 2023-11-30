using UnityEngine;
using Root.Assets._Scripts.General;

namespace Root.Assets._Scripts.Tools
{
    public static class SaveLoader
    {
        private const string KEY_SAVE = "box_rash_data";

        public static void Save(GameConfig gameConfig)
        {

            string config = JsonUtility.ToJson(gameConfig);

            PlayerPrefs.SetString(KEY_SAVE, config);
            PlayerPrefs.Save();
        }

        public static GameConfig Load() 
        {
            if (!PlayerPrefs.HasKey(KEY_SAVE))
            {
                Debug.Log("!HasKey");
                return new GameConfig();
            }

            Debug.Log("HasKey");

            GameConfig config = JsonUtility.FromJson<GameConfig>(PlayerPrefs.GetString(KEY_SAVE));

            return config;
        }
    }
}
