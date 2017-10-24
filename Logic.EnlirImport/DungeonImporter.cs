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
    public class DungeonImporter : RowImporterBase<DungeonRow>
    {
        public DungeonImporter(ISheetsApiHelper sheetsApiHelper, IOptions<DungeonImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<DungeonRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override DungeonRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            DungeonRow importedRow = new DungeonRow();

            importedRow.Realm = ResolveColumnContents(columnCount, DungeonColumn.Realm, row);
            importedRow.DungeonName = ResolveColumnContents(columnCount, DungeonColumn.DungeonName, row);
            importedRow.StaminaClassic = ResolveColumnContents(columnCount, DungeonColumn.StaminaClassic, row);
            importedRow.DifficultyClassic = ResolveColumnContents(columnCount, DungeonColumn.DifficultyClassic, row);
            importedRow.CompletionClassic = ResolveColumnContents(columnCount, DungeonColumn.CompletionClassic, row);
            importedRow.FirstTimeClassic = ResolveColumnContents(columnCount, DungeonColumn.FirstTimeClassic, row);
            importedRow.MasteryClassic = ResolveColumnContents(columnCount, DungeonColumn.MasteryClassic, row);
            importedRow.StaminaElite = ResolveColumnContents(columnCount, DungeonColumn.StaminaElite, row);
            importedRow.DifficultyElite = ResolveColumnContents(columnCount, DungeonColumn.DifficultyElite, row);
            importedRow.CompletionElite = ResolveColumnContents(columnCount, DungeonColumn.CompletionElite, row);
            importedRow.FirstTimeElite = ResolveColumnContents(columnCount, DungeonColumn.FirstTimeElite, row);
            importedRow.MasteryElite = ResolveColumnContents(columnCount, DungeonColumn.MasteryElite, row);
            importedRow.Update = ResolveColumnContents(columnCount, DungeonColumn.Update, row);

            return importedRow;
        }
    }
}
