using Fusion;
using UnityEngine;
using Il2CppSystem;
using Il2CppInterop.Runtime;
using System.Collections.Generic;
using Action = System.Action;
using IntPtr = System.IntPtr;

namespace Caputilla.Utils
{
    public class RoomUtils : MonoBehaviour
    {
        public static RoomUtils instance;
        private NetworkRunner runner;
        public event Action OnModdedJoin, OnModdedLeave;
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
                OnModdedJoin?.Invoke();
            }
        }

        internal void OnLeaveModded()
        {
            OnModdedLeave?.Invoke();
        }
    }
}
