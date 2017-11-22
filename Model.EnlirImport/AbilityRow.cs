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
        SBJP = 14,
        Uses = 15,
        Max = 16,

        //Orb 1
        Orb1RequiredType = 17,
        Orb1RequiredRank1 = 18,
        Orb1RequiredRank2 = 19,
        Orb1RequiredRank3 = 20,
        Orb1RequiredRank4 = 21,
        Orb1RequiredRank5 = 22,

        //Orb 2
        Orb2RequiredType = 23,
        Orb2RequiredRank1 = 24,
        Orb2RequiredRank2 = 25,
        Orb2RequiredRank3 = 26,
        Orb2RequiredRank4 = 27,
        Orb2RequiredRank5 = 28,

        //Orb 3
        Orb3RequiredType = 29,
        Orb3RequiredRank1 = 30,
        Orb3RequiredRank2 = 31,
        Orb3RequiredRank3 = 32,
        Orb3RequiredRank4 = 33,
        Orb3RequiredRank5 = 34,

        //Orb 4
        Orb4RequiredType = 35,
        Orb4RequiredRank1 = 36,
        Orb4RequiredRank2 = 37,
        Orb4RequiredRank3 = 38,
        Orb4RequiredRank4 = 39,
        Orb4RequiredRank5 = 40,

        //Misc
        IntroducingEvent = 41,
        ID = 42,
        Checked = 43
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
        public string ID { get; set; }
        public string Checked { get; set; }

    }
}
