using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Model.EnlirImport;
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
        private readonly IRowImporter<OtherRow> _otherImporter;
        private readonly IRowImporter<StatusRow> _statusImporter;
        private readonly IRowImporter<RelicRow> _relicImporter;
        private readonly IRowImporter<MagiciteRow> _magiciteImporter;
        private readonly IRowImporter<MagiciteSkillRow> _magiciteSkillImporter;
        private readonly IRowImporter<DungeonRow> _dungeonImporter;
        private readonly IRowImporter<EventRow> _eventImporter;
        private readonly IRowImporter<MissionRow> _missionImporter;
        private readonly IRowImporter<ExperienceRow> _experienceImporter;

        private readonly ILogger<ImportManager> _logger;
        #endregion

        #region Constructors
        public ImportManager(IRowImporter<CharacterRow> characterImporter, IRowImporter<RecordSphereRow> recordSphereImporter,
            IRowImporter<LegendSphereRow> legendSphereImporter, IRowImporter<RecordMateriaRow> recordMateriaImporter,
            IRowImporter<LegendMateriaRow> legendMateriaImporter, IRowImporter<AbilityRow> abilityImporter,
            IRowImporter<SoulBreakRow> soulBreakImporter, IRowImporter<CommandRow> commandImporter,
            IRowImporter<OtherRow> otherImporter, IRowImporter<StatusRow> statusImporter,
            IRowImporter<RelicRow> relicImporter, IRowImporter<MagiciteRow> magiciteImporter,
            IRowImporter<MagiciteSkillRow> magiciteSkillImporter, IRowImporter<DungeonRow> dungeonImporter,
            IRowImporter<MissionRow> missionImporter, IRowImporter<EventRow> eventImporter,
            IRowImporter<ExperienceRow> experienceImporter, ILogger<ImportManager> logger)
        {
            _characterImporter = characterImporter;
            _recordSphereImporter = recordSphereImporter;
            _legendSphereImporter = legendSphereImporter;
            _recordMateriaImporter = recordMateriaImporter;
            _legendMateriaImporter = legendMateriaImporter;
            _abilityImporter = abilityImporter;
            _soulBreakImporter = soulBreakImporter;
            _commandImporter = commandImporter;
            _otherImporter = otherImporter;
            _statusImporter = statusImporter;
            _relicImporter = relicImporter;
            _magiciteImporter = magiciteImporter;
            _magiciteSkillImporter = magiciteSkillImporter;
            _dungeonImporter = dungeonImporter;
            _eventImporter = eventImporter;
            _missionImporter = missionImporter;
            _experienceImporter = experienceImporter;

            _logger = logger;
        }
        #endregion

        #region IImportManager Implementation
        public ImportResultsContainer ImportAll()
        {
            ImportResultsContainer resultsContainer = new ImportResultsContainer();

            //resultsContainer.CharacterRows = _characterImporter.Import();
            _logger.LogInformation("finished loading CharacterRows");

           // resultsContainer.RecordSphereRows = _recordSphereImporter.Import();
            _logger.LogInformation("finished loading RecordSphereRows");

            //resultsContainer.LegendSphereRows = _legendSphereImporter.Import();
            _logger.LogInformation("finished loading LegendSphereRows");

            //resultsContainer.RecordMateriaRows = _recordMateriaImporter.Import();
            _logger.LogInformation("finished loading RecordMateriaRows");

            //resultsContainer.AbilityRows = _abilityImporter.Import();
            _logger.LogInformation("finished loading AbilityRows");

            //resultsContainer.SoulBreakRows = _soulBreakImporter.Import();
            _logger.LogInformation("finished loading SoulBreakRows");

            //resultsContainer.CommandRows = _commandImporter.Import();
            _logger.LogInformation("finished loading CommandRows");

            //resultsContainer.OtherRows = _otherImporter.Import();
            _logger.LogInformation("finished loading OtherRows");

            //resultsContainer.StatusRows = _statusImporter.Import();
            _logger.LogInformation("finished loading StatusRows");

            //resultsContainer.RelicRows = _relicImporter.Import();
            _logger.LogInformation("finished loading RelicRows");

            //resultsContainer.MagiciteRows = _magiciteImporter.Import();
            _logger.LogInformation("finished loading MagiciteRows");

            //resultsContainer.MagiciteSkillRows = _magiciteSkillImporter.Import();
            _logger.LogInformation("finished loading MagiciteRows");

            //resultsContainer.DungeonRows = _dungeonImporter.Import();
            _logger.LogInformation("finished loading DungeonRows");

            resultsContainer.EventRows = _eventImporter.Import();
            _logger.LogInformation("finished loading EventRows");

            //resultsContainer.MissionRows = _missionImporter.Import();
            _logger.LogInformation("finished loading MissionRows");

            //resultsContainer.ExperienceRows = _experienceImporter.Import();
            _logger.LogInformation("finished loading ExperienceRows");

            return resultsContainer;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
