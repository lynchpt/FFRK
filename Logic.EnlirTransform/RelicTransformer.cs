using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using FFRKApi.Model.EnlirTransform.Converters;
using FFRKApi.Model.EnlirTransform.IdLists;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.EnlirTransform
{
    public class RelicTransformer : RowTransformerBase<RelicRow, Relic>
    {
        #region Class Variables
        private readonly IntConverter _intConverter;
        private readonly TypeListConverter _realmConverter;
        private readonly TypeListConverter _relicTypeConverter;
        private readonly StringToBooleanConverter _stringToBooleanConverter;

        #endregion

        public RelicTransformer(ILogger<RowTransformerBase<RelicRow, Relic>> logger) : base(logger)
        {
            //prepare converters so we only need one instance no matter how many rows are processed
            _intConverter = new IntConverter();
            _realmConverter = new TypeListConverter(new RealmList());
            _relicTypeConverter = new TypeListConverter(new RelicTypeList());
            _stringToBooleanConverter = new StringToBooleanConverter();

        }

        protected override Relic ConvertRowToModel(int generatedId, RelicRow row)
        {
            Relic model = new Relic();


            model.Id = generatedId;
            model.Description = $"{row.RelicName} - {row.Realm}" ;

            model.RelicName = row.RelicName;
            model.Realm = _realmConverter.ConvertFromNameToId(row.Realm);
            model.RelicType = _relicTypeConverter.ConvertFromNameToId(row.Type);
            model.EnlirId = row.ID;

            model.CharacterName = row.Character.Replace(DashCharacter, String.Empty);
            model.CharacterId = 0; //fill during merge phase

            model.SoulBreakName = row.SoulBreak;
            model.SoulBreakId = 0; //fill during merge phase
            model.SoulBreak = null; //fill during merge phase

            model.LegendMateriaName = row.LegendMateria;
            model.LegendMateriaId = 0; //fill during merge phase

            model.HasSynergy = _stringToBooleanConverter.ConvertFromStringToBool(row.Synergy);
            model.CombineLevel = row.Combine;

            model.Rarity = _intConverter.ConvertFromStringToInt(row.Rarity);
            model.Level = _intConverter.ConvertFromStringToInt(row.Level);
            model.Attack = _intConverter.ConvertFromStringToInt(row.ATK);
            model.Defense = _intConverter.ConvertFromStringToInt(row.DEF);
            model.Magic = _intConverter.ConvertFromStringToInt(row.MAG);
            model.Resistance = _intConverter.ConvertFromStringToInt(row.RES);
            model.Mind = _intConverter.ConvertFromStringToInt(row.MND);
            model.Accuracy = _intConverter.ConvertFromStringToInt(row.ACC);
            model.Evasion = _intConverter.ConvertFromStringToInt(row.EVA);

            model.Effect = row.Effect;

            model.BaseRarity = _intConverter.ConvertFromStringToInt(row.BRAR);
            model.BaseLevel = _intConverter.ConvertFromStringToInt(row.BLV);
            model.BaseAttack = _intConverter.ConvertFromStringToInt(row.BATK);
            model.BaseDefense = _intConverter.ConvertFromStringToInt(row.BDEF);
            model.BaseMagic = _intConverter.ConvertFromStringToInt(row.BMAG);
            model.BaseResistance = _intConverter.ConvertFromStringToInt(row.BRES);
            model.BaseMind = _intConverter.ConvertFromStringToInt(row.BMND);
            model.BaseAccuracy = _intConverter.ConvertFromStringToInt(row.BACC);
            model.BaseEvasion = _intConverter.ConvertFromStringToInt(row.BEVA);

            model.MaxRarity = _intConverter.ConvertFromStringToInt(row.MRAR);
            model.MaxLevel = _intConverter.ConvertFromStringToInt(row.MLV);
            model.MaxAttack = _intConverter.ConvertFromStringToInt(row.MATK);
            model.MaxDefense = _intConverter.ConvertFromStringToInt(row.MDEF);
            model.MaxMagic = _intConverter.ConvertFromStringToInt(row.MMAG);
            model.MaxResistance = _intConverter.ConvertFromStringToInt(row.MRES);
            model.MaxMind = _intConverter.ConvertFromStringToInt(row.MMND);
            model.MaxAccuracy = _intConverter.ConvertFromStringToInt(row.MACC);
            model.MaxEvasion = _intConverter.ConvertFromStringToInt(row.MEVA);


            _logger.LogDebug("Converted RelicRow to Relic: {Id} - {Description}", model.Id, model.Description);

            return model;
        }
    }
}
