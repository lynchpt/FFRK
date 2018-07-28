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
    public class SoulBreakImporter : RowImporterBase<SoulBreakRow>
    {
        public SoulBreakImporter(ISheetsApiHelper sheetsApiHelper, IOptions<SoulBreakImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<SoulBreakRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override SoulBreakRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            SoulBreakRow importedRow = new SoulBreakRow();

            importedRow.Realm = ResolveColumnContents(columnCount, SoulBreakColumn.Realm, row);
            importedRow.Character = ResolveColumnContents(columnCount, SoulBreakColumn.Character, row);
            importedRow.ImagePath = ResolveColumnContents(columnCount, SoulBreakColumn.ImagePath, row);
            importedRow.SoulBreakName = ResolveColumnContents(columnCount, SoulBreakColumn.SoulBreakName, row);
            importedRow.Type = ResolveColumnContents(columnCount, SoulBreakColumn.Type, row);
            importedRow.Target = ResolveColumnContents(columnCount, SoulBreakColumn.Target, row);
            importedRow.Formula = ResolveColumnContents(columnCount, SoulBreakColumn.Formula, row);
            importedRow.Multiplier = ResolveColumnContents(columnCount, SoulBreakColumn.Multiplier, row);
            importedRow.Element = ResolveColumnContents(columnCount, SoulBreakColumn.Element, row);
            importedRow.Time = ResolveColumnContents(columnCount, SoulBreakColumn.Time, row);
            importedRow.Effects = ResolveColumnContents(columnCount, SoulBreakColumn.Effects, row);
            importedRow.Counter = ResolveColumnContents(columnCount, SoulBreakColumn.Counter, row);
            importedRow.AutoTarget = ResolveColumnContents(columnCount, SoulBreakColumn.AutoTarget, row);
            importedRow.Points = ResolveColumnContents(columnCount, SoulBreakColumn.Points, row);
            importedRow.Tier = ResolveColumnContents(columnCount, SoulBreakColumn.Tier, row);
            importedRow.Master = ResolveColumnContents(columnCount, SoulBreakColumn.Master, row);
            importedRow.Relic = ResolveColumnContents(columnCount, SoulBreakColumn.Relic, row);
            importedRow.JapaneseName = ResolveColumnContents(columnCount, SoulBreakColumn.JapaneseName, row);
            importedRow.ID = ResolveColumnContents(columnCount, SoulBreakColumn.ID, row);
            importedRow.IsInGlobal = ResolveColumnContents(columnCount, SoulBreakColumn.IsInGlobal, row);
            importedRow.Checked = ResolveColumnContents(columnCount, SoulBreakColumn.Checked, row);


            return importedRow;
        }
    }
}
