using UnityEngine;

namespace Root.Assets._Scripts.Actors
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speedMove;
        [SerializeField] private float _ratioAcceleration;

        private Rigidbody2D _rigidbody2d;
        private Transform[] _path;

        private int _indexCurrentPoint;
        private float _currentRatioAcceleration;
        
        private bool _isActive;

        public void Init(Transform[] path, int indexStartPoint = 0)
        {
            _rigidbody2d = GetComponent<Rigidbody2D>();

            _path = path;
            transform.position = path[indexStartPoint].position;

            _indexCurrentPoint = indexStartPoint;

            _currentRatioAcceleration = 0;

            _isActive = false;
        }

        private void FixedUpdate()
        {
            if (!_isActive) return;

            if (IsDistance())
                ChangePoint();

            CalculateAcceleration();
            Movement();
        }
        private void Movement()
            => _rigidbody2d.velocity = GetDirection() * _speedMove * _currentRatioAcceleration;

        private bool IsDistance()
            => Vector2.Distance(transform.position, _path[_indexCurrentPoint].position) < 0.1f ? true : false; 

        private void ChangePoint()
        {
            if (_indexCurrentPoint == _path.Length - 1)
                _indexCurrentPoint = _path.Length - 2;
            else if (_indexCurrentPoint == 0)
                _indexCurrentPoint++;
            else
                _indexCurrentPoint = Random.Range(0, 10) > 5 ? 0 : _path.Length - 1;

            _rigidbody2d.velocity = Vector2.zero;
            _currentRatioAcceleration = 0;
        }

        private void CalculateAcceleration()
            => _currentRatioAcceleration = Mathf.Lerp(_currentRatioAcceleration, _ratioAcceleration, (1 * Time.fixedDeltaTime));
        
        private Vector2 GetDirection()
            => (_path[_indexCurrentPoint].position - transform.position).normalized;


        public void SetActive(bool value)
        {
            _isActive = value;
        }


    }
}
