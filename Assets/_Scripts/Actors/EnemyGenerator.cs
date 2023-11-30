using UnityEngine;

namespace Root.Assets._Scripts.Actors
{
    public class EnemyGenerator : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;

        [SerializeField] private Transform[] _path1;
        [SerializeField] private Transform[] _path2;

        private Enemy _enemy1;
        private Enemy _enemy2;

        public void Init()
        {
            _enemy1 = CreateEnemy();
            _enemy2 = CreateEnemy();
            
            _enemy1.Init(_path2, 0);
            _enemy2.Init(_path1, _path2.Length - 1);
        }

        public void Run()
        {
            _enemy1.SetActive(true);
            _enemy2.SetActive(true);
        }

        public void Stop()
        {
            _enemy1.SetActive(false);
            _enemy2.SetActive(false);
        }

        private Enemy CreateEnemy()
            => Instantiate(_prefab);
    }
}
