using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Model.EnlirImport;
using FFRKApi.SheetsApiHelper;
using Google.Apis.Sheets.v4.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FFRKApi.Logic.EnlirImport
{
    public class LegendSphereImporter : RowImporterBase<LegendSphereRow>
    {
        public LegendSphereImporter(ISheetsApiHelper sheetsApiHelper, IOptions<LegendSphereImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<LegendSphereRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override LegendSphereRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            LegendSphereRow importedRow = new LegendSphereRow();

            //General
            importedRow.Realm = ResolveColumnContents(columnCount, LegendSphereColumn.Realm, row);
            importedRow.Character = ResolveColumnContents(columnCount, LegendSphereColumn.Character, row);

            //Sphere Benefits
            importedRow.BenefitColumn1 = ResolveColumnContents(columnCount, LegendSphereColumn.BenefitColumn1, row);
            importedRow.BenefitColumn2 = ResolveColumnContents(columnCount, LegendSphereColumn.BenefitColumn2, row);
            importedRow.BenefitColumn3 = ResolveColumnContents(columnCount, LegendSphereColumn.BenefitColumn3, row);
            importedRow.BenefitColumn4 = ResolveColumnContents(columnCount, LegendSphereColumn.BenefitColumn4, row);

            //Mote 1
            importedRow.Mote1Type = ResolveColumnContents(columnCount, LegendSphereColumn.Mote1Type, row);
            importedRow.Mote1AmountColumn1 = ResolveColumnContents(columnCount, LegendSphereColumn.Mote1AmountColumn1, row);
            importedRow.Mote1AmountColumn2 = ResolveColumnContents(columnCount, LegendSphereColumn.Mote1AmountColumn2, row);
            importedRow.Mote1AmountColumn3 = ResolveColumnContents(columnCount, LegendSphereColumn.Mote1AmountColumn3, row);
            importedRow.Mote1AmountColumn4 = ResolveColumnContents(columnCount, LegendSphereColumn.Mote1AmountColumn4, row);

            //Mote 2
            importedRow.Mote2Type = ResolveColumnContents(columnCount, LegendSphereColumn.Mote2Type, row);
            importedRow.Mote2AmountColumn1 = ResolveColumnContents(columnCount, LegendSphereColumn.Mote2AmountColumn1, row);
            importedRow.Mote2AmountColumn2 = ResolveColumnContents(columnCount, LegendSphereColumn.Mote2AmountColumn2, row);
            importedRow.Mote2AmountColumn3 = ResolveColumnContents(columnCount, LegendSphereColumn.Mote2AmountColumn3, row);
            importedRow.Mote2AmountColumn4 = ResolveColumnContents(columnCount, LegendSphereColumn.Mote2AmountColumn4, row);

            return importedRow;
        }
    }
}
