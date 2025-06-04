using Fusion;
using UnityEngine;

namespace Caputilla.Utils;

public static class CaputillaExtensions
{
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        var component = gameObject.GetComponent<T>();
        if (component == null)
        {
            component = gameObject.AddComponent<T>();
        }
        return component;
    }

    public static void Kill(this Object self)
    {
        if (self == null) return;
        
        Object.Destroy(self);
    }
    
    public static void Kill(this GameObject self)
    {
        if (self == null) return;
        
        GameObject.Destroy(self);
    }
}