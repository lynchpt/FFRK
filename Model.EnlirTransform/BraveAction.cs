using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    public class BraveAction : IModelDescriptor
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public string CharacterName { get; set; }
        public int CharacterId { get; set; } //filled in during merge phase
        public string SourceSoulBreakName { get; set; }
        public int SourceSoulBreakId { get; set; } //filled in during merge phase

        public string ImagePath { get; set; }
        public string BraveActionName { get; set; }
        public string JapaneseName { get; set; }

        public string BraveCondition { get; set; }
        public int BraveLevel { get; set; }


        public int AbilityType { get; set; }
        public int TargetType { get; set; }
        public int AutoTargetType { get; set; }
        public int DamageFormulaType { get; set; }
        public double Multiplier { get; set; }
        public IEnumerable<int> Elements { get; set; }

        public double CastTime { get; set; }
        public string Effects { get; set; }
        public bool IsCounterable { get; set; }
        public bool IsInGlobal { get; set; }
        public bool IsChecked { get; set; }

        public int SoulBreakPointsGained { get; set; }
        public int School { get; set; }        

    }
}
