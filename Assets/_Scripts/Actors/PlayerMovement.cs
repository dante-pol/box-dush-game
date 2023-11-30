using Root.Assets._Scripts.Actors;
using Root.Assets._Scripts.Gameplay.Inputs;
using UnityEngine;

namespace Root.Assets._Scripts.Tools
{
    public class PlayerMovement
    {
        private readonly Player _player;
        private readonly Rigidbody2D _rigidbody;
        private readonly IInputSystem _inputSystem;

        public float MaxAngleRotate;
        public float MinAngleRotate;

        public bool CanMove;
        public bool CanRotate;
        public bool CanShoot;
        public bool IsRun;

        public float _dir;

        public PlayerMovement(Player playerModel, Rigidbody2D rigidbody, IInputSystem inputSystem)
        {
            _player = playerModel;
            _rigidbody = rigidbody;
            _inputSystem = inputSystem;

            MaxAngleRotate = playerModel.StartMaxAngleRotate;
            MinAngleRotate = playerModel.StartMinAngleRotate;

            CanRotate = true;
            CanShoot = true;
            CanMove = false;
            IsRun = true;

            _dir = 1;

            Shoot();
        }

        public void Update() 
        {
            if (_inputSystem.IsShoot && CanShoot)
                Shoot();
        }

        public void FixedUpdate() 
        {
            if (_rigidbody.rotation > MaxAngleRotate)
            {
                _rigidbody.rotation = MaxAngleRotate;
                _dir = -1;
            }
            else if (_rigidbody.rotation < MinAngleRotate)
            {
                _rigidbody.rotation = MinAngleRotate;
                _dir = 1;
            }

            if (CanRotate)
                Rotate();

            if (CanMove)
                Move();
        }

        public void ResetMove()
        {
            CanRotate = true;
            CanShoot = true;
            CanMove = false;

            _rigidbody.velocity = Vector2.zero;
        }

        public void ChangeAngles(StickyBorder border)
        {
            MaxAngleRotate = border.MaxAngle;
            MinAngleRotate = border.MinAngle;
            _rigidbody.rotation = border.CurrentAngle;
        }

        public void Disable()
        {
            CanMove = false;
            CanRotate = false;
            CanShoot = false;
        }

        private void Shoot()
        {
            CanRotate = false;
            CanShoot = false;
            CanMove = true;
        }

        private Vector2 GetDirection()
            => _player.transform.up;

        private void Move()
            => _rigidbody.velocity = GetDirection() * _player.SpeedMove;

        private void Rotate()
            => _rigidbody.rotation += (_dir * _player.SpeedRotate);
    }

}
