using System.Collections.Generic;

namespace Skills
{
    public partial class SkillConfigBase
    {
        public string id;
        public string name;
        public string baseDescription;

        public string description;

        // put this data here because it often used in various skill implementations
        public List<StatChange> statChanges;
        public float effectDuration;

        public override string ToString()
        {
            return id;
        }
    }
}