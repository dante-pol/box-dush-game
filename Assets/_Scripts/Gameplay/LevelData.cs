using System;

namespace Root.Assets._Scripts.Gameplay
{
    public class LevelData
    {
        public event Action OnIncreaseScore;

        public int Score => _score;

        private int _score;

        public void AddListenerToIncreaseScore(Action callBack)
        {
            OnIncreaseScore += callBack;
        }

        public void IncreaseScore(int value = 1)
        {
            _score += value;
            OnIncreaseScore?.Invoke();
        }
    }
}
