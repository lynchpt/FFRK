using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum LegendMateriaColumn
    {
        Realm = 0,
        Character = 1,
        ImagePath = 2,
        LegendMateriaName = 3,
        Effect = 4,
        Master = 5,
        Relic = 6,
        JapaneseName = 7,
        ID = 8,
        IsInGlobal = 9,
        Checked = 10
    }


    public class LegendMateriaRow
    {
    
        //General
        public string Realm { get; set; }
        public string Character { get; set; }
        public string ImagePath { get; set; }
        public string LegendMateriaName { get; set; }
        public string Effect { get; set; }
        public string Master { get; set; }
        public string Relic { get; set; }
        public string JapaneseName { get; set; }
        public string ID { get; set; }
        public string IsInGlobal { get; set; }
        public string Checked { get; set; }

    }
}
