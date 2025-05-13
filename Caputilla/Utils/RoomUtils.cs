using Fusion;
using UnityEngine;
using Il2CppSystem;
using Il2CppInterop.Runtime;
using System.Collections.Generic;

namespace Caputilla.Utils
{
    public class RoomUtils : MonoBehaviour
    {
        public static RoomUtils instance;
        public string currentQueue;
        private NetworkRunner runner;
        public bool isInModded;

        private void Awake()
        {
            instance = this;
            runner = GameObject.FindObjectOfType<NetworkRunner>();
        }

        private void Update()
        {
            if (!isInModded && runner.IsInSession)
            {
                if (currentQueue.ToLower().Contains("modded"))
                {
                    isInModded = true;
                }
            }

            if (isInModded && !runner.IsInSession)
            {
                isInModded = false;
            }
        }
    }
}
