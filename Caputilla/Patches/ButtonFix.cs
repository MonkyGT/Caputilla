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
            if (!FusionHub.selectedQueue.ToLower().Contains("modded"))
            {
                _queueSelect.button.material = _queueSelect.defaultMat;
            }
            else
            {
                _queueSelect.button.material = _queueSelect.redMat;
            }
        }
    }
}