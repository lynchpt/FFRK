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
    public class MagiciteImporter : RowImporterBase<MagiciteRow>
    {
        public MagiciteImporter(ISheetsApiHelper sheetsApiHelper, IOptions<MagiciteImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<MagiciteRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override MagiciteRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            MagiciteRow importedRow = new MagiciteRow();

            //Magicite Stats
            importedRow.Element = ResolveColumnContents(columnCount, MagiciteColumn.Element, row);
            importedRow.ImagePath = ResolveColumnContents(columnCount, MagiciteColumn.ImagePath, row);
            importedRow.Name = ResolveColumnContents(columnCount, MagiciteColumn.Name, row);
            importedRow.Realm = ResolveColumnContents(columnCount, MagiciteColumn.Realm, row);
            importedRow.Rarity = ResolveColumnContents(columnCount, MagiciteColumn.Rarity, row);
            importedRow.IntroducingEvent = ResolveColumnContents(columnCount, MagiciteColumn.IntroducingEvent, row);
            importedRow.HP = ResolveColumnContents(columnCount, MagiciteColumn.HP, row);
            importedRow.ATK = ResolveColumnContents(columnCount, MagiciteColumn.ATK, row);
            importedRow.DEF = ResolveColumnContents(columnCount, MagiciteColumn.DEF, row);
            importedRow.MAG = ResolveColumnContents(columnCount, MagiciteColumn.MAG, row);
            importedRow.RES = ResolveColumnContents(columnCount, MagiciteColumn.RES, row);
            importedRow.MND = ResolveColumnContents(columnCount, MagiciteColumn.MND, row);
            importedRow.SPD = ResolveColumnContents(columnCount, MagiciteColumn.SPD, row);

            //Passive 1
            importedRow.Passive1Name = ResolveColumnContents(columnCount, MagiciteColumn.Passive1Name, row);
            importedRow.Passive1StrengthLevel1 = ResolveColumnContents(columnCount, MagiciteColumn.Passive1StrengthLevel1, row);
            importedRow.Passive1StrengthLevel10 = ResolveColumnContents(columnCount, MagiciteColumn.Passive1StrengthLevel10, row);
            importedRow.Passive1StrengthLevel25 = ResolveColumnContents(columnCount, MagiciteColumn.Passive1StrengthLevel25, row);
            importedRow.Passive1StrengthLevel50 = ResolveColumnContents(columnCount, MagiciteColumn.Passive1StrengthLevel50, row);
            importedRow.Passive1StrengthLevel65 = ResolveColumnContents(columnCount, MagiciteColumn.Passive1StrengthLevel65, row);
            importedRow.Passive1StrengthLevel80 = ResolveColumnContents(columnCount, MagiciteColumn.Passive1StrengthLevel80, row);
            importedRow.Passive1StrengthLevel81 = ResolveColumnContents(columnCount, MagiciteColumn.Passive1StrengthLevel81, row);
            importedRow.Passive1StrengthLevel90 = ResolveColumnContents(columnCount, MagiciteColumn.Passive1StrengthLevel90, row);
            importedRow.Passive1StrengthLevel99 = ResolveColumnContents(columnCount, MagiciteColumn.Passive1StrengthLevel99, row);

            //Passive 2
            importedRow.Passive2Name = ResolveColumnContents(columnCount, MagiciteColumn.Passive2Name, row);
            importedRow.Passive2StrengthLevel1 = ResolveColumnContents(columnCount, MagiciteColumn.Passive2StrengthLevel1, row);
            importedRow.Passive2StrengthLevel10 = ResolveColumnContents(columnCount, MagiciteColumn.Passive2StrengthLevel10, row);
            importedRow.Passive2StrengthLevel25 = ResolveColumnContents(columnCount, MagiciteColumn.Passive2StrengthLevel25, row);
            importedRow.Passive2StrengthLevel50 = ResolveColumnContents(columnCount, MagiciteColumn.Passive2StrengthLevel50, row);
            importedRow.Passive2StrengthLevel65 = ResolveColumnContents(columnCount, MagiciteColumn.Passive2StrengthLevel65, row);
            importedRow.Passive2StrengthLevel80 = ResolveColumnContents(columnCount, MagiciteColumn.Passive2StrengthLevel80, row);
            importedRow.Passive2StrengthLevel81 = ResolveColumnContents(columnCount, MagiciteColumn.Passive2StrengthLevel81, row);
            importedRow.Passive2StrengthLevel90 = ResolveColumnContents(columnCount, MagiciteColumn.Passive2StrengthLevel90, row);
            importedRow.Passive2StrengthLevel99 = ResolveColumnContents(columnCount, MagiciteColumn.Passive2StrengthLevel99, row);

            //Passive 3
            importedRow.Passive3Name = ResolveColumnContents(columnCount, MagiciteColumn.Passive3Name, row);
            importedRow.Passive3StrengthLevel1 = ResolveColumnContents(columnCount, MagiciteColumn.Passive3StrengthLevel1, row);
            importedRow.Passive3StrengthLevel10 = ResolveColumnContents(columnCount, MagiciteColumn.Passive3StrengthLevel10, row);
            importedRow.Passive3StrengthLevel25 = ResolveColumnContents(columnCount, MagiciteColumn.Passive3StrengthLevel25, row);
            importedRow.Passive3StrengthLevel50 = ResolveColumnContents(columnCount, MagiciteColumn.Passive3StrengthLevel50, row);
            importedRow.Passive3StrengthLevel65 = ResolveColumnContents(columnCount, MagiciteColumn.Passive3StrengthLevel65, row);
            importedRow.Passive3StrengthLevel80 = ResolveColumnContents(columnCount, MagiciteColumn.Passive3StrengthLevel80, row);
            importedRow.Passive3StrengthLevel81 = ResolveColumnContents(columnCount, MagiciteColumn.Passive3StrengthLevel81, row);
            importedRow.Passive3StrengthLevel90 = ResolveColumnContents(columnCount, MagiciteColumn.Passive3StrengthLevel90, row);
            importedRow.Passive3StrengthLevel99 = ResolveColumnContents(columnCount, MagiciteColumn.Passive3StrengthLevel99, row);

            //Ultra Skill
            importedRow.Cooldown = ResolveColumnContents(columnCount, MagiciteColumn.Cooldown, row);
            importedRow.Duration = ResolveColumnContents(columnCount, MagiciteColumn.Duration, row);
            importedRow.UltraSkill = ResolveColumnContents(columnCount, MagiciteColumn.UltraSkill, row);
            importedRow.Type = ResolveColumnContents(columnCount, MagiciteColumn.Type, row);
            importedRow.AutoTarget = ResolveColumnContents(columnCount, MagiciteColumn.AutoTarget, row);
            importedRow.Formula = ResolveColumnContents(columnCount, MagiciteColumn.Formula, row);
            importedRow.Multiplier = ResolveColumnContents(columnCount, MagiciteColumn.Multiplier, row);
            importedRow.UltraSkillElement = ResolveColumnContents(columnCount, MagiciteColumn.UltraSkillElement, row);
            importedRow.Time = ResolveColumnContents(columnCount, MagiciteColumn.Time, row);
            importedRow.Effects = ResolveColumnContents(columnCount, MagiciteColumn.Effects, row);
            importedRow.Counter = ResolveColumnContents(columnCount, MagiciteColumn.Counter, row);
            importedRow.JapaneseName = ResolveColumnContents(columnCount, MagiciteColumn.JapaneseName, row);
            importedRow.ID = ResolveColumnContents(columnCount, MagiciteColumn.ID, row);
            importedRow.IsInGlobal = ResolveColumnContents(columnCount, MagiciteColumn.IsInGlobal, row);
            importedRow.Checked = ResolveColumnContents(columnCount, MagiciteColumn.Checked, row);

            return importedRow;
        }
    }
}
