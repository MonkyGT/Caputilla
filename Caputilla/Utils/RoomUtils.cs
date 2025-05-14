using Fusion;
using UnityEngine;


namespace Caputilla.Utils
{
    public class RoomUtils : MonoBehaviour
    {
        public static RoomUtils instance;
        private NetworkRunner runner;
        public bool isInModded;

        private void Awake()
        {
            instance = this;
        }

        internal void OnJoinModded()
        {
            if (FusionHub.InRoom && FusionHub.currentQueue.ToLower().Contains("modded"))
            {
                isInModded = true;
                CaputillaManager.Instance.InvokeModdedJoin();
            }
        }

        internal void OnLeaveModded()
        {
            isInModded = false;
            CaputillaManager.Instance.InvokeModdedLeave();
        }
    }
}
