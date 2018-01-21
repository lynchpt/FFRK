using System.Collections.Generic;

namespace FFRKApi.Dto.Api
{
    public class Ability
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        //General
        public string AbilityName { get; set; }
        public string ImagePath { get; set; }

        public int School { get; set; }

        public int Rarity { get; set; }
        public int MinUses { get; set; }
        public int MaxUses { get; set; }

        public int AbilityType { get; set; }
        public int TargetType { get; set; }
        public int AutoTargetType { get; set; }
        public int DamageFormulaType { get; set; }
        public double Multiplier { get; set; }
        public IEnumerable<int> Elements { get; set; }
        public double CastTime { get; set; }
        public string Effects { get; set; }
        public bool IsCounterable { get; set; }
        public bool IsChecked { get; set; }
        public int SoulBreakPointsGained { get; set; }
        public int SoulBreakPointsGainedJapan { get; set; }

        public string IntroducingEventName { get; set; }
        public int IntroducingEventId { get; set; } //filled in during merge phase
        public string JapaneseName { get; set; }
        public string EnlirId { get; set; }

        public IEnumerable<OrbRequirementsByRankInfo>OrbRequirements { get; set; }

    }

    public class OrbRequirementsByRankInfo
    {
        public int HoneRank { get; set; }

        public string OrbName { get; set; }

        public int OrbId { get; set; }

        public int OrbCount { get; set; }

    }
}
