using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Buffs that don't have duration like item stats
/// 
/// </summary>

[System.Serializable]
public class StaticBuff
{
    public string statName;
    public Modifier modifier;

    public StaticBuff(string statName, Modifier modifier)
    {
        this.statName = statName;
        this.modifier = modifier;
    }

    public StaticBuff(string statName, Modifier.Type type, float value)
    {
        this.statName = statName;
        modifier = new Modifier(type, value);
    }

    public void SetBuffValue(float value)
    {
        modifier.value = value;
    }
}
