using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum DungeonColumn
    {
        //General
        Realm = 0,
        DungeonName = 1,

        //Classic
        StaminaClassic = 2,
        DifficultyClassic = 3,
        CompletionClassic = 4,
        FirstTimeClassic = 5,
        MasteryClassic = 6,

        //Elite
        StaminaElite = 7,
        DifficultyElite = 8,
        CompletionElite = 9,
        FirstTimeElite = 10,
        MasteryElite = 11,
        Update = 12
    }

    public class DungeonRow
    {
        //General
        public string Realm { get; set; }
        public string DungeonName { get; set; }

        //Classic
        public string StaminaClassic { get; set; }
        public string DifficultyClassic { get; set; }
        public string CompletionClassic { get; set; }
        public string FirstTimeClassic { get; set; }
        public string MasteryClassic { get; set; }

        //Elite
        public string StaminaElite { get; set; }
        public string DifficultyElite { get; set; }
        public string CompletionElite { get; set; }
        public string FirstTimeElite { get; set; }
        public string MasteryElite { get; set; }
        public string Update { get; set; }

    }
}
