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
    public class LegendMateriaTransformer : RowTransformerBase<LegendMateriaRow, LegendMateria>
    {
        #region Class Variables

        private readonly StringToBooleanConverter _stringToBooleanConverter;
        private readonly TypeListConverter _realmConverter;
        #endregion

        #region Constructors
        public LegendMateriaTransformer(ILogger<RowTransformerBase<LegendMateriaRow, LegendMateria>> logger) : base(logger)
        {
            //prepare converters so we only need one instance no matter how many rows are processed
            _realmConverter = new TypeListConverter(new RealmList());
            _stringToBooleanConverter = new StringToBooleanConverter();
        }
        #endregion

        #region RowTransformerBase Overrides
        protected override LegendMateria ConvertRowToModel(int generatedId, LegendMateriaRow row)
        {
            LegendMateria model = new LegendMateria();

            model.Id = generatedId;
            model.Description = row.LegendMateriaName;

            model.LegendMateriaName = row.LegendMateriaName;
            model.JapaneseName = row.JapaneseName ?? String.Empty;

            model.ImagePath = row.ImagePath;
            model.Realm = _realmConverter.ConvertFromNameToId(row.Realm);

            model.CharacterName = row.Character;
            model.CharacterId = 0; //filled in during merge phase

            model.RelicName = row.Relic != null ? row.Relic.Replace(DashCharacter, String.Empty) : String.Empty;
            model.RelicId = 0; //filled in during merge phase

            model.Effect = row.Effect;
            model.MasteryBonus = row.Master;
            model.IsChecked = _stringToBooleanConverter.ConvertFromStringToBool(row.Checked);



            _logger.LogInformation("Converted LegendMateriaRow to LegendMateria: {Id} - {Description}", model.Id, model.Description);

            return model;
        } 
        #endregion
    }
}
