using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    public class LegendSphere : IModelDescriptor
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public int Realm { get; set; }
        public string CharacterName { get; set; }
        public int CharacterId { get; set; } //filled in during merge phase

        //1 is the top of the legend sphere grid, with the least valuable benefits.
        //5 is the bottom of the legend sphere grid, with the most valuable benefits.
        public int Tier { get; set; } //filled in during merge phase

        public IEnumerable<LegendSphereInfo> LegendSphereInfos { get; set; }
    }

    public class LegendSphereInfo
    {

        //in a given tier, this is the position of the benefit from left to right.
        public int Index { get; set; }

        public string Benefit { get; set; }

        public IList<ItemWithCountAndStarLevel> RequiredMotes { get; set; }
    }
}
