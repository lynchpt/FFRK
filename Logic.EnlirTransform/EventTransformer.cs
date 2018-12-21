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
    public class EventTransformer : RowTransformerBase<EventRow, Event>
    {
        #region Class Variables
        private TypeListConverter _realmConverter;
        private TypeListConverter _eventTypeConverter;
        private DateConverter _dateConverter;
        private IntConverter _intConverter;

        #endregion

        #region Constructors
        public EventTransformer(ILogger<RowTransformerBase<EventRow, Event>> logger) : base(logger)
        {
            //prepare converters so we only need one instance
            _dateConverter = new DateConverter();
            _intConverter = new IntConverter();
            _realmConverter = new TypeListConverter(new RealmList());
            _eventTypeConverter = new TypeListConverter(new EventTypeList());
        }
        #endregion

        #region RowTransformerBase Overrides
        protected override Event ConvertRowToModel(int generatedId, EventRow row)
        {
            Event model = new Event();

            model.Id = generatedId;
            model.Description = row.EventName;

            model.EventName = row.EventName;

            model.RealmId = _realmConverter.ConvertFromNameToId(row.Realm);
            model.RealmName = row.Realm;

            model.GlobalEventDate = _dateConverter.ConvertFromEuropeanDateString(row.GlobalDate);
            model.JapaneseEventDate = _dateConverter.ConvertFromEuropeanDateString(row.JapanDate);

            model.EventTypeId = _eventTypeConverter.ConvertFromNameToId(row.Type);
            model.EventTypeName = row.Type;

            model.HeroRecordsAwarded = ConvertCommaSeparatedStringToList(row.HeroRecords);
            //model.SoulOfHerosAwarded = _intConverter.ConvertFromStringToInt(row.SpiritOfAHero);

            model.MemoryCrystalsLevel1Awarded = ConvertCommaSeparatedStringToList(row.MemoryCrystalsLevel1);
            //model.MemoryCrystalLodesLevel1Awarded = _intConverter.ConvertFromStringToInt(row.MemoryCrystalLodesLevel1);

            model.MemoryCrystalsLevel2Awarded = ConvertCommaSeparatedStringToList(row.MemoryCrystalsLevel2);
            //model.MemoryCrystalLodesLevel2Awarded = _intConverter.ConvertFromStringToInt(row.MemoryCrystalLodesLevel2);

            model.MemoryCrystalsLevel3Awarded = ConvertCommaSeparatedStringToList(row.MemoryCrystalsLevel3);
            //model.MemoryCrystalLodesLevel3Awarded = _intConverter.ConvertFromStringToInt(row.MemoryCrystalLodesLevel3);

            model.WardrobeRecordsAwarded = ConvertCommaSeparatedStringToList(row.WardrobeRecords);
            model.AbilitiesAwarded = ConvertCommaSeparatedStringToList(row.AbilitiesAwarded);

            _logger.LogDebug("Converted EventRow to Event: {Id} - {Description}", model.Id, model.Description);

            return model;
        } 
        #endregion
    }
}
