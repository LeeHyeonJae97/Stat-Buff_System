using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Modifier
{
    public enum Type { Flat, Percent }

    public Type type;
    public float value;

    public Modifier(Type type, float value)
    {
        this.type = type;
        this.value = value;
    }
}
