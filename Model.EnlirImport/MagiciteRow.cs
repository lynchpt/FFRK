using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum MagiciteColumn
    {
        //Magicite Stats
        Element = 0,
        ImagePath = 1,
        Name = 2,
        Realm = 3,
        Rarity = 4,
        IntroducingEvent = 5,
        HP = 6,
        ATK = 7,
        DEF = 8,
        MAG = 9,
        RES = 10,
        MND = 11,
        SPD = 12,

        //Passive 1
        Passive1Name = 13,
        Passive1StrengthLevel1 = 14,
        Passive1StrengthLevel10 = 15,
        Passive1StrengthLevel25 = 16,
        Passive1StrengthLevel50 = 17,
        Passive1StrengthLevel65 = 18,
        Passive1StrengthLevel80 = 19,
        Passive1StrengthLevel90 = 20,
        Passive1StrengthLevel99 = 21,

        //Passive 2
        Passive2Name = 22,
        Passive2StrengthLevel1 = 23,
        Passive2StrengthLevel10 = 24,
        Passive2StrengthLevel25 = 25,
        Passive2StrengthLevel50 = 26,
        Passive2StrengthLevel65 = 27,
        Passive2StrengthLevel80 = 28,
        Passive2StrengthLevel90 = 29,
        Passive2StrengthLevel99 = 30,

        //Passive 3
        Passive3Name = 31,
        Passive3StrengthLevel1 = 32,
        Passive3StrengthLevel10 = 33,
        Passive3StrengthLevel25 = 34,
        Passive3StrengthLevel50 = 35,
        Passive3StrengthLevel65 = 36,
        Passive3StrengthLevel80 = 37,
        Passive3StrengthLevel90 = 38,
        Passive3StrengthLevel99 = 39,

        //Ultra Skill
        Cooldown = 40,
        Duration = 41,
        UltraSkill = 42,
        Type = 43,
        AutoTarget = 44,
        Formula = 45,
        Multiplier = 46,
        UltraSkillElement = 47,
        Time = 48,
        Effects = 49,
        Counter = 50,
        JapaneseName = 51,
        ID = 52
    }

    public class MagiciteRow
    {
        //Magicite Stats
        public string Element { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Realm { get; set; }
        public string Rarity { get; set; }
        public string IntroducingEvent { get; set; }
        public string HP { get; set; }
        public string ATK { get; set; }
        public string DEF { get; set; }
        public string MAG { get; set; }
        public string RES { get; set; }
        public string MND { get; set; }
        public string SPD { get; set; }

        //Passive 1
        public string Passive1Name { get; set; }
        public string Passive1StrengthLevel1 { get; set; }
        public string Passive1StrengthLevel10 { get; set; }
        public string Passive1StrengthLevel25 { get; set; }
        public string Passive1StrengthLevel50 { get; set; }
        public string Passive1StrengthLevel65 { get; set; }
        public string Passive1StrengthLevel80 { get; set; }
        public string Passive1StrengthLevel90 { get; set; }
        public string Passive1StrengthLevel99 { get; set; }

        //Passive 2
        public string Passive2Name { get; set; }
        public string Passive2StrengthLevel1 { get; set; }
        public string Passive2StrengthLevel10 { get; set; }
        public string Passive2StrengthLevel25 { get; set; }
        public string Passive2StrengthLevel50 { get; set; }
        public string Passive2StrengthLevel65 { get; set; }
        public string Passive2StrengthLevel80 { get; set; }
        public string Passive2StrengthLevel90 { get; set; }
        public string Passive2StrengthLevel99 { get; set; }

        //Passive 3
        public string Passive3Name { get; set; }
        public string Passive3StrengthLevel1 { get; set; }
        public string Passive3StrengthLevel10 { get; set; }
        public string Passive3StrengthLevel25 { get; set; }
        public string Passive3StrengthLevel50 { get; set; }
        public string Passive3StrengthLevel65 { get; set; }
        public string Passive3StrengthLevel80 { get; set; }
        public string Passive3StrengthLevel90 { get; set; }
        public string Passive3StrengthLevel99 { get; set; }
        
        //Ultra Skill
        public string Cooldown { get; set; }
        public string Duration { get; set; }
        public string UltraSkill { get; set; }
        public string Type { get; set; }
        public string AutoTarget { get; set; }
        public string Formula { get; set; }
        public string Multiplier { get; set; }
        public string UltraSkillElement { get; set; }
        public string Time { get; set; }
        public string Effects { get; set; }
        public string Counter { get; set; }
        public string JapaneseName { get; set; }
        public string ID { get; set; }
    }
}
