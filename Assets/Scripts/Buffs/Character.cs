using Buffs;
using System.Collections.Generic;
using UnityEngine;

public class Character : IBuffable
{
    public CharacterStats BaseStats { get; }
    public CharacterStats CurrentStats { get; private set; }

    private readonly List<IBuff> _buffs = new();

    public Character(CharacterStats stats)
    {
        BaseStats = stats;
        CurrentStats = stats;
    }


    public void AddBuff(IBuff buff)
    {
        _buffs.Add(buff);
        ApplyBuffs();
        Debug.Log($"Buff added: {buff}");
    }

    public void RemoveBuff(IBuff buff)
    {
        _buffs.Remove(buff);
        ApplyBuffs();
        Debug.Log($"Buff removed: {buff}");
    }
    private void ApplyBuffs()
    {
        CurrentStats = BaseStats;
        foreach (IBuff buff in _buffs)
        {
            CurrentStats = buff.ApplyBuff(CurrentStats);
        }
    }
}
