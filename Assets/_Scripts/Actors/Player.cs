using Root.Assets._Scripts.Actors;
using UnityEngine;
using Root.Assets._Scripts.Gameplay.Inputs;
using System;
using Root.Assets._Scripts.Gameplay;

namespace Root.Assets._Scripts.Tools
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        #region Config
        [Header("Configuration")]
        public float StartMaxAngleRotate;
        public float StartMinAngleRotate;

        public ParticleSystem _effectForDead;
        #endregion

        #region Movement
        public float SpeedRotate => _speedRotate;
        public float SpeedMove => _speedMove;

        [Header("Movement")]
        [SerializeField] private float _speedRotate;
        [SerializeField] private float _speedMove;
        #endregion

        #region PlayerComponents
        private PlayerMovement _playerMovement;
        #endregion

        private Game _game;

        private Action OnDead;
        private bool _isLive;

        public void Init(Game game, IInputSystem inputSystem)
        {
            _game = game;
            _isLive = true;
            _playerMovement = new PlayerMovement(this, GetComponent<Rigidbody2D>(), inputSystem);
        }

        private void Update()
        {
            if (!_game.IsGameActive) return;
            _playerMovement.Update();
        }

        private void FixedUpdate()
        {
            if (!_game.IsGameActive) return;
            _playerMovement.FixedUpdate();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Enemy") || !_isLive) return;

            _isLive = false;
            Dead();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_playerMovement.CanMove == false) return;

            _playerMovement.ResetMove();

            var border = collision.gameObject.GetComponent<StickyBorder>();
            if (!border) return;

            _playerMovement.ChangeAngles(border);
        }

        private void Dead()
        {
            _playerMovement.Disable();
            _effectForDead.Play();

            OnDead?.Invoke();
            RemoveAllListenerToDead();
        }

        public void AddListenerToDead(Action callBack)
            => OnDead += callBack;

        public void RemoveAllListenerToDead()
            => OnDead = null;

    }

}
