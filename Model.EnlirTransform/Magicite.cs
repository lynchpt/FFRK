using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    public class Magicite : IModelDescriptor
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        //core attributes
        public string MagiciteName { get; set; }

        public int Element { get; set; }

        public int Rarity { get; set; }

        public int Realm { get; set; }

        public string ImagePath { get; set; }

        public string IntroducingEventName { get; set; }
        public int IntroducingEventId { get; set; }

        //stats
        public int HitPoints { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Magic { get; set; }
        public int Resistance { get; set; }
        public int Mind { get; set; }
        public int Speed { get; set; }

        //passives
        public IEnumerable<PassiveEffectValueByLevelInfo> PassiveEffects { get; set; }

        public UltraSkill UltraSkill { get; set; }

        public IEnumerable<MagiciteSkill> MagiciteSkills { get; set; }

    }

    public class UltraSkill
    {

        public string Name { get; set; }

        public string JapaneseName { get; set; }

        public int AbilityType { get; set; }

        public int AutoTargetType { get; set; }

        public int DamageFormulaType { get; set; }

        public double Multiplier { get; set; }

        public int Element { get; set; }

        public double CastTime { get; set; }

        public string Effects { get; set; }

        public bool IsCounterable { get; set; }

        public double Cooldown { get; set; }

        public double Duration { get; set; }

        public string EnlirId { get; set; }

    }

    public class PassiveEffectValueByLevelInfo
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public int Value { get; set; }

    }
}
