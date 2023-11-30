using Root.Assets._Scripts.Gameplay;
using Root.Assets._Scripts.General;
using Root.Assets._Scripts.Tools;
using UnityEngine;

namespace Root.Assets._Scripts.GUI
{
    public class GUIManager : MonoBehaviour
    {
        [SerializeField] private UIGamePlay _pnlGameplay;
        [SerializeField] private UIGameOver _pnlGameOver;

        public void Init(Game game, GameConfig gameConfig, LevelData levelData, Player player)
        {
            _pnlGameplay.Init(game, gameConfig, levelData);
            _pnlGameOver.Init(gameConfig, levelData);

            SetActiveGameplay(true);
            SetActiveGameOver(false);

            player.AddListenerToDead(() =>
            {
                SetActiveGameplay(false);
                SetActiveGameOver(true);

                _pnlGameOver.UpdateUI();
            });
        }

        public void SetActiveGameOver(bool value)
            => _pnlGameOver.gameObject.SetActive(value);

        public void SetActiveGameplay(bool value)
            => _pnlGameplay.gameObject.SetActive(value);
    }
}
