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
    public class RecordMateriaTransformer : RowTransformerBase<RecordMateriaRow, RecordMateria>
    {
        #region Class Variables

        private readonly StringToBooleanConverter _stringToBooleanConverter;
        private readonly TypeListConverter _realmConverter;
        #endregion

        #region Constructors
        public RecordMateriaTransformer(ILogger<RowTransformerBase<RecordMateriaRow, RecordMateria>> logger) : base(logger)
        {
            //prepare converters so we only need one instance no matter how many rows are processed
            _realmConverter = new TypeListConverter(new RealmList());
            _stringToBooleanConverter = new StringToBooleanConverter();
        }
        #endregion

        #region RowTransformerBase Overrides
        protected override RecordMateria ConvertRowToModel(int generatedId, RecordMateriaRow row)
        {
            RecordMateria model = new RecordMateria();

            model.Id = generatedId;
            model.Description = $"{row.Character} - {row.RecordMateriaName}";

            model.RecordMateriaName = row.RecordMateriaName;
            model.JapaneseName = row.JapaneseName ?? String.Empty;

            model.ImagePath = row.ImagePath;
            model.Realm = _realmConverter.ConvertFromNameToId(row.Realm);

            model.CharacterName = row.Character;
            model.CharacterId = 0; //filled in during merge phase


            model.Effect = row.Effect;
            model.UnlockCriteria = row.UnlockCriteria;
            model.IsInGlobal = _stringToBooleanConverter.ConvertFromStringToBool(row.IsInGlobal);
            model.IsChecked = _stringToBooleanConverter.ConvertFromStringToBool(row.Checked);


            _logger.LogDebug("Converted RecordMateriaRow to RecordMateria: {Id} - {Description}", model.Id, model.Description);

            return model;
        } 
        #endregion
    }
}
