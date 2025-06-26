using Il2Cpp;
using Il2CppFusion;
using Il2CppSystem;
using UnityEngine;


namespace Caputilla.Utils
{
    public class RoomUtils : MonoBehaviour
    {
        public static RoomUtils instance;
        private NetworkRunner runner;
        public bool isInModded { get; private set; }

        private void Awake() => instance = this;

        internal void OnJoin()
        {
            if (FusionHub.InRoom && FusionHub.currentQueue.ToLower().Contains("modded"))
            {
                isInModded = true;
                Caputilla.Instance.InvokeModdedJoin();
            }
            else
            {
                isInModded = false;
                Caputilla.Instance.InvokeNonModdedJoin();
            }
        }

        internal void OnLeave()
        {
            if (isInModded)
            {
                isInModded = false;
                Caputilla.Instance.InvokeModdedLeave();
            }
            else
            {
                isInModded = false;
                Caputilla.Instance.InvokeNonModdedLeave();
            }
        }
    }
}
