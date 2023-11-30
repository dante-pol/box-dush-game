using Root.Assets._Scripts.Gameplay;
using Root.Assets._Scripts.General;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Root.Assets._Scripts.GUI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class UIBaseButton : MonoBehaviour
    {
        private Button _btn;

        private void OnDisable()
            => RemoveAllListeners();

        public void AddListenerOnClick(UnityAction handler)
        {
            if (_btn == null) _btn = GetComponent<Button>();
            _btn.onClick.AddListener(handler); 
        }

        private void RemoveAllListeners()
            => _btn.onClick.RemoveAllListeners();
    }
}