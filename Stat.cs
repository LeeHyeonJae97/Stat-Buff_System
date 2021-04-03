using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// 1. Just static base value -> no level, just baseValue
/// 
/// 2. Simple increasement on base value -> no level, just baseValue
/// 
///     public void LevelUp(float amount)
///     {
///         baseValue += amount;
///         isDirty = true;
///     }
/// 
/// 3. Increase base value by formula (ex. y = x*x) -> with level, just baseValue
/// 
///     int level;
///     
///     public void LevelUp()
///     {
///         level += 1;
///         baseValue = level * level; // some formula like 'y = x * x' (x = level, y = baseValue)
///         
///         isDirty = true;
///     }
/// 
/// 4. Use saved array that index stands for level -> with level, baseValue array
/// 
///     int level;
///     public float[] baseValue;
///     public float[] BaseValue { get { return baseValue[level]; } }
/// 
///     public void LevelUp()
///     {
///         level += 1;
///         isDirty = true;
///     }
/// 
/// </summary>

[System.Serializable]
public class Stat
{
    public string statName;

    public float baseValue;

    private bool isDirty = true;
    private float value;
    public float Value
    {
        get
        {
            if (isDirty)
            {
                value = baseValue;
                for (int i = 0; i < modifiers.Count; i++)
                {
                    Modifier modifier = modifiers[i];
                    if (modifier.type == Modifier.Type.Flat)
                    {
                        value += modifier.value;
                    }
                    else if (modifier.type == Modifier.Type.Percent)
                    {
                        value += modifier.value * baseValue;
                    }
                }

                isDirty = false;
            }

            return value;
        }
    }

    private List<Modifier> modifiers = new List<Modifier>();

    public void AddModifier(Modifier modifier)
    {
        modifiers.Add(modifier);
        isDirty = true;
    }

    public void RemoveModifier(Modifier modifier)
    {
        modifiers.Remove(modifier);
        isDirty = true;
    }

    public void RemoveAllModiifers()
    {
        this.modifiers = new List<Modifier>();
        isDirty = true;
    }
}
