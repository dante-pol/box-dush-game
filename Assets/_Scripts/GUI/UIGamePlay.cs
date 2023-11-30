using UnityEngine.UI;
using UnityEngine;
using Root.Assets._Scripts.General;
using Root.Assets._Scripts.Gameplay;
using Root.Assets._Scripts.GUI.Buttons;

namespace Root.Assets._Scripts.GUI
{
    public class UIGamePlay : MonoBehaviour
    {
        [SerializeField] private UIBaseButton _btnPlay;
        [SerializeField] private Text _txtLastScore;
        [SerializeField] private Text _txtCurrentScore;

        private LevelData _levelData;

        public void Init(Game game, GameConfig gameConfig, LevelData levelData)
        {
            _levelData= levelData;

            _txtLastScore.text = gameConfig.CountScore.ToString();
            _txtCurrentScore.text = "0";

            _levelData.AddListenerToIncreaseScore(() =>
            {
                _txtCurrentScore.text = _levelData.Score.ToString();
            });

            _btnPlay.AddListenerOnClick(game.Run);
            _btnPlay.AddListenerOnClick(() => { _btnPlay.gameObject.SetActive(false); });
        }
    }
}