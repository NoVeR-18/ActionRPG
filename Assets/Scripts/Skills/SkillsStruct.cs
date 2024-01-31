using UnityEngine;

namespace Skills
{

    public struct StatChange
    {
        public UnitStatType type;
        public int value;
    }
    public struct AoeForm
    {
        public AoeType type;
        public float size1;
        public float size2;
    }

    public struct TargetData
    {
        public Vector2 pos;
        public int unitId;
    }

    // Data for the skill that currently in casting stage
    public struct SkillActivationData
    {
        public TargetData target;
        public bool activated;
        public float currentCastingTime;
        public float activeTime;
        public bool castStarted;
    }
}

