using System;

public enum UnitStatType
{
    strength,
    agility,
    intellect,
    stamina,
    melee_power,
    block_chance,
    armor,
    ranged_power,
    dodge_chance,
    critical_strike_chance,
    spell_power,
    mana_pool,
    spell_crit_chance,
    mana_regeneration,
    health_pool,
    health_regeneration,
    magic_resistance,
    movement_speed,
    attack_power_multiplier,
    damage_received_multiplier,
    armor_multiplier,

    MAX
}

public enum Specialization
{
    Warrior,
    Mage,
    Hunter
}

[Flags]
public enum ItemType
{
    None,
    Sword = 1 << 0,
    TwoHandedSwords = 1 << 1,
    TwoHandedAxes = 1 << 2,
    Bow = 1 << 3,
    DualCrossbows = 1 << 4,
    Staff = 1 << 5,
    MagicSword = 1 << 6,
    Plate = 1 << 7,
    Leather = 1 << 8,
    Cloth = 1 << 9,
    All = ~0
}

public enum SkillGroupType
{
    BasicSkills,
    SpecializationWeaponSkills,
    Active,
    Passive,
}

[Flags]
public enum ItemSlotType
{
    None,
    Weapon = 1 << 0,
    Helmet = 1 << 1,
    Chest = 1 << 2,
    Cloak = 1 << 3,
    Ring = 1 << 4,
    Trinkets = 1 << 5,
}

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
}

public enum OverlapType
{
    Box,
    Sphere,
}
public enum DrawGizmosType
{
    Always,
    OnSelected,
    Never
}