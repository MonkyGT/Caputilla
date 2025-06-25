using Caputilla.Utils;
using HarmonyLib;
using Il2Cpp;
using Il2CppFusion;

namespace CapuchinTemplate.Patches
{
    [HarmonyPatch(typeof(FusionHub), "OnPlayerJoined")]
    public class FusionHubPatchesJoin
    {
        public static void Postfix(FusionHub __instance, PlayerRef player)
        {
            if (FusionHub.Runner.LocalPlayer == player)
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