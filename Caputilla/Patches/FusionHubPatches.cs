using Caputilla.Utils;
using Fusion;
using HarmonyLib;

namespace CapuchinTemplate.Patches
{
    [HarmonyPatch(typeof(FusionHub), "OnPlayerJoined")]
    public class JoinedRoomPatches
    {
        public static void Postfix(FusionHub __instance, NetworkRunner runner, PlayerRef player)
        {
            if (player == runner.LocalPlayer)
            {
                RoomUtils.instance.OnJoinModded();
            }
        }
    }

    [HarmonyPatch(typeof(FusionHub), "OnPlayerLeft")]
    public class LeftRoomPatches
    {
        public static void Postfix(FusionHub __instance, NetworkRunner runner, PlayerRef player)
        {
            if (player == runner.LocalPlayer)
            {
                RoomUtils.instance.OnLeaveModded();
            }
        }
    }
}