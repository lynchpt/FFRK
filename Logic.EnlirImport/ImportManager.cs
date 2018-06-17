using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRKApi.Model.EnlirImport;
using FFRKApi.SheetsApiHelper;
using Microsoft.Extensions.Logging;
using Model.EnlirImport;

namespace FFRKApi.Logic.EnlirImport
{
    public interface IImportManager
    {
        ImportResultsContainer ImportAll();
    }

    public class ImportManager: IImportManager
    {
        #region Class Variables

        private readonly IRowImporter<CharacterRow> _characterImporter;
        private readonly IRowImporter<RecordSphereRow> _recordSphereImporter;
        private readonly IRowImporter<LegendSphereRow> _legendSphereImporter;
        private readonly IRowImporter<RecordMateriaRow> _recordMateriaImporter;
        private readonly IRowImporter<LegendMateriaRow> _legendMateriaImporter;
        private readonly IRowImporter<AbilityRow> _abilityImporter;
        private readonly IRowImporter<SoulBreakRow> _soulBreakImporter;
        private readonly IRowImporter<CommandRow> _commandImporter;
        private readonly IRowImporter<BraveActionRow> _braveActionImporter;
        private readonly IRowImporter<OtherRow> _otherImporter;
        private readonly IRowImporter<StatusRow> _statusImporter;
        private readonly IRowImporter<RelicRow> _relicImporter;
        private readonly IRowImporter<MagiciteRow> _magiciteImporter;
        private readonly IRowImporter<MagiciteSkillRow> _magiciteSkillImporter;
        //private readonly IRowImporter<DungeonRow> _dungeonImporter;
        private readonly IRowImporter<EventRow> _eventImporter;
        private readonly IRowImporter<MissionRow> _missionImporter;
        private readonly IRowImporter<ExperienceRow> _experienceImporter;

        private readonly ISheetsApiHelper _sheetsApiHelper;
        private readonly ILogger<ImportManager> _logger;
        #endregion

        #region Constructors
        public ImportManager(IRowImporter<CharacterRow> characterImporter, IRowImporter<RecordSphereRow> recordSphereImporter,
            IRowImporter<LegendSphereRow> legendSphereImporter, IRowImporter<RecordMateriaRow> recordMateriaImporter,
            IRowImporter<LegendMateriaRow> legendMateriaImporter, IRowImporter<AbilityRow> abilityImporter,
            IRowImporter<SoulBreakRow> soulBreakImporter, IRowImporter<CommandRow> commandImporter, IRowImporter<BraveActionRow> braveActionImporter,
            IRowImporter<OtherRow> otherImporter, IRowImporter<StatusRow> statusImporter,
            IRowImporter<RelicRow> relicImporter, IRowImporter<MagiciteRow> magiciteImporter,
            IRowImporter<MagiciteSkillRow> magiciteSkillImporter,
            IRowImporter<MissionRow> missionImporter, IRowImporter<EventRow> eventImporter,
            IRowImporter<ExperienceRow> experienceImporter, ISheetsApiHelper sheetsApiHelper,
            ILogger<ImportManager> logger)
        {
            _characterImporter = characterImporter;
            _recordSphereImporter = recordSphereImporter;
            _legendSphereImporter = legendSphereImporter;
            _recordMateriaImporter = recordMateriaImporter;
            _legendMateriaImporter = legendMateriaImporter;
            _abilityImporter = abilityImporter;
            _soulBreakImporter = soulBreakImporter;
            _commandImporter = commandImporter;
            _braveActionImporter = braveActionImporter;
            _otherImporter = otherImporter;
            _statusImporter = statusImporter;
            _relicImporter = relicImporter;
            _magiciteImporter = magiciteImporter;
            _magiciteSkillImporter = magiciteSkillImporter;
            //_dungeonImporter = dungeonImporter;
            _eventImporter = eventImporter;
            _missionImporter = missionImporter;
            _experienceImporter = experienceImporter;

            _sheetsApiHelper = sheetsApiHelper;
            _logger = logger;
        }
        #endregion

