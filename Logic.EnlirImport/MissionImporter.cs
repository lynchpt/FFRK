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
    public class MissionImporter : RowImporterBase<MissionRow>
    {
        public MissionImporter(ISheetsApiHelper sheetsApiHelper, IOptions<MissionImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<MissionRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override MissionRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            MissionRow importedRow = new MissionRow();

            importedRow.Type = ResolveColumnContents(columnCount, MissionColumn.Type, row);
            importedRow.Event = ResolveColumnContents(columnCount, MissionColumn.Event, row);
            importedRow.Description = ResolveColumnContents(columnCount, MissionColumn.Description, row);
            importedRow.Reward = ResolveColumnContents(columnCount, MissionColumn.Reward, row);


            return importedRow;
        }
    }
}
