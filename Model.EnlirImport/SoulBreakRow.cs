using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum SoulBreakColumn
    {
        //General
        Realm = 0,
        Character = 1,
        ImagePath = 2,
        SoulBreakName = 3,
        Type = 4,
        Target = 5,
        Formula = 6,
        Multiplier = 7,
        Element = 8,
        Time = 9,
        Effects = 10,
        Counter = 11,
        AutoTarget = 12,
        Points = 13,
        Tier = 14,
        Master = 15,
        Relic = 16,
        JapaneseName = 17,
        ID = 18,
        Checked = 19

    }

    public class SoulBreakRow
    {
        //General
        public string Realm { get; set; }
        public string Character { get; set; }
        public string ImagePath { get; set; }
        public string SoulBreakName { get; set; }
        public string Type { get; set; }
        public string Target { get; set; }
        public string Formula { get; set; }
        public string Multiplier { get; set; }
        public string Element { get; set; }
        public string Time { get; set; }
        public string Effects { get; set; }
        public string Counter { get; set; }
        public string AutoTarget { get; set; }
        public string Points { get; set; }
        public string Tier { get; set; }
        public string Master { get; set; }
        public string Relic { get; set; }
        public string JapaneseName { get; set; }
        public string ID { get; set; }
        public string Checked { get; set; }
    }
}
