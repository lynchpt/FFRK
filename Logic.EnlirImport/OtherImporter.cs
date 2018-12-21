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
    public class OtherImporter : RowImporterBase<OtherRow>
    {
        public OtherImporter(ISheetsApiHelper sheetsApiHelper, IOptions<OtherImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<OtherRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override OtherRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            OtherRow importedRow = new OtherRow();

            importedRow.Character = ResolveColumnContents(columnCount, OtherColumn.Character, row);
            importedRow.Source = ResolveColumnContents(columnCount, OtherColumn.Source, row);
            importedRow.ImagePath = ResolveColumnContents(columnCount, OtherColumn.ImagePath, row);
            importedRow.OtherName = ResolveColumnContents(columnCount, OtherColumn.OtherName, row);
            importedRow.Type = ResolveColumnContents(columnCount, OtherColumn.Type, row);
            importedRow.Target = ResolveColumnContents(columnCount, OtherColumn.Target, row);
            importedRow.Formula = ResolveColumnContents(columnCount, OtherColumn.Formula, row);
            importedRow.Multiplier = ResolveColumnContents(columnCount, OtherColumn.Multiplier, row);
            importedRow.Element = ResolveColumnContents(columnCount, OtherColumn.Element, row);
            importedRow.Time = ResolveColumnContents(columnCount, OtherColumn.Time, row);
            importedRow.Effects = ResolveColumnContents(columnCount, OtherColumn.Effects, row);
            importedRow.Counter = ResolveColumnContents(columnCount, OtherColumn.Counter, row);
            importedRow.AutoTarget = ResolveColumnContents(columnCount, OtherColumn.AutoTarget, row);
            importedRow.SB = ResolveColumnContents(columnCount, OtherColumn.SB, row);
            importedRow.School = ResolveColumnContents(columnCount, OtherColumn.School, row);
            importedRow.ID = ResolveColumnContents(columnCount, OtherColumn.ID, row);
            importedRow.IsInGlobal = ResolveColumnContents(columnCount, OtherColumn.IsInGlobal, row);
            importedRow.Checked = ResolveColumnContents(columnCount, OtherColumn.Checked, row);

            return importedRow;
        }
    }
}
