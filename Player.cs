using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Stat[] stats;
    private Dictionary<string, Stat> statDic = new Dictionary<string, Stat>();

    private void Awake()
    {
        for (int i = 0; i < stats.Length; i++)
            statDic.Add(stats[i].statName, stats[i]);
    }

    public float GetStatValue(string statName)
    {
        return statDic.ContainsKey(statName) ? statDic[statName].Value : 0;
    }

    public void AddBuff(StaticBuff buff)
    {
        if (statDic.ContainsKey(buff.statName)) statDic[buff.statName].AddModifier(buff.modifier);
    }

    public void AddBuff(StaticBuff[] buffs)
    {
        for (int i = 0; i < buffs.Length; i++)
        {
            StaticBuff buff = buffs[i];
            if (statDic.ContainsKey(buff.statName)) statDic[buff.statName].AddModifier(buff.modifier);
        }
    }

    public void RemoveBuff(StaticBuff buff)
    {
        if (statDic.ContainsKey(buff.statName)) statDic[buff.statName].RemoveModifier(buff.modifier);
    }

    public void RemoveBuff(StaticBuff[] buffs)
    {
        for (int i = 0; i < buffs.Length; i++)
        {
            StaticBuff buff = buffs[i];
            if (statDic.ContainsKey(buff.statName)) statDic[buff.statName].RemoveModifier(buff.modifier);
        }
    }

    public void AddBuff(DynamicBuff buff)
    {
        if (statDic.ContainsKey(buff.statName))
        {
            statDic[buff.statName].AddModifier(buff.modifier);
            StartCoroutine(RemoveBuff(buff));
        }
    }

    public void AddBuff(DynamicBuff[] buffs)
    {
        for (int i = 0; i < buffs.Length; i++)
        {
            DynamicBuff buff = buffs[i];
            if (statDic.ContainsKey(buff.statName))
            {
                statDic[buff.statName].AddModifier(buff.modifier);
                StartCoroutine(RemoveBuff(buff));
            }
        }
    }

    private IEnumerator RemoveBuff(DynamicBuff buff)
    {
        yield return new WaitForSeconds(buff.duration);
        statDic[buff.statName].RemoveModifier(buff.modifier);
    }
}