        #region IImportManager Implementation

        public ImportResultsContainer ImportAll()
        {
            try
            {
                ImportResultsContainer resultsContainer = new ImportResultsContainer();

                resultsContainer.CharacterRows = _characterImporter.Import();
                _logger.LogInformation("finished loading {RowCount} CharacterRows", resultsContainer.CharacterRows?.Count());

                resultsContainer.RecordSphereRows = _recordSphereImporter.Import();
                _logger.LogInformation("finished loading {RowCount} RecordSphereRows", resultsContainer.RecordSphereRows?.Count());

                resultsContainer.LegendSphereRows = _legendSphereImporter.Import();
                _logger.LogInformation("finished loading {RowCount} LegendSphereRows", resultsContainer.LegendSphereRows?.Count());

                resultsContainer.RecordMateriaRows = _recordMateriaImporter.Import();
                _logger.LogInformation("finished loading {RowCount} RecordMateriaRows", resultsContainer.RecordMateriaRows?.Count());

                resultsContainer.LegendMateriaRows = _legendMateriaImporter.Import();
                _logger.LogInformation("finished loading {RowCount} LegendMateriaRows", resultsContainer.LegendMateriaRows?.Count());

                resultsContainer.AbilityRows = _abilityImporter.Import();
                _logger.LogInformation("finished loading {RowCount} AbilityRows", resultsContainer.AbilityRows?.Count());

                resultsContainer.SoulBreakRows = _soulBreakImporter.Import();
                _logger.LogInformation("finished loading {RowCount} SoulBreakRows", resultsContainer.SoulBreakRows?.Count());

                resultsContainer.CommandRows = _commandImporter.Import();
                _logger.LogInformation("finished loading {RowCount} CommandRows", resultsContainer.CommandRows?.Count());

                resultsContainer.BraveActionRows = _braveActionImporter.Import();
                _logger.LogInformation("finished loading {RowCount} BraveActionRows", resultsContainer.BraveActionRows?.Count());

                resultsContainer.OtherRows = _otherImporter.Import();
                _logger.LogInformation("finished loading {RowCount} OtherRows", resultsContainer.OtherRows?.Count());

                resultsContainer.StatusRows = _statusImporter.Import();
                _logger.LogInformation("finished loading {RowCount} StatusRows", resultsContainer.StatusRows?.Count());

                resultsContainer.RelicRows = _relicImporter.Import();
                _logger.LogInformation("finished loading {RowCount} RelicRows", resultsContainer.RelicRows?.Count());

                resultsContainer.MagiciteRows = _magiciteImporter.Import();
                _logger.LogInformation("finished loading {RowCount} MagiciteRows", resultsContainer.MagiciteRows?.Count());

                resultsContainer.MagiciteSkillRows = _magiciteSkillImporter.Import();
                _logger.LogInformation("finished loading {RowCount} MagiciteSkillRows", resultsContainer.MagiciteSkillRows?.Count());

                //resultsContainer.DungeonRows = _dungeonImporter.Import();
                //_logger.LogInformation("finished loading {RowCount} DungeonRows", resultsContainer.DungeonRows?.Count());

                resultsContainer.EventRows = _eventImporter.Import();
                _logger.LogInformation("finished loading {RowCount} EventRows", resultsContainer.EventRows?.Count());

                resultsContainer.MissionRows = _missionImporter.Import();
                _logger.LogInformation("finished loading {RowCount} MissionRows", resultsContainer.MissionRows?.Count());

                resultsContainer.ExperienceRows = _experienceImporter.Import();
                _logger.LogInformation("finished loading {RowCount} ExperienceRows", resultsContainer.ExperienceRows?.Count());

                return resultsContainer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                _logger.LogInformation("Error in ImportManager ImportAll method - import was NOT completed.");
                throw;
            }
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
