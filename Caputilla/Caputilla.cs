using System;
using BepInEx;
using BepInEx.Unity.IL2CPP;
using System.Threading.Tasks;
using BepInEx.Logging;
using Caputilla.Utils;
using HarmonyLib;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppSystem.Collections.Generic;
using Locomotion;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using IEnumerator = Il2CppSystem.Collections.IEnumerator;

namespace Caputilla
{
    [BepInPlugin(ModInfo.Guid, ModInfo.Name, ModInfo.Version)]
    public class Caputilla : BasePlugin
    {
        internal static new ManualLogSource Log;
        
        public override void Load()
        {
            Harmony.CreateAndPatchAll(GetType().Assembly, ModInfo.Guid);
            ClassInjector.RegisterTypeInIl2Cpp<RoomUtils>();
            ClassInjector.RegisterTypeInIl2Cpp<ButtonFix>();
            ClassInjector.RegisterTypeInIl2Cpp<ControllerInputManager>();
            AddComponent<CaputillaManager>();
        }
    }

    public class CaputillaManager : MonoBehaviour
    {
        public static CaputillaManager Instance;

        private readonly List<Il2CppSystem.Action> _onInitialized = new();
        private bool _init = false;
        public GameObject button2;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (!_init && Player.Instance != null)
            {
                _init = true;
                OnInit();
            }
        }

        private void OnInit()
        {
            this.gameObject.AddComponent(Il2CppType.Of<RoomUtils>());
            this.gameObject.AddComponent(Il2CppType.Of<ControllerInputManager>());
            
            GameObject text = GameObject.Find("Global/Levels/ObjectNotInMaps/Stump/TableOffset/QueueBoard/Text (TMP)");
            text.GetComponent<TextMeshPro>().text = "|CASUAL\n\n|KING OF THE HILL\n\n|MODDED\n\n|???";

            GameObject button1 = GameObject.Find("Global/Levels/ObjectNotInMaps/Stump/TableOffset/QueueBoard/Casual");
            button2 = Instantiate(button1);
            button2.transform.parent = button1.transform.parent;
            button2.name = "Modded";
            button2.transform.position = button1.transform.parent.Find("Cube (3)").position;
            button2.transform.localScale = button1.transform.localScale;
            button2.transform.localRotation = button1.transform.localRotation;
            button2.AddComponent<ButtonFix>();
            button1.transform.parent.Find("Cube (3)").gameObject.SetActive(false);
            var queueselet1 = button1.GetComponent<QueueSelect>();
            var queueselet2 = button2.GetComponent<QueueSelect>();
            queueselet2.button = button2.GetComponent<MeshRenderer>();
            queueselet2.redMat = queueselet1.redMat;
            queueselet2.defaultMat = queueselet1.defaultMat;
            queueselet2.queue = "MODDED";
        }
    }
}