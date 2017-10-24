using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum ExperienceColumn
    {
        Level = 0,
        Character = 1,
        NextLevelCharacter = 2,
        Tyro = 3,
        NextLevelTyro = 4,
        Magicite1 = 5,
        NextLevelMagicite1 = 6,
        Magicite2 = 7,
        NextLevelMagicite2 = 8,
        Magicite3 = 9,
        NextLevelMagicite3 = 10,
        Magicite4 = 11,
        NextLevelMagicite4 = 12,
        Magicite5 = 13,
        NextLevelMagicite5 = 14,
        Inheritance3 = 15,
        NextLevelInheritance3 = 16,
        Inheritance4 = 17,
        NextLevelInheritance4 = 18,
        Inheritance5 = 19,
        NextLevelInheritance5 = 20
    }

    public class ExperienceRow
    {
        public string Level { get; set; }
        public string Character { get; set; }
        public string NextLevelCharacter { get; set; }
        public string Tyro { get; set; }
        public string NextLevelTyro { get; set; }
        public string Magicite1 { get; set; }
        public string NextLevelMagicite1 { get; set; }
        public string Magicite2 { get; set; }
        public string NextLevelMagicite2 { get; set; }
        public string Magicite3 { get; set; }
        public string NextLevelMagicite3 { get; set; }
        public string Magicite4 { get; set; }
        public string NextLevelMagicite4 { get; set; }
        public string Magicite5 { get; set; }
        public string NextLevelMagicite5 { get; set; }
        public string Inheritance3 { get; set; }
        public string NextLevelInheritance3 { get; set; }
        public string Inheritance4 { get; set; }
        public string NextLevelInheritance4 { get; set; }
        public string Inheritance5 { get; set; }
        public string NextLevelInheritance5 { get; set; }
    }
}
