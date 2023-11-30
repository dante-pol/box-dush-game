using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Inputs
{
    public class BaseInputSystem : IInputSystem
    {
        public virtual bool IsShoot
        {
            get => Input.GetKeyDown(KeyCode.Space);
        }
    }
}
