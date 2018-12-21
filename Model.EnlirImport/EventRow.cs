using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum EventColumn
    {
        EventName = 0,
        Realm = 1,
        GlobalDate = 2,
        JapanDate = 3,
        Type = 4,
        HeroRecords = 5,
        //SpiritOfAHero = 6,
        MemoryCrystalsLevel1 = 6,
        //MemoryCrystalLodesLevel1 = 8,
        MemoryCrystalsLevel2 = 7,
        //MemoryCrystalLodesLevel2 = 10,
        MemoryCrystalsLevel3 = 8,
        //MemoryCrystalLodesLevel3 = 12,
        WardrobeRecords = 9,
        AbilitiesAwarded = 10
    }

    public class EventRow
    {
        public string EventName { get; set; }
        public string Realm { get; set; }
        public string GlobalDate { get; set; }
        public string JapanDate { get; set; }
        public string Type { get; set; }
        public string HeroRecords { get; set; }
        //public string SpiritOfAHero { get; set; }
        public string MemoryCrystalsLevel1 { get; set; }
        //public string MemoryCrystalLodesLevel1 { get; set; }
        public string MemoryCrystalsLevel2 { get; set; }
        //public string MemoryCrystalLodesLevel2 { get; set; }
        public string MemoryCrystalsLevel3 { get; set; }
        //public string MemoryCrystalLodesLevel3 { get; set; }
        public string WardrobeRecords { get; set; }
        public string AbilitiesAwarded { get; set; }

    }
}
