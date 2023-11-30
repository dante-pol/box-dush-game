using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Styles
{
    public class GameBackgroundController
    {
        private Color32[] _backgrounds = {
            new Color32(173, 216, 230, 255),
            new Color32(144, 238, 144, 255),
            new Color32(255, 182, 193, 255),
            new Color32(221, 160, 221, 255)
        };

        private Camera _camera;

        private int _nextCount;
        private int _count;
        private int _index;

        public void Init()
        {
            _camera = Camera.main;
            _count = 0;
            _nextCount = 0;
        }

        public void Change()
        {
            _index = Random.Range(0, _backgrounds.Length);
            _camera.backgroundColor = _backgrounds[_index];

            UpdateCurrentCount();
        }

        public void Increase()
        {
            _count++;
            
            if (_count != _nextCount) return;

            _count = 0;
            Change();
        }

        private void UpdateCurrentCount()
            => _nextCount = Random.Range(1, 5);
    }
}
