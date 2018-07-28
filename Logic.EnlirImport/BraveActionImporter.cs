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
    public class BraveActionImporter : RowImporterBase<BraveActionRow>
    {
        public BraveActionImporter(ISheetsApiHelper sheetsApiHelper, IOptions<BraveActionImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<BraveActionRow>> logger)
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override BraveActionRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            BraveActionRow importedRow = new BraveActionRow();

            importedRow.Character = ResolveColumnContents(columnCount, BraveActionColumn.Character, row);
            importedRow.Source = ResolveColumnContents(columnCount, BraveActionColumn.Source, row);
            importedRow.ImagePath = ResolveColumnContents(columnCount, BraveActionColumn.ImagePath, row);
            importedRow.BraveName = ResolveColumnContents(columnCount, BraveActionColumn.BraveName, row);
            importedRow.BraveLevel = ResolveColumnContents(columnCount, BraveActionColumn.BraveLevel, row);
            importedRow.Type = ResolveColumnContents(columnCount, BraveActionColumn.Type, row);
            importedRow.Target = ResolveColumnContents(columnCount, BraveActionColumn.Target, row);
            importedRow.Formula = ResolveColumnContents(columnCount, BraveActionColumn.Formula, row);
            importedRow.Multiplier = ResolveColumnContents(columnCount, BraveActionColumn.Multiplier, row);
            importedRow.Element = ResolveColumnContents(columnCount, BraveActionColumn.Element, row);
            importedRow.Time = ResolveColumnContents(columnCount, BraveActionColumn.Time, row);
            importedRow.Effects = ResolveColumnContents(columnCount, BraveActionColumn.Effects, row);
            importedRow.Counter = ResolveColumnContents(columnCount, BraveActionColumn.Counter, row);
            importedRow.AutoTarget = ResolveColumnContents(columnCount, BraveActionColumn.AutoTarget, row);
            importedRow.SB = ResolveColumnContents(columnCount, BraveActionColumn.SB, row);
            importedRow.School = ResolveColumnContents(columnCount, BraveActionColumn.School, row);
            importedRow.BraveCondition = ResolveColumnContents(columnCount, BraveActionColumn.BraveCondition, row);
            importedRow.JapaneseName = ResolveColumnContents(columnCount, BraveActionColumn.JapaneseName, row);
            importedRow.IsInGlobal = ResolveColumnContents(columnCount, BraveActionColumn.IsInGlobal, row);
            importedRow.Checked = ResolveColumnContents(columnCount, BraveActionColumn.Checked, row);

            return importedRow;
        }
    }
}
