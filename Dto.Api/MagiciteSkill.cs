namespace FFRKApi.Dto.Api
{
    public class MagiciteSkill
    {

        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public string MagiciteName { get; set; }
        public int MagiciteId { get; set; }
        public string SkillName { get; set; }

        public string JapaneseName { get; set; }
        public string ImagePath { get; set; }

        public int AbilityType { get; set; }

        public int AutoTargetType { get; set; }

        public int DamageFormulaType { get; set; }

        public double Multiplier { get; set; }

        public int Element { get; set; }

        public double CastTime { get; set; }

        public string Effects { get; set; }

        public bool IsCounterable { get; set; }

        public bool IsChecked { get; set; }

        public double ChanceForSkillUseWith0LevelCapBreaks { get; set; }
        public double ChanceForSkillUseWith1LevelCapBreaks { get; set; }
        public double ChanceForSkillUseWith2LevelCapBreaks { get; set; }
        public double ChanceForSkillUseWith3LevelCapBreaks { get; set; }


    }
}
