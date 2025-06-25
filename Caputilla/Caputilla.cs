using System;
using Caputilla;
using Caputilla.Utils;
using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppLocomotion;
using Il2CppTMPro;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(Caputilla.Caputilla), ModInfo.Name, ModInfo.Version, ModInfo.Author)]

namespace Caputilla
{
    public class Caputilla : MelonMod
    {
        public static Caputilla Instance;

        public event Action OnGameInitialized, OnModdedJoin, OnModdedLeave, OnJoinedRoom, OnLeaveRoom;
        public bool initialized;
        public GameObject button2;
        // Stand-in for the normal BepInEx gameObject
        private GameObject gameObject;

        public override void OnInitializeMelon()
        {
            ClassInjector.RegisterTypeInIl2Cpp<RoomUtils>();
            ClassInjector.RegisterTypeInIl2Cpp<ControllerInputManager>();
            ClassInjector.RegisterTypeInIl2Cpp<ButtonFix>();
            Instance = this;
        }

        public override void OnUpdate()
        {
            if (!initialized && Player.Instance != null)
            {
                initialized = true;
                OnInit();
            }
        }

        private void OnInit()
        {
            gameObject = new GameObject("CaputillaManager");
            Console.WriteLine("Initializing Caputilla");
            this.gameObject.AddComponent<RoomUtils>();
            this.gameObject.AddComponent<ControllerInputManager>();
            OnGameInitialized?.Invoke();
            
            GameObject text = GameObject.Find("Global/Levels/ObjectNotInMaps/Stump/TableOffset/QueueBoard/Text (TMP)");
            text.GetComponent<TextMeshPro>().text = "|CASUAL\n\n|KING OF THE HILL\n\n|MODDED\n\n|???";

            GameObject button1 = GameObject.Find("Global/Levels/ObjectNotInMaps/Stump/TableOffset/QueueBoard/Casual");
            button2 = GameObject.Instantiate(button1);
            button2.transform.parent = button1.transform.parent;
            button2.name = "Modded";
            button2.transform.position = button1.transform.parent.Find("Cube (3)").position;
            button2.transform.localScale = button1.transform.localScale;
            button2.transform.localRotation = button1.transform.localRotation;
            button2.AddComponent<ButtonFix>();
            button1.transform.parent.Find("Cube (3)").gameObject.Kill();
            var queueselet1 = button1.GetComponent<QueueSelect>();
            var queueselet2 = button2.GetComponent<QueueSelect>();
            queueselet2.button = button2.GetComponent<MeshRenderer>();
            queueselet2.redMat = queueselet1.redMat;
            queueselet2.defaultMat = queueselet1.defaultMat;
            queueselet2.queue = "MODDED";
        }

        internal void InvokeModdedJoin()
        {
            OnModdedJoin?.Invoke();
        }
        internal void InvokeModdedLeave()
        {
            OnModdedLeave?.Invoke();
        }

        internal void InvokeNonModdedJoin()
        {
            OnJoinedRoom?.Invoke();
        }

        internal void InvokeNonModdedLeave()
        {
            OnLeaveRoom?.Invoke();
        }
    }
}