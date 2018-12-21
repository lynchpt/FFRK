using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    public class Event: IModelDescriptor
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public string EventName { get; set; }

        public int RealmId { get; set; }

        public string RealmName { get; set; }

        public DateTime GlobalEventDate { get; set; }

        public DateTime JapaneseEventDate { get; set; }

        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; }

        public IEnumerable<string> HeroRecordsAwarded { get; set; }

        //public int SoulOfHerosAwarded { get; set; }

        public IEnumerable<string> MemoryCrystalsLevel1Awarded { get; set; }

        //public int MemoryCrystalLodesLevel1Awarded { get; set; }

        public IEnumerable<string> MemoryCrystalsLevel2Awarded { get; set; }

        //public int MemoryCrystalLodesLevel2Awarded { get; set; }

        public IEnumerable<string> MemoryCrystalsLevel3Awarded { get; set; }

        //public int MemoryCrystalLodesLevel3Awarded { get; set; }

        public IEnumerable<string> WardrobeRecordsAwarded { get; set; }

        public IEnumerable<string> AbilitiesAwarded { get; set; }
    }
}
