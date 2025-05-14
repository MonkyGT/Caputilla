using System;
using Caputilla.Utils;
using HarmonyLib;

namespace Caputilla.Patches
{
    [HarmonyPatch(typeof(QueueManager), "Start")]
    public class QueueManagerStartPatch
    {
        public static void Postfix(QueueManager __instance)
        {
            __instance.button.AddItem(CaputillaManager.Instance.button2.GetComponent<QueueSelect>());
        }
    }
}