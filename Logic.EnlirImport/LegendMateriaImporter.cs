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
    public class LegendMateriaImporter : RowImporterBase<LegendMateriaRow>
    {
        public LegendMateriaImporter(ISheetsApiHelper sheetsApiHelper, IOptions<LegendMateriaImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<LegendMateriaRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override LegendMateriaRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            LegendMateriaRow importedRow = new LegendMateriaRow();

            importedRow.Realm = ResolveColumnContents(columnCount, LegendMateriaColumn.Realm, row);
            importedRow.Character = ResolveColumnContents(columnCount, LegendMateriaColumn.Character, row);
            importedRow.ImagePath = ResolveColumnContents(columnCount, LegendMateriaColumn.ImagePath, row);
            importedRow.LegendMateriaName = ResolveColumnContents(columnCount, LegendMateriaColumn.LegendMateriaName, row);
            importedRow.Effect = ResolveColumnContents(columnCount, LegendMateriaColumn.Effect, row);
            importedRow.Master = ResolveColumnContents(columnCount, LegendMateriaColumn.Master, row);
            importedRow.Relic = ResolveColumnContents(columnCount, LegendMateriaColumn.Relic, row);
            importedRow.JapaneseName = ResolveColumnContents(columnCount, LegendMateriaColumn.JapaneseName, row);
            importedRow.ID = ResolveColumnContents(columnCount, LegendMateriaColumn.ID, row);
            importedRow.IsInGlobal = ResolveColumnContents(columnCount, LegendMateriaColumn.IsInGlobal, row);
            importedRow.Checked = ResolveColumnContents(columnCount, LegendMateriaColumn.Checked, row);

            return importedRow;
        }
    }
}
