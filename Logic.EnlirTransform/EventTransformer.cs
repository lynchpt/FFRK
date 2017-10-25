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
        public EventTransformer(ILogger<RowTransformerBase<EventRow, Event>> logger) : base(logger)
        {
        }

        protected override Event ConvertRowToModel(int generatedId, EventRow row)
        {

            Event model = new Event();

            //prepare converters so we only need one instance
            DateConverter dateConverter = new DateConverter();
            IntConverter intConverter = new IntConverter();

            model.Id = generatedId;
            model.Description = row.EventName;

            model.EventName = row.EventName;

            model.RealmId = new RealmConverter().ConvertFromNameToId(row.Realm);
            model.RealmName = row.Realm;

            model.GlobalEventDate = dateConverter.ConvertFromEuropeanDateString(row.GlobalDate);
            model.JapaneseEventDate = dateConverter.ConvertFromEuropeanDateString(row.JapanDate);

            model.EventTypeId = new EventTypeConverter().ConvertFromNameToId(row.Type);
            model.EventTypeName = row.Type;

            model.HeroRecordsAwarded = ConvertCommaSeparatedStringToList(row.HeroRecords);
            model.SoulOfHerosAwarded = intConverter.ConvertFromStringToInt(row.SpiritOfAHero);

            model.MemoryCrystalsLevel1Awarded = ConvertCommaSeparatedStringToList(row.MemoryCrystalsLevel1);
            model.MemoryCrystalLodesLevel1Awarded = intConverter.ConvertFromStringToInt(row.MemoryCrystalLodesLevel1);

            model.MemoryCrystalsLevel2Awarded = ConvertCommaSeparatedStringToList(row.MemoryCrystalsLevel2);
            model.MemoryCrystalLodesLevel2Awarded = intConverter.ConvertFromStringToInt(row.MemoryCrystalLodesLevel2);

            model.MemoryCrystalsLevel3Awarded = ConvertCommaSeparatedStringToList(row.MemoryCrystalsLevel3);
            model.MemoryCrystalLodesLevel3Awarded = intConverter.ConvertFromStringToInt(row.MemoryCrystalLodesLevel3);

            model.WardrobeRecordsAwarded = ConvertCommaSeparatedStringToList(row.WardrobeRecords);
            model.AbilitiesAwarded = ConvertCommaSeparatedStringToList(row.AbilitiesAwarded);

            return model;
        }
    }
}
