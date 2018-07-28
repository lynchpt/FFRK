using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum CommandColumn
    {
        //General
        Character = 0,
        Source = 1,
        ImagePath = 2,
        CommandName = 3,
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
        JapaneseName = 15,
        ID = 16,
        IsInGlobal = 17,
        Checked = 18
    }

    public class CommandRow
    {
        //General
        public string Character { get; set; }
        public string Source { get; set; }
        public string ImagePath { get; set; }
        public string CommandName { get; set; }
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
        public string JapaneseName { get; set; }
        public string ID { get; set; }
        public string IsInGlobal { get; set; }
        public string Checked { get; set; }
    }
}
