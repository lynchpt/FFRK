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
    public class CommandImporter : RowImporterBase<CommandRow>
    {
        public CommandImporter(ISheetsApiHelper sheetsApiHelper, IOptions<CommandImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<CommandRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override CommandRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            CommandRow importedRow = new CommandRow();

            importedRow.Character = ResolveColumnContents(columnCount, CommandColumn.Character, row);
            importedRow.Source = ResolveColumnContents(columnCount, CommandColumn.Source, row);
            importedRow.ImagePath = ResolveColumnContents(columnCount, CommandColumn.ImagePath, row);
            importedRow.CommandName = ResolveColumnContents(columnCount, CommandColumn.CommandName, row);
            importedRow.Type = ResolveColumnContents(columnCount, CommandColumn.Type, row);
            importedRow.Target = ResolveColumnContents(columnCount, CommandColumn.Target, row);
            importedRow.Formula = ResolveColumnContents(columnCount, CommandColumn.Formula, row);
            importedRow.Multiplier = ResolveColumnContents(columnCount, CommandColumn.Multiplier, row);
            importedRow.Element = ResolveColumnContents(columnCount, CommandColumn.Element, row);
            importedRow.Time = ResolveColumnContents(columnCount, CommandColumn.Time, row);
            importedRow.Effects = ResolveColumnContents(columnCount, CommandColumn.Effects, row);
            importedRow.Counter = ResolveColumnContents(columnCount, CommandColumn.Counter, row);
            importedRow.AutoTarget = ResolveColumnContents(columnCount, CommandColumn.AutoTarget, row);
            importedRow.SB = ResolveColumnContents(columnCount, CommandColumn.SB, row);
            importedRow.School = ResolveColumnContents(columnCount, CommandColumn.School, row);
            importedRow.JapaneseName = ResolveColumnContents(columnCount, CommandColumn.JapaneseName, row);
            importedRow.ID = ResolveColumnContents(columnCount, CommandColumn.ID, row);
            importedRow.IsInGlobal = ResolveColumnContents(columnCount, CommandColumn.IsInGlobal, row);
            importedRow.Checked = ResolveColumnContents(columnCount, CommandColumn.Checked, row);

            return importedRow;
        }
    }
}
