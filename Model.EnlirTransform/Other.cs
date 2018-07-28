using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    public class Other : IModelDescriptor
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public string CharacterName { get; set; } //use string so we don't get circular references
        public string SourceName { get; set; } //use string because it may not be possible to tie to owners: soul breaks, record materia (and circ ref)
        public string SourceType { get; set; } //null during transform, set during merge
        public int SourceId { get; set; } //0 during transform, set during merge
        public string ImagePath { get; set; }
        public string Name { get; set; }

        public int AbilityType { get; set; }

        public int TargetType { get; set; }

        public int DamageFormulaType { get; set; }

        public double Multiplier { get; set; }

        public IEnumerable<int> Elements { get; set; }

        public double CastTime { get; set; }

        public string Effects { get; set; }

        public bool IsCounterable { get; set; }

        public int AutoTargetType { get; set; }

        public int SoulBreakPointsGained { get; set; }

        public int School { get; set; }
        public bool IsInGlobal { get; set; }
        public bool IsChecked { get; set; }
    }
}
