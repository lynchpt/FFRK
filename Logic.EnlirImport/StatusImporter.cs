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
    public class StatusImporter : RowImporterBase<StatusRow>
    {
        public StatusImporter(ISheetsApiHelper sheetsApiHelper, IOptions<StatusImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<StatusRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override StatusRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            StatusRow importedRow = new StatusRow();

            importedRow.ID = ResolveColumnContents(columnCount, StatusColumn.ID, row);
            importedRow.CommonName = ResolveColumnContents(columnCount, StatusColumn.CommonName, row);
            importedRow.Effects = ResolveColumnContents(columnCount, StatusColumn.Effects, row);
            importedRow.DefaultDuration = ResolveColumnContents(columnCount, StatusColumn.DefaultDuration, row);
            importedRow.MindModifier = ResolveColumnContents(columnCount, StatusColumn.MindModifier, row);
            importedRow.ExclusiveStatus = ResolveColumnContents(columnCount, StatusColumn.ExclusiveStatus, row);
            importedRow.CodedName = ResolveColumnContents(columnCount, StatusColumn.CodedName, row);
            importedRow.Notes = ResolveColumnContents(columnCount, StatusColumn.Notes, row);

            return importedRow;
        }
    }
}
