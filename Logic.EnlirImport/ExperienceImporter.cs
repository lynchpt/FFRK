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
    public class ExperienceImporter : RowImporterBase<ExperienceRow>
    {
        public ExperienceImporter(ISheetsApiHelper sheetsApiHelper, IOptions<ExperienceImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<ExperienceRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override ExperienceRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            ExperienceRow importedRow = new ExperienceRow();

            importedRow.Level = ResolveColumnContents(columnCount, ExperienceColumn.Level, row);
            importedRow.Character = ResolveColumnContents(columnCount, ExperienceColumn.Character, row);
            importedRow.NextLevelCharacter = ResolveColumnContents(columnCount, ExperienceColumn.NextLevelCharacter, row);
            importedRow.Tyro = ResolveColumnContents(columnCount, ExperienceColumn.Tyro, row);
            importedRow.NextLevelTyro = ResolveColumnContents(columnCount, ExperienceColumn.NextLevelTyro, row);
            importedRow.Magicite1 = ResolveColumnContents(columnCount, ExperienceColumn.Magicite1, row);
            importedRow.NextLevelMagicite1 = ResolveColumnContents(columnCount, ExperienceColumn.NextLevelMagicite1, row);
            importedRow.Magicite2 = ResolveColumnContents(columnCount, ExperienceColumn.Magicite2, row);
            importedRow.NextLevelMagicite2 = ResolveColumnContents(columnCount, ExperienceColumn.NextLevelMagicite2, row);
            importedRow.Magicite3 = ResolveColumnContents(columnCount, ExperienceColumn.Magicite3, row);
            importedRow.NextLevelMagicite3 = ResolveColumnContents(columnCount, ExperienceColumn.NextLevelMagicite3, row);
            importedRow.Magicite4 = ResolveColumnContents(columnCount, ExperienceColumn.Magicite4, row);
            importedRow.NextLevelMagicite4 = ResolveColumnContents(columnCount, ExperienceColumn.NextLevelMagicite4, row);
            importedRow.Magicite5 = ResolveColumnContents(columnCount, ExperienceColumn.Magicite5, row);
            importedRow.NextLevelMagicite5 = ResolveColumnContents(columnCount, ExperienceColumn.NextLevelMagicite5, row);
            importedRow.Inheritance3 = ResolveColumnContents(columnCount, ExperienceColumn.Inheritance3, row);
            importedRow.NextLevelInheritance3 = ResolveColumnContents(columnCount, ExperienceColumn.NextLevelInheritance3, row);
            importedRow.Inheritance4 = ResolveColumnContents(columnCount, ExperienceColumn.Inheritance4, row);
            importedRow.NextLevelInheritance4 = ResolveColumnContents(columnCount, ExperienceColumn.NextLevelInheritance4, row);
            importedRow.Inheritance5 = ResolveColumnContents(columnCount, ExperienceColumn.Inheritance5, row);
            importedRow.NextLevelInheritance5 = ResolveColumnContents(columnCount, ExperienceColumn.NextLevelInheritance5, row);

            return importedRow;
        }
    }
}
