using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum AbilityColumn
    {
        //General
        School = 0,
        ImagePath = 1,
        AbilityName = 2,
        Rarity = 3,
        Type = 4,
        Target = 5,
        Formula = 6,
        Multiplier = 7,
        Element = 8,
        Time = 9,
        Effects = 10,
        Counter = 11,
        AutoTarget = 12,
        SB = 13,
        Uses = 14,
        Max = 15,

        //Orb 1
        Orb1RequiredType = 16,
        Orb1RequiredRank1 = 17,
        Orb1RequiredRank2 = 18,
        Orb1RequiredRank3 = 19,
        Orb1RequiredRank4 = 20,
        Orb1RequiredRank5 = 21,

        //Orb 2
        Orb2RequiredType = 22,
        Orb2RequiredRank1 = 23,
        Orb2RequiredRank2 = 24,
        Orb2RequiredRank3 = 25,
        Orb2RequiredRank4 = 26,
        Orb2RequiredRank5 = 27,

        //Orb 3
        Orb3RequiredType = 28,
        Orb3RequiredRank1 = 29,
        Orb3RequiredRank2 = 30,
        Orb3RequiredRank3 = 31,
        Orb3RequiredRank4 = 32,
        Orb3RequiredRank5 = 33,

        //Orb 4
        Orb4RequiredType = 34,
        Orb4RequiredRank1 = 35,
        Orb4RequiredRank2 = 36,
        Orb4RequiredRank3 = 37,
        Orb4RequiredRank4 = 38,
        Orb4RequiredRank5 = 39,

        //Misc
        IntroducingEvent = 40,
        JapaneseName = 41,
        ID = 42,
        IsInGlobal = 43,
        Checked = 44
    }

    public class AbilityRow
    {
        //General
        public string School { get; set; }
        public string ImagePath { get; set; }
        public string AbilityName { get; set; }
        public string Rarity { get; set; }
        public string Type { get; set; }
        public string Target { get; set; }
        public string Formula { get; set; }
        public string Multiplier { get; set; }
        public string Element { get; set; }
        public string Time { get; set; }
        public string Effects { get; set; }
        public string Counter { get; set; }
        public string AutoTarget { get; set; }
        public string SB { get; set; }
        public string SBJP { get; set; }
        public string Uses { get; set; }
        public string Max { get; set; }

        //Orb 1
        public string Orb1RequiredType { get; set; }
        public string Orb1RequiredRank1 { get; set; }
        public string Orb1RequiredRank2 { get; set; }
        public string Orb1RequiredRank3 { get; set; }
        public string Orb1RequiredRank4 { get; set; }
        public string Orb1RequiredRank5 { get; set; }

        //Orb 2
        public string Orb2RequiredType { get; set; }
        public string Orb2RequiredRank1 { get; set; }
        public string Orb2RequiredRank2 { get; set; }
        public string Orb2RequiredRank3 { get; set; }
        public string Orb2RequiredRank4 { get; set; }
        public string Orb2RequiredRank5 { get; set; }

        //Orb 3
        public string Orb3RequiredType { get; set; }
        public string Orb3RequiredRank1 { get; set; }
        public string Orb3RequiredRank2 { get; set; }
        public string Orb3RequiredRank3 { get; set; }
        public string Orb3RequiredRank4 { get; set; }
        public string Orb3RequiredRank5 { get; set; }

        //Orb 4
        public string Orb4RequiredType { get; set; }
        public string Orb4RequiredRank1 { get; set; }
        public string Orb4RequiredRank2 { get; set; }
        public string Orb4RequiredRank3 { get; set; }
        public string Orb4RequiredRank4 { get; set; }
        public string Orb4RequiredRank5 { get; set; }


        //Misc
        public string IntroducingEvent { get; set; }
        public string JapaneseName { get; set; }
        public string ID { get; set; }
        public string IsInGlobal { get; set; }
        public string Checked { get; set; }

    }
}
