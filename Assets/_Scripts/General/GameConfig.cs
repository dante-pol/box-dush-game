using System;

namespace Root.Assets._Scripts.General
{
    [Serializable]
    public class GameConfig
    {
        public int CountScore => _countScore;

        private int _countScore;

        public void SetNewScore(int score)
            => _countScore = score;
    }
}
