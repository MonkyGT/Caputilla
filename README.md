# Caputilla

##### This mod adds Modded rooms and an easy to use InputManager to the game "Capuchin"


##### To use this in code do something like 
```C#
    public class Template : MonoBehaviour
    {
        void Start()
        {
            Caputilla.Utils.RoomUtils.instance.OnModdedJoin += OnJoinedModded;
            Caputilla.Utils.RoomUtils.instance.OnModdedLeave += OnLeaveModded;
        }

        void OnJoinedModded()
        {
            //Activate Mod Here
        }

        void OnLeaveModded()
        {
            //Deactivate Mod Here
        }
    }
```
and put make sure in the `Load()` part of the plugin class add `AddCompenent<Template>();`
