using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum OtherColumn
    {
        //General
        Character = 0,
        Source = 1,
        ImagePath = 2,
        OtherName = 3,
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
        School = 14,
        IsInGlobal = 15,
        Checked = 16
    }

    public class OtherRow
    {
        public string Character { get; set; }
        public string Source { get; set; }
        public string ImagePath { get; set; }
        public string OtherName { get; set; }
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
        public string IsInGlobal { get; set; }
        public string Checked { get; set; }
    }
}
