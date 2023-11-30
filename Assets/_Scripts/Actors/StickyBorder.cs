using UnityEngine;

namespace Root.Assets._Scripts.Actors
{
    public class StickyBorder : MonoBehaviour
    {
        public float CurrentAngle => _currentAngle;
        public float MaxAngle => _maxAngle;
        public float MinAngle => _minAngle;

        [SerializeField][Range(-360, 360)] private float _maxAngle;
        [SerializeField][Range(-360, 360)] private float _minAngle;
        [SerializeField][Range(-360, 360)] private float _currentAngle;
    }
}
