using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum MagiciteSkillColumn
    {
        Magicite = 0,
        ImagePath = 1,
        Name = 2,
        ChanceToUseTier0 = 3,
        ChanceToUseTier1 = 4,
        ChanceToUseTier2 = 5,
        ChanceToUseTier3 = 6,
        Type = 7,
        AutoTarget = 8,
        Formula = 9,
        Multiplier = 10,
        Element = 11,
        Time = 12,
        Effects = 13,
        Counter = 14,
        JapaneseName = 15,
        ID = 16,
        IsInGlobal = 17,
        Checked = 18
    }

    public class MagiciteSkillRow
    {
        public string Magicite { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string ChanceToUseTier0 { get; set; }
        public string ChanceToUseTier1 { get; set; }
        public string ChanceToUseTier2 { get; set; }
        public string ChanceToUseTier3 { get; set; }
        public string Type { get; set; }
        public string AutoTarget { get; set; }
        public string Formula { get; set; }
        public string Multiplier { get; set; }
        public string Element { get; set; }
        public string Time { get; set; }
        public string Effects { get; set; }
        public string Counter { get; set; }
        public string JapaneseName { get; set; }
        public string ID { get; set; }
        public string IsInGlobal { get; set; }
        public string Checked { get; set; }
    }
}
