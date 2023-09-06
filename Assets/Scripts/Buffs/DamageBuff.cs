using UnityEngine;

namespace Buffs
{
    public class DamageBuff : IBuff
    {
        public int Damage { get; set; }

        public DamageBuff(int DamageBonus)
        {
            Damage = DamageBonus;
        }

        public CharacterStats ApplyBuff(CharacterStats baseStats)
        {
            var newStats = baseStats;
            newStats.Damage = Mathf.Max(newStats.Damage + Damage, 0);
            return newStats;
        }
    }
}
