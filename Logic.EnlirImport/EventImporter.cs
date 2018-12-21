using System;
using System.Collections.Generic;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Model.EnlirImport;
using FFRKApi.SheetsApiHelper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FFRKApi.Logic.EnlirImport
{
    public class EventImporter : RowImporterBase<EventRow>
    {
        public EventImporter(ISheetsApiHelper sheetsApiHelper, IOptions<EventImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<EventRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override EventRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            EventRow importedRow = new EventRow();

            importedRow.EventName = ResolveColumnContents(columnCount, EventColumn.EventName, row);
            importedRow.Realm = ResolveColumnContents(columnCount, EventColumn.Realm, row);
            importedRow.GlobalDate = ResolveColumnContents(columnCount, EventColumn.GlobalDate, row);
            importedRow.JapanDate = ResolveColumnContents(columnCount, EventColumn.JapanDate, row);
            importedRow.Type = ResolveColumnContents(columnCount, EventColumn.Type, row);
            importedRow.HeroRecords = ResolveColumnContents(columnCount, EventColumn.HeroRecords, row);
            //importedRow.SpiritOfAHero = ResolveColumnContents(columnCount, EventColumn.SpiritOfAHero, row);
            importedRow.MemoryCrystalsLevel1 = ResolveColumnContents(columnCount, EventColumn.MemoryCrystalsLevel1, row);
            //importedRow.MemoryCrystalLodesLevel1 = ResolveColumnContents(columnCount, EventColumn.MemoryCrystalLodesLevel1, row);
            importedRow.MemoryCrystalsLevel2 = ResolveColumnContents(columnCount, EventColumn.MemoryCrystalsLevel2, row);
            //importedRow.MemoryCrystalLodesLevel2 = ResolveColumnContents(columnCount, EventColumn.MemoryCrystalLodesLevel2, row);
            importedRow.MemoryCrystalsLevel3 = ResolveColumnContents(columnCount, EventColumn.MemoryCrystalsLevel3, row);
            //importedRow.MemoryCrystalLodesLevel3 = ResolveColumnContents(columnCount, EventColumn.MemoryCrystalLodesLevel3, row);
            importedRow.WardrobeRecords = ResolveColumnContents(columnCount, EventColumn.WardrobeRecords, row);
            importedRow.AbilitiesAwarded = ResolveColumnContents(columnCount, EventColumn.AbilitiesAwarded, row);

            return importedRow;
        }
    }
}
