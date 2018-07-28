namespace FFRKApi.Dto.Api
{
    public class Relic
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public string RelicName { get; set; }

        public int Realm { get; set; }

        public string CharacterName { get; set; }
        public int CharacterId { get; set; } //fill during merge phase

        public string SoulBreakName { get; set; }
        public int SoulBreakId { get; set; } //fill during merge phase

        public SoulBreak SoulBreak { get; set; } //fill during merge phase

        public string LegendMateriaName { get; set; }
        public int LegendMateriaId { get; set; } //fill during merge phase



        public int RelicType { get; set; }
        public bool HasSynergy { get; set; }
        public string CombineLevel { get; set; }
        public int Rarity { get; set; }
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Magic { get; set; }
        public int Resistance { get; set; }
        public int Mind { get; set; }
        public int Accuracy { get; set; }
        public int Evasion { get; set; }
        public string Effect { get; set; }


        public int BaseRarity { get; set; }
        public int BaseLevel { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefense { get; set; }
        public int BaseMagic { get; set; }
        public int BaseResistance { get; set; }
        public int BaseMind { get; set; }
        public int BaseAccuracy { get; set; }
        public int BaseEvasion { get; set; }

        public int MaxRarity { get; set; }
        public int MaxLevel { get; set; }
        public int MaxAttack { get; set; }
        public int MaxDefense { get; set; }
        public int MaxMagic { get; set; }
        public int MaxResistance { get; set; }
        public int MaxMind { get; set; }
        public int MaxAccuracy { get; set; }
        public int MaxEvasion { get; set; }

        public string EnlirId { get; set; }
        public bool IsInGlobal { get; set; }

    }
}
