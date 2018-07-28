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
    public class MagiciteSkillImporter : RowImporterBase<MagiciteSkillRow>
    {
        public MagiciteSkillImporter(ISheetsApiHelper sheetsApiHelper, IOptions<MagiciteSkillImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<MagiciteSkillRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override MagiciteSkillRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            MagiciteSkillRow importedRow = new MagiciteSkillRow();

            importedRow.Magicite = ResolveColumnContents(columnCount, MagiciteSkillColumn.Magicite, row);
            importedRow.ImagePath = ResolveColumnContents(columnCount, MagiciteSkillColumn.ImagePath, row);
            importedRow.Name = ResolveColumnContents(columnCount, MagiciteSkillColumn.Name, row);
            importedRow.ChanceToUseTier0 = ResolveColumnContents(columnCount, MagiciteSkillColumn.ChanceToUseTier0, row);
            importedRow.ChanceToUseTier1 = ResolveColumnContents(columnCount, MagiciteSkillColumn.ChanceToUseTier1, row);
            importedRow.ChanceToUseTier2 = ResolveColumnContents(columnCount, MagiciteSkillColumn.ChanceToUseTier2, row);
            importedRow.ChanceToUseTier3 = ResolveColumnContents(columnCount, MagiciteSkillColumn.ChanceToUseTier3, row);
            importedRow.Type = ResolveColumnContents(columnCount, MagiciteSkillColumn.Type, row);
            importedRow.AutoTarget = ResolveColumnContents(columnCount, MagiciteSkillColumn.AutoTarget, row);
            importedRow.Formula = ResolveColumnContents(columnCount, MagiciteSkillColumn.Formula, row);
            importedRow.Multiplier = ResolveColumnContents(columnCount, MagiciteSkillColumn.Multiplier, row);
            importedRow.Element = ResolveColumnContents(columnCount, MagiciteSkillColumn.Element, row);
            importedRow.Time = ResolveColumnContents(columnCount, MagiciteSkillColumn.Time, row);
            importedRow.Effects = ResolveColumnContents(columnCount, MagiciteSkillColumn.Effects, row);
            importedRow.Counter = ResolveColumnContents(columnCount, MagiciteSkillColumn.Counter, row);
            importedRow.JapaneseName = ResolveColumnContents(columnCount, MagiciteSkillColumn.JapaneseName, row);
            importedRow.IsInGlobal = ResolveColumnContents(columnCount, MagiciteSkillColumn.IsInGlobal, row);
            importedRow.Checked = ResolveColumnContents(columnCount, MagiciteSkillColumn.Checked, row);

            return importedRow;
        }
    }
}
