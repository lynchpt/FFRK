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
    public class AbilityImporter : RowImporterBase<AbilityRow>
    {
        public AbilityImporter(ISheetsApiHelper sheetsApiHelper, IOptions<AbilityImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<AbilityRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override AbilityRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            AbilityRow importedRow = new AbilityRow();

            importedRow.School = ResolveColumnContents(columnCount, AbilityColumn.School, row);
            importedRow.ImagePath = ResolveColumnContents(columnCount, AbilityColumn.ImagePath, row);
            importedRow.AbilityName = ResolveColumnContents(columnCount, AbilityColumn.AbilityName, row);
            importedRow.Rarity = ResolveColumnContents(columnCount, AbilityColumn.Rarity, row);
            importedRow.Type = ResolveColumnContents(columnCount, AbilityColumn.Type, row);
            importedRow.Target = ResolveColumnContents(columnCount, AbilityColumn.Target, row);
            importedRow.Formula = ResolveColumnContents(columnCount, AbilityColumn.Formula, row);
            importedRow.Multiplier = ResolveColumnContents(columnCount, AbilityColumn.Multiplier, row);
            importedRow.Element = ResolveColumnContents(columnCount, AbilityColumn.Element, row);
            importedRow.Time = ResolveColumnContents(columnCount, AbilityColumn.Time, row);
            importedRow.Effects = ResolveColumnContents(columnCount, AbilityColumn.Effects, row);
            importedRow.Counter = ResolveColumnContents(columnCount, AbilityColumn.Counter, row);
            importedRow.AutoTarget = ResolveColumnContents(columnCount, AbilityColumn.AutoTarget, row);
            importedRow.SB = ResolveColumnContents(columnCount, AbilityColumn.SB, row);
            importedRow.Uses = ResolveColumnContents(columnCount, AbilityColumn.Uses, row);
            importedRow.Max = ResolveColumnContents(columnCount, AbilityColumn.Max, row);
            importedRow.Orb1RequiredType = ResolveColumnContents(columnCount, AbilityColumn.Orb1RequiredType, row);
            importedRow.Orb1RequiredRank1 = ResolveColumnContents(columnCount, AbilityColumn.Orb1RequiredRank1, row);
            importedRow.Orb1RequiredRank2 = ResolveColumnContents(columnCount, AbilityColumn.Orb1RequiredRank2, row);
            importedRow.Orb1RequiredRank3 = ResolveColumnContents(columnCount, AbilityColumn.Orb1RequiredRank3, row);
            importedRow.Orb1RequiredRank4 = ResolveColumnContents(columnCount, AbilityColumn.Orb1RequiredRank4, row);
            importedRow.Orb1RequiredRank5 = ResolveColumnContents(columnCount, AbilityColumn.Orb1RequiredRank5, row);
            importedRow.Orb2RequiredType = ResolveColumnContents(columnCount, AbilityColumn.Orb2RequiredType, row);
            importedRow.Orb2RequiredRank1 = ResolveColumnContents(columnCount, AbilityColumn.Orb2RequiredRank1, row);
            importedRow.Orb2RequiredRank2 = ResolveColumnContents(columnCount, AbilityColumn.Orb2RequiredRank2, row);
            importedRow.Orb2RequiredRank3 = ResolveColumnContents(columnCount, AbilityColumn.Orb2RequiredRank3, row);
            importedRow.Orb2RequiredRank4 = ResolveColumnContents(columnCount, AbilityColumn.Orb2RequiredRank4, row);
            importedRow.Orb2RequiredRank5 = ResolveColumnContents(columnCount, AbilityColumn.Orb2RequiredRank5, row);
            importedRow.Orb3RequiredType = ResolveColumnContents(columnCount, AbilityColumn.Orb3RequiredType, row);
            importedRow.Orb3RequiredRank1 = ResolveColumnContents(columnCount, AbilityColumn.Orb3RequiredRank1, row);
            importedRow.Orb3RequiredRank2 = ResolveColumnContents(columnCount, AbilityColumn.Orb3RequiredRank2, row);
            importedRow.Orb3RequiredRank3 = ResolveColumnContents(columnCount, AbilityColumn.Orb3RequiredRank3, row);
            importedRow.Orb3RequiredRank4 = ResolveColumnContents(columnCount, AbilityColumn.Orb3RequiredRank4, row);
            importedRow.Orb3RequiredRank5 = ResolveColumnContents(columnCount, AbilityColumn.Orb3RequiredRank5, row);
            importedRow.Orb4RequiredType = ResolveColumnContents(columnCount, AbilityColumn.Orb4RequiredType, row);
            importedRow.Orb4RequiredRank1 = ResolveColumnContents(columnCount, AbilityColumn.Orb4RequiredRank1, row);
            importedRow.Orb4RequiredRank2 = ResolveColumnContents(columnCount, AbilityColumn.Orb4RequiredRank2, row);
            importedRow.Orb4RequiredRank3 = ResolveColumnContents(columnCount, AbilityColumn.Orb4RequiredRank3, row);
            importedRow.Orb4RequiredRank4 = ResolveColumnContents(columnCount, AbilityColumn.Orb4RequiredRank4, row);
            importedRow.Orb4RequiredRank5 = ResolveColumnContents(columnCount, AbilityColumn.Orb4RequiredRank5, row);
            importedRow.IntroducingEvent = ResolveColumnContents(columnCount, AbilityColumn.IntroducingEvent, row);
            importedRow.JapaneseName = ResolveColumnContents(columnCount, AbilityColumn.JapaneseName, row);
            importedRow.ID = ResolveColumnContents(columnCount, AbilityColumn.ID, row);
            importedRow.IsInGlobal = ResolveColumnContents(columnCount, AbilityColumn.IsInGlobal, row);
            importedRow.Checked = ResolveColumnContents(columnCount, AbilityColumn.Checked, row);

            return importedRow;
        }
    }
}
