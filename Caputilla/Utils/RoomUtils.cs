using System;
using System.Net.Http;
using System.Text;
using Fusion;
using Il2CppInterop.Runtime;
using UnityEngine;


namespace Caputilla.Utils
{
    public class RoomUtils : MonoBehaviour
    {
        public static RoomUtils instance;
        private NetworkRunner runner;
        public bool isInModded { get; private set; }

        private void Awake()
        {
            instance = this;
        }

        internal void OnJoin()
        {
            if (FusionHub.InRoom && FusionHub.currentQueue.ToLower().Contains("modded"))
            {
                isInModded = true;
                CaputillaManager.Instance.InvokeModdedJoin();
            }
            else
            {
                CaputillaManager.Instance.InvokeNonModdedJoin();
            }
        }

        internal void OnLeave()
        {
            if (isInModded)
            {
                isInModded = false;
                CaputillaManager.Instance.InvokeModdedLeave();
            }
            else
            {
                CaputillaManager.Instance.InvokeNonModdedLeave();
            }
        }
    }
}
