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
    public class RecordMateriaImporter : RowImporterBase<RecordMateriaRow>
    {
        public RecordMateriaImporter(ISheetsApiHelper sheetsApiHelper, IOptions<RecordMateriaImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<RecordMateriaRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override RecordMateriaRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            RecordMateriaRow importedRow = new RecordMateriaRow();

            importedRow.Realm = ResolveColumnContents(columnCount, RecordMateriaColumn.Realm, row);
            importedRow.Character = ResolveColumnContents(columnCount, RecordMateriaColumn.Character, row);
            importedRow.ImagePath = ResolveColumnContents(columnCount, RecordMateriaColumn.ImagePath, row);
            importedRow.RecordMateriaName = ResolveColumnContents(columnCount, RecordMateriaColumn.RecordMateriaName, row);
            importedRow.Effect = ResolveColumnContents(columnCount, RecordMateriaColumn.Effect, row);
            importedRow.UnlockCriteria = ResolveColumnContents(columnCount, RecordMateriaColumn.UnlockCriteria, row);
            importedRow.JapaneseName = ResolveColumnContents(columnCount, RecordMateriaColumn.JapaneseName, row);
            importedRow.ID = ResolveColumnContents(columnCount, RecordMateriaColumn.ID, row);
            importedRow.IsInGlobal = ResolveColumnContents(columnCount, RecordMateriaColumn.IsInGlobal, row);
            importedRow.Checked = ResolveColumnContents(columnCount, RecordMateriaColumn.Checked, row);

            return importedRow;
        }
    }
}
