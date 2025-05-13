using System;
using Caputilla.Utils;
using HarmonyLib;

namespace Caputilla.Patches
{
    [HarmonyPatch(typeof(QueueManager), "UpdateQueue")]
    public class QueueManagerQueuePatch
    {
        public static void Postfix(QueueManager __instance, string queue, QueueSelect selectedQueue)
        {
            RoomUtils.instance.currentQueue = queue;
        }
    }
    [HarmonyPatch(typeof(QueueManager), "Start")]
    public class QueueManagerStartPatch
    {
        public static void Postfix(QueueManager __instance)
        {
            __instance.button.AddItem(CaputillaManager.Instance.button2.GetComponent<QueueSelect>());
        }
    }
}