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
using Model.EnlirImport;

namespace FFRKApi.Logic.EnlirImport
{
    public class RecordSphereImporter : RowImporterBase<RecordSphereRow>
    {
        public RecordSphereImporter(ISheetsApiHelper sheetsApiHelper, IOptions<RecordSphereImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<RecordSphereRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override RecordSphereRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            RecordSphereRow importedRow = new RecordSphereRow();

            //General
            importedRow.Realm = ResolveColumnContents(columnCount, RecordSphereColumn.Realm, row);
            importedRow.Character = ResolveColumnContents(columnCount, RecordSphereColumn.Character, row);
            importedRow.RecordSphereName = ResolveColumnContents(columnCount, RecordSphereColumn.RecordSphereName, row);

            //Sphere Benefits
            importedRow.BenefitLevel1 = ResolveColumnContents(columnCount, RecordSphereColumn.BenefitLevel1, row);
            importedRow.BenefitLevel2 = ResolveColumnContents(columnCount, RecordSphereColumn.BenefitLevel2, row);
            importedRow.BenefitLevel3 = ResolveColumnContents(columnCount, RecordSphereColumn.BenefitLevel3, row);
            importedRow.BenefitLevel4 = ResolveColumnContents(columnCount, RecordSphereColumn.BenefitLevel4, row);
            importedRow.BenefitLevel5 = ResolveColumnContents(columnCount, RecordSphereColumn.BenefitLevel5, row);

            //Prerequisites
            importedRow.RecordSpherePrerequisites = ResolveColumnContents(columnCount, RecordSphereColumn.RecordSpherePrerequisites, row);

            //Motes Required
            importedRow.Mote1Type = ResolveColumnContents(columnCount, RecordSphereColumn.Mote1Type, row);
            importedRow.Mote1AmountLevel1 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote1AmountLevel1, row);
            importedRow.Mote1AmountLevel2 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote1AmountLevel2, row);
            importedRow.Mote1AmountLevel3 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote1AmountLevel3, row);
            importedRow.Mote1AmountLevel4 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote1AmountLevel4, row);
            importedRow.Mote1AmountLevel5 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote1AmountLevel5, row);

            importedRow.Mote2Type = ResolveColumnContents(columnCount, RecordSphereColumn.Mote2Type, row);
            importedRow.Mote2AmountLevel1 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote2AmountLevel1, row);
            importedRow.Mote2AmountLevel2 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote2AmountLevel2, row);
            importedRow.Mote2AmountLevel3 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote2AmountLevel3, row);
            importedRow.Mote2AmountLevel4 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote2AmountLevel4, row);
            importedRow.Mote2AmountLevel5 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote2AmountLevel5, row);

            importedRow.Mote3Type = ResolveColumnContents(columnCount, RecordSphereColumn.Mote3Type, row);
            importedRow.Mote3AmountLevel1 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote3AmountLevel1, row);
            importedRow.Mote3AmountLevel2 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote3AmountLevel2, row);
            importedRow.Mote3AmountLevel3 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote3AmountLevel3, row);
            importedRow.Mote3AmountLevel4 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote3AmountLevel4, row);
            importedRow.Mote3AmountLevel5 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote3AmountLevel5, row);

            importedRow.Mote4Type = ResolveColumnContents(columnCount, RecordSphereColumn.Mote4Type, row);
            importedRow.Mote4AmountLevel1 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote4AmountLevel1, row);
            importedRow.Mote4AmountLevel2 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote4AmountLevel2, row);
            importedRow.Mote4AmountLevel3 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote4AmountLevel3, row);
            importedRow.Mote4AmountLevel4 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote4AmountLevel4, row);
            importedRow.Mote4AmountLevel5 = ResolveColumnContents(columnCount, RecordSphereColumn.Mote4AmountLevel5, row);

            return importedRow;
        }
    }
}
