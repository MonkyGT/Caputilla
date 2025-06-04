using Caputilla.Utils;
using Fusion;
using HarmonyLib;

namespace CapuchinTemplate.Patches
{
    [HarmonyPatch(typeof(FusionHub), "JoinedRoom")]
    public class FusionHubPatchesJoin
    {
        public static void Postfix(FusionHub __instance)
        {
            RoomUtils.instance.OnJoin();
        }
    }
    
    [HarmonyPatch(typeof(FusionHub), "Leave")]
    public class FusionHubPatchesLeave
    {
        public static void Postfix(FusionHub __instance)
        {
            RoomUtils.instance.OnLeave();
        }
    }
}