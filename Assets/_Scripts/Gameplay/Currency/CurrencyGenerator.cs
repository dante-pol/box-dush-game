using Root.Assets._Scripts.Gameplay.Styles;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Currency
{
    public class CurrencyGenerator : MonoBehaviour
    {
        [Header("Currency")]
        [SerializeField] private CurrencyItem _prefabCurrency;

        [Header("Zone generation")]
        [SerializeField] private float _pointLeft;
        [SerializeField] private float _pointRight;
        [SerializeField] private float _pointTop;
        [SerializeField] private float _pointBottom;

        [Header("Generation")]
        [SerializeField] private float _maxCountGeneration;
        [SerializeField] private float _maxTimeWait;
        [SerializeField] private float _minTimeWait;

        public bool IsGenerate { get; set; }
        public int CurrentCount { get; set; }
        
        private GameBackgroundController _backgroundController;
        private LevelData _levelData;

        public void Init(GameBackgroundController backgroundController, LevelData levelData)
        {
            _backgroundController = backgroundController;
            _levelData = levelData;

            IsGenerate = true;
        }

        public void Run()
            => StartCoroutine(Generating());

        public IEnumerator Generating()
        {
            while(IsGenerate)
            {
                if (CurrentCount < _maxCountGeneration)
                {
                    var currencyItem = CreateCurrency();
                    ConfigCurrency(currencyItem);
                    CurrentCount++;
                }

                yield return new WaitForSeconds(_minTimeWait);
            }
        }

        private void ConfigCurrency(CurrencyItem currency)
        {
            currency.Init(this, _backgroundController, _levelData);

            currency.transform.position = GetPosition();
            currency.transform.parent = transform;
        }

        private Vector2 GetPosition()
        {
            float coorX = Random.Range(_pointLeft, _pointRight);
            float coorY = Random.Range(_pointBottom, _pointTop);

            return new Vector2(coorX, coorY);
        }

        private CurrencyItem CreateCurrency()
            => Instantiate(_prefabCurrency);
    }
}
