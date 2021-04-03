using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBuff
{
    public string statName;
    public float duration;
    public Modifier modifier;

    public DynamicBuff(string statName, float duration, Modifier modifier)
    {
        this.statName = statName;
        this.duration = duration;
        this.modifier = modifier;
    }

    public DynamicBuff(string statName, float duration, Modifier.Type type, float value)
    {
        this.statName = statName;
        this.duration = duration;
        modifier = new Modifier(type, value);
    }

    public void SetBuffValue(float value)
    {
        modifier.value = value;
    }
}
