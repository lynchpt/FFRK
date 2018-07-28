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
    public class RelicImporter: RowImporterBase<RelicRow>
    {
        public RelicImporter(ISheetsApiHelper sheetsApiHelper, IOptions<RelicImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<RelicRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override RelicRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            RelicRow importedRow = new RelicRow();

            importedRow.RelicName = ResolveColumnContents(columnCount, RelicColumn.RelicName, row);
            importedRow.Realm = ResolveColumnContents(columnCount, RelicColumn.Realm, row);
            importedRow.Type = ResolveColumnContents(columnCount, RelicColumn.Type, row);
            importedRow.Synergy = ResolveColumnContents(columnCount, RelicColumn.Synergy, row);
            importedRow.Combine = ResolveColumnContents(columnCount, RelicColumn.Combine, row);
            importedRow.Rarity = ResolveColumnContents(columnCount, RelicColumn.Rarity, row);
            importedRow.Level = ResolveColumnContents(columnCount, RelicColumn.Level, row);
            importedRow.ATK = ResolveColumnContents(columnCount, RelicColumn.ATK, row);
            importedRow.DEF = ResolveColumnContents(columnCount, RelicColumn.DEF, row);
            importedRow.MAG = ResolveColumnContents(columnCount, RelicColumn.MAG, row);
            importedRow.RES = ResolveColumnContents(columnCount, RelicColumn.RES, row);
            importedRow.MND = ResolveColumnContents(columnCount, RelicColumn.MND, row);
            importedRow.ACC = ResolveColumnContents(columnCount, RelicColumn.ACC, row);
            importedRow.EVA = ResolveColumnContents(columnCount, RelicColumn.EVA, row);
            importedRow.Effect = ResolveColumnContents(columnCount, RelicColumn.Effect, row);
            importedRow.Character = ResolveColumnContents(columnCount, RelicColumn.Character, row);
            importedRow.SoulBreak = ResolveColumnContents(columnCount, RelicColumn.SoulBreak, row);
            importedRow.LegendMateria = ResolveColumnContents(columnCount, RelicColumn.LegendMateria, row);
            importedRow.BRAR = ResolveColumnContents(columnCount, RelicColumn.BRAR, row);
            importedRow.BLV = ResolveColumnContents(columnCount, RelicColumn.BLV, row);
            importedRow.BATK = ResolveColumnContents(columnCount, RelicColumn.BATK, row);
            importedRow.BDEF = ResolveColumnContents(columnCount, RelicColumn.BDEF, row);
            importedRow.BMAG = ResolveColumnContents(columnCount, RelicColumn.BMAG, row);
            importedRow.BRES = ResolveColumnContents(columnCount, RelicColumn.BRES, row);
            importedRow.BMND = ResolveColumnContents(columnCount, RelicColumn.BMND, row);
            importedRow.BACC = ResolveColumnContents(columnCount, RelicColumn.BACC, row);
            importedRow.BEVA = ResolveColumnContents(columnCount, RelicColumn.BEVA, row);
            importedRow.MRAR = ResolveColumnContents(columnCount, RelicColumn.MRAR, row);
            importedRow.MLV = ResolveColumnContents(columnCount, RelicColumn.MLV, row);
            importedRow.MATK = ResolveColumnContents(columnCount, RelicColumn.MATK, row);
            importedRow.MDEF = ResolveColumnContents(columnCount, RelicColumn.MDEF, row);
            importedRow.MMAG = ResolveColumnContents(columnCount, RelicColumn.MMAG, row);
            importedRow.MRES = ResolveColumnContents(columnCount, RelicColumn.MRES, row);
            importedRow.MMND = ResolveColumnContents(columnCount, RelicColumn.MMND, row);
            importedRow.MACC = ResolveColumnContents(columnCount, RelicColumn.MACC, row);
            importedRow.MEVA = ResolveColumnContents(columnCount, RelicColumn.MEVA, row);
            importedRow.ID = ResolveColumnContents(columnCount, RelicColumn.ID, row);
            importedRow.IsInGlobal = ResolveColumnContents(columnCount, RelicColumn.IsInGlobal, row);

            return importedRow;
        }
    }
}
