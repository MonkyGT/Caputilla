# Caputilla

##### This mod adds Modded rooms and an easy to use InputManager to the game "Capuchin"


##### To use this in code do something like 
```C#
bool WasInModded;

void Update()
        {
            if (Player.Instance != null && Caputilla.Utils.RoomUtils.instance != null)
            {
                if (Caputilla.Utils.RoomUtils.instance.isInModded && !wasInModded)
                {
                    // ACTIVATE MOD HERE

                    wasInModded = true;
                }

                if (!Caputilla.Utils.RoomUtils.instance.isInModded && wasInModded)
                {
                    // DEACTIVATE MOD HERE

                    wasInModded = false;
                }
            }
        }
```
and put it in a class that *ISNT* your plugin class.
