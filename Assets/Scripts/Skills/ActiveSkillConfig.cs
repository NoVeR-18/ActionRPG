namespace Skills
{
    public abstract partial class ActiveSkillConfig : SkillConfigBase
    {
        public float cooldown;
        public float castTime;
        public float castRange = 1;
        public TargetType targetType;
        public AoeForm aoe;

        public SkillApplicationType application;
        public bool isProjectileActivation => application == SkillApplicationType.Projectile;
        public float projectileSpeed = 10;
        public bool requireUnitTarget => aoe.type == AoeType.None;

        public abstract void Activate();

        public virtual void Using(TargetData target, SkillActivationData data) { }
        // for channeling type skills if return false then skill is finished
        public virtual bool Tick(float dt, SkillActivationData state)
        {
            return false;
        }
    }
}