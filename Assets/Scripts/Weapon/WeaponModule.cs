using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewModule", menuName = "Weapon/Modules/")]
public class WeaponModule : ScriptableObject
{
    public virtual void Activate(ModuleContext context = null)
    {
        
    }
}
public class ModuleContext
{
    public int damage = 0;

    private Dictionary<string, object> _data = new Dictionary<string, object>();

    public void Set<T>(string key, T value)
    {
        _data[key] = value;
    }

    public T Get<T>(string key)
    {
        if (_data.TryGetValue(key, out var value) && value is T tValue)
            return tValue;

        return default;
    }

    public bool TryGet<T>(string key, out T result)
    {
        if (_data.TryGetValue(key, out var value) && value is T tValue)
        {
            result = tValue;
            return true;
        }

        result = default;
        return false;
    }
}