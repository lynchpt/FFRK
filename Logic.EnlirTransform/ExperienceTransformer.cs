using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using FFRKApi.Model.EnlirTransform.Converters;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.EnlirTransform
{
    public class ExperienceTransformer : RowTransformerBase<ExperienceRow, Experience>
    {
        #region Class Variables
        private readonly IntConverter _intConverter;
        #endregion

        #region Constructors
        public ExperienceTransformer(ILogger<RowTransformerBase<ExperienceRow, Experience>> logger) : base(logger)
        {
            _intConverter = new IntConverter();
        } 
        #endregion

        #region RowTransformerBase Overrides
        //the base class Transform method assumes that for each incoming imported row, there will be one corresponding
        //output transformed row. In the case of experience, all the imported rows as a whole will be pivoted into one
        //output tranformed object. This transformed object will still be out into a collection to keep the signature consistent.
        public override IEnumerable<Experience> Transform(IEnumerable<ExperienceRow> importedRows)
        {
            _logger.LogInformation($"Transform invoked and attempting to transform imported Rows");

            //initialize
            IList<Experience> models = InitializeOutput();
            Experience model = models.First();
       

            //iterate
            foreach (ExperienceRow row in importedRows)
            {
                PivotInputRow(row, model);
            }

            _logger.LogDebug("Converted ExperienceRow to Experience: {Id} - {Description}", model.Id, model.Description);

            return models;
        }

        //Experience is transformed by a pivot operation rather than a row by row series of object mappings. Thus,
        //this method is unused.
        protected override Experience ConvertRowToModel(int generatedId, ExperienceRow row)
        {
            throw new NotImplementedException(); 
        }
        #endregion

        #region Private Methods

        private IList<Experience> InitializeOutput()
        {
            IList<Experience> models = new List<Experience>(); //we will only have one entry in this list

            int generatedId = 1;

            Experience model = new Experience();

            //initialize
            model.Id = generatedId;
            model.Description = "Container for Experience / Level information for Charcaters and Magicites";

            model.GenericCharacterLevelInfo = new List<ExperienceByLevelInfo>();
            model.TyroCharacterLevelInfo = new List<ExperienceByLevelInfo>();
            model.Magicite1StarLevelInfo = new List<ExperienceByLevelInfo>();
            model.Magicite2StarLevelInfo = new List<ExperienceByLevelInfo>();
            model.Magicite3StarLevelInfo = new List<ExperienceByLevelInfo>();
            model.Magicite4StarLevelInfo = new List<ExperienceByLevelInfo>();
            model.Magicite5StarLevelInfo = new List<ExperienceByLevelInfo>();
            model.Magicite3StarInheritanceLevelInfo = new List<ExperienceByLevelInfo>();
            model.Magicite4StarInheritanceLevelInfo = new List<ExperienceByLevelInfo>();
            model.Magicite5StarInheritanceLevelInfo = new List<ExperienceByLevelInfo>();

            models.Add(model);

            return models;
        }

        //This row modifies the model that was input by reference, adding another object to each of its collection properties
        public void PivotInputRow(ExperienceRow row, Experience model)
        {
            int currentLevel = _intConverter.ConvertFromStringToInt(row.Level);

            ExperienceByLevelInfo genericCharacterLevel = new ExperienceByLevelInfo() { Level = currentLevel };
            genericCharacterLevel.ExperienceNeededToReachLevel = _intConverter.ConvertFromStringToInt(row.Character);
            genericCharacterLevel.ExperienceNeededToReachNextLevel = _intConverter.ConvertFromStringToInt(row.NextLevelCharacter);
            ((IList<ExperienceByLevelInfo>)model.GenericCharacterLevelInfo).Add(genericCharacterLevel);

            ExperienceByLevelInfo tyroCharacterLevel = new ExperienceByLevelInfo() { Level = currentLevel };
            tyroCharacterLevel.ExperienceNeededToReachLevel = _intConverter.ConvertFromStringToInt(row.Tyro);
            tyroCharacterLevel.ExperienceNeededToReachNextLevel = _intConverter.ConvertFromStringToInt(row.NextLevelTyro);
            ((IList<ExperienceByLevelInfo>)model.TyroCharacterLevelInfo).Add(tyroCharacterLevel);

            ExperienceByLevelInfo magicite1StarLevel = new ExperienceByLevelInfo() { Level = currentLevel };
            magicite1StarLevel.ExperienceNeededToReachLevel = _intConverter.ConvertFromStringToInt(row.Magicite1);
            magicite1StarLevel.ExperienceNeededToReachNextLevel = _intConverter.ConvertFromStringToInt(row.NextLevelMagicite1);
            ((IList<ExperienceByLevelInfo>)model.Magicite1StarLevelInfo).Add(magicite1StarLevel);

            ExperienceByLevelInfo magicite2StarLevel = new ExperienceByLevelInfo() { Level = currentLevel };
            magicite2StarLevel.ExperienceNeededToReachLevel = _intConverter.ConvertFromStringToInt(row.Magicite2);
            magicite2StarLevel.ExperienceNeededToReachNextLevel = _intConverter.ConvertFromStringToInt(row.NextLevelMagicite2);
            ((IList<ExperienceByLevelInfo>)model.Magicite2StarLevelInfo).Add(magicite2StarLevel);

            ExperienceByLevelInfo magicite3StarLevel = new ExperienceByLevelInfo() { Level = currentLevel };
            magicite3StarLevel.ExperienceNeededToReachLevel = _intConverter.ConvertFromStringToInt(row.Magicite3);
            magicite3StarLevel.ExperienceNeededToReachNextLevel = _intConverter.ConvertFromStringToInt(row.NextLevelMagicite3);
            ((IList<ExperienceByLevelInfo>)model.Magicite3StarLevelInfo).Add(magicite3StarLevel);

            ExperienceByLevelInfo magicite4StarLevel = new ExperienceByLevelInfo() { Level = currentLevel };
            magicite4StarLevel.ExperienceNeededToReachLevel = _intConverter.ConvertFromStringToInt(row.Magicite4);
            magicite4StarLevel.ExperienceNeededToReachNextLevel = _intConverter.ConvertFromStringToInt(row.NextLevelMagicite4);
            ((IList<ExperienceByLevelInfo>)model.Magicite4StarLevelInfo).Add(magicite4StarLevel);

            ExperienceByLevelInfo magicite5StarLevel = new ExperienceByLevelInfo() { Level = currentLevel };
            magicite5StarLevel.ExperienceNeededToReachLevel = _intConverter.ConvertFromStringToInt(row.Magicite5);
            magicite5StarLevel.ExperienceNeededToReachNextLevel = _intConverter.ConvertFromStringToInt(row.NextLevelMagicite5);
            ((IList<ExperienceByLevelInfo>)model.Magicite5StarLevelInfo).Add(magicite5StarLevel);

            ExperienceByLevelInfo magicite3StarInheritanceLevel = new ExperienceByLevelInfo() { Level = currentLevel };
            magicite3StarInheritanceLevel.ExperienceNeededToReachLevel = _intConverter.ConvertFromStringToInt(row.Inheritance3);
            magicite3StarInheritanceLevel.ExperienceNeededToReachNextLevel = _intConverter.ConvertFromStringToInt(row.NextLevelInheritance3);
            ((IList<ExperienceByLevelInfo>)model.Magicite3StarInheritanceLevelInfo).Add(magicite3StarInheritanceLevel);

            ExperienceByLevelInfo magicite4StarInheritanceLevel = new ExperienceByLevelInfo() { Level = currentLevel };
            magicite4StarInheritanceLevel.ExperienceNeededToReachLevel = _intConverter.ConvertFromStringToInt(row.Inheritance4);
            magicite4StarInheritanceLevel.ExperienceNeededToReachNextLevel = _intConverter.ConvertFromStringToInt(row.NextLevelInheritance4);
            ((IList<ExperienceByLevelInfo>)model.Magicite4StarInheritanceLevelInfo).Add(magicite4StarInheritanceLevel);

            ExperienceByLevelInfo magicite5StarInheritanceLevel = new ExperienceByLevelInfo() { Level = currentLevel };
            magicite5StarInheritanceLevel.ExperienceNeededToReachLevel = _intConverter.ConvertFromStringToInt(row.Inheritance5);
            magicite5StarInheritanceLevel.ExperienceNeededToReachNextLevel = _intConverter.ConvertFromStringToInt(row.NextLevelInheritance5);
            ((IList<ExperienceByLevelInfo>)model.Magicite5StarInheritanceLevelInfo).Add(magicite5StarInheritanceLevel);

        }
        #endregion
    }
}
