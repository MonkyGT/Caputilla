using UnityEngine;

namespace Caputilla.Utils
{
    public class ButtonFix : MonoBehaviour
    {
        private QueueSelect _queueSelect;

        void Start()
        {
            _queueSelect = gameObject.GetComponent<QueueSelect>();
        }
        void Update()
        {
            if (!RoomUtils.instance.currentQueue.ToLower().Contains("modded"))
            {
                _queueSelect.button.material = _queueSelect.defaultMat;
            }
        }
    }
}