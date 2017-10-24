using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum RelicColumn
    {
        RelicName = 0,
        Realm = 1,
        Type = 2,
        Synergy = 3,
        Combine = 4,
        Rarity = 5,
        Level = 6,
        ATK = 7,
        DEF = 8,
        MAG = 9,
        RES = 10,
        MND = 11,
        ACC = 12,
        EVA = 13,
        Effect = 14,
        Character = 15,
        SoulBreak = 16,
        LegendMateria = 17,
        BRAR = 18,
        BLV = 19,
        BATK = 20,
        BDEF = 21,
        BMAG = 22,
        BRES = 23,
        BMND = 24,
        BACC = 25,
        BEVA = 26,
        MRAR = 27,
        MLV = 28,
        MATK = 29,
        MDEF = 30,
        MMAG = 31,
        MRES = 32,
        MMND = 33,
        MACC = 34,
        MEVA = 35,
        ID = 36
    }

    public class RelicRow
    {
        public string RelicName { get; set; }
        public string Realm { get; set; }
        public string Type { get; set; }
        public string Synergy { get; set; }
        public string Combine { get; set; }
        public string Rarity { get; set; }
        public string Level { get; set; }
        public string ATK { get; set; }
        public string DEF { get; set; }
        public string MAG { get; set; }
        public string RES { get; set; }
        public string MND { get; set; }
        public string ACC { get; set; }
        public string EVA { get; set; }
        public string Effect { get; set; }
        public string Character { get; set; }
        public string SoulBreak { get; set; }
        public string LegendMateria { get; set; }
        public string BRAR { get; set; }
        public string BLV { get; set; }
        public string BATK { get; set; }
        public string BDEF { get; set; }
        public string BMAG { get; set; }
        public string BRES { get; set; }
        public string BMND { get; set; }
        public string BACC { get; set; }
        public string BEVA { get; set; }
        public string MRAR { get; set; }
        public string MLV { get; set; }
        public string MATK { get; set; }
        public string MDEF { get; set; }
        public string MMAG { get; set; }
        public string MRES { get; set; }
        public string MMND { get; set; }
        public string MACC { get; set; }
        public string MEVA { get; set; }
        public string ID { get; set; }
    }
}
