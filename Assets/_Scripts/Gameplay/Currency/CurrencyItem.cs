using Root.Assets._Scripts.Gameplay.Styles;
using Root.Assets._Scripts.GUI;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Currency
{
    public class CurrencyItem : MonoBehaviour
    {
        private CurrencyGenerator _currencyGenerator;
        private GameBackgroundController _backgroundController;
        private LevelData _levelData;

        public void Init(
            CurrencyGenerator currencyGenerator, 
            GameBackgroundController backgroundController,
            LevelData levelData)
        {
            _levelData = levelData;
            _currencyGenerator = currencyGenerator;
            _backgroundController = backgroundController;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")) 
            {
                _currencyGenerator.CurrentCount--;
                
                _backgroundController.Increase();
                _levelData.IncreaseScore();
                
                gameObject.SetActive(false);
            }
        }
    }
}
