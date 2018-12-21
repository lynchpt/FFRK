using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum RecordMateriaColumn
    {
        Realm = 0,
        Character = 1,
        ImagePath = 2,
        RecordMateriaName = 3,
        Effect = 4,
        UnlockCriteria = 5,
        JapaneseName = 6,
        ID = 7,
        IsInGlobal = 8,
        Checked = 9
    }

    public class RecordMateriaRow
    {
        //General
        public string Realm { get; set; }
        public string Character { get; set; }
        public string ImagePath { get; set; }
        public string RecordMateriaName { get; set; }
        public string Effect { get; set; }
        public string UnlockCriteria { get; set; }
        public string JapaneseName { get; set; }
        public string ID { get; set; }
        public string IsInGlobal { get; set; }
        public string Checked { get; set; }
    }
}
