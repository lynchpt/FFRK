using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum BraveActionColumn
    {
        //General
        Character = 0,
        Source = 1,
        ImagePath = 2,
        BraveName = 3,
        BraveLevel = 4,
        Type = 5,
        Target = 6,
        Formula = 7,
        Multiplier = 8,
        Element = 9,
        Time = 10,
        Effects = 11,
        Counter = 12,
        AutoTarget = 13,
        SB = 14,
        School = 15,
        BraveCondition = 16,
        JapaneseName = 17,
        Checked = 18
    }

    public class BraveActionRow
    {
        //General
        public string Character { get; set; }
        public string Source { get; set; }
        public string ImagePath { get; set; }
        public string BraveName { get; set; }
        public string BraveLevel { get; set; }
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
        public string School { get; set; }
        public string BraveCondition { get; set; }
        public string JapaneseName { get; set; }
        public string Checked { get; set; }
    }
}
