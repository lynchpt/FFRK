using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Data.Storage;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.EnlirTransform
{
    public interface ITransformManager
    {
        TransformResultsContainer TransformAll();
    }

    public class TransformManager: ITransformManager
    {
        #region Class Variables

        private readonly IRowTransformer<MissionRow, Mission> _missionRowTransformer;
        private readonly IRowTransformer<EventRow, Event> _eventRowTransformer;
        private readonly IRowTransformer<ExperienceRow, Experience> _experienceRowTransformer;
        private readonly IRowTransformer<DungeonRow, Dungeon> _dungeonRowTransformer;
        private readonly IRowTransformer<MagiciteSkillRow, MagiciteSkill> _magiciteSkillRowTransformer;
        private readonly IRowTransformer<MagiciteRow, Magicite> _magiciteRowTransformer;
        private readonly IRowTransformer<StatusRow, Status> _statusRowTransformer;
        private readonly IRowTransformer<OtherRow, Other> _otherRowTransformer;
        private readonly IRowTransformer<CommandRow, Command> _commandRowTransformer;
        private readonly IRowTransformer<SoulBreakRow, SoulBreak> _soulBreakRowTransformer;
        private readonly IRowTransformer<RelicRow, Relic> _relicRowTransformer;
        private readonly IRowTransformer<AbilityRow, Ability> _abilityRowTransformer;

        private readonly IImportStorageProvider _importStorageProvider;
        private readonly ILogger<TransformManager> _logger;

        #endregion

        #region Constructors

        public TransformManager(IRowTransformer<EventRow, Event> eventRowTransformer, IRowTransformer<MissionRow, Mission> missionRowTransformer,
            IRowTransformer<ExperienceRow, Experience> experienceRowTransformer, IRowTransformer<DungeonRow, Dungeon> dungeonRowTransformer,
            IRowTransformer<MagiciteSkillRow, MagiciteSkill> magiciteSkillRowTransformer, IRowTransformer<MagiciteRow, Magicite> magiciteRowTransformer,
            IRowTransformer<StatusRow, Status> statusRowTransformer, IRowTransformer<OtherRow, Other> otherRowTransformer,
            IRowTransformer<CommandRow, Command> commandRowTransformer, IRowTransformer<SoulBreakRow, SoulBreak> soulBreakRowTransformer,
            IRowTransformer<RelicRow, Relic> relicRowTransformer, IRowTransformer<AbilityRow, Ability> abilityRowTransformer,
            IImportStorageProvider importStorageProvider, ILogger<TransformManager> logger)
        {
            _eventRowTransformer = eventRowTransformer;
            _missionRowTransformer = missionRowTransformer;
            _experienceRowTransformer = experienceRowTransformer;
            _dungeonRowTransformer = dungeonRowTransformer;
            _magiciteSkillRowTransformer = magiciteSkillRowTransformer;
            _magiciteRowTransformer = magiciteRowTransformer;
            _statusRowTransformer = statusRowTransformer;
            _otherRowTransformer = otherRowTransformer;
            _commandRowTransformer = commandRowTransformer;
            _soulBreakRowTransformer = soulBreakRowTransformer;
            _relicRowTransformer = relicRowTransformer;
            _abilityRowTransformer = abilityRowTransformer;


            _importStorageProvider = importStorageProvider;
            _logger = logger;
        }
        #endregion

        #region ITransformManager Implementation
        public TransformResultsContainer TransformAll()
        {
            TransformResultsContainer transformResultsContainer = new TransformResultsContainer();

            ImportResultsContainer importResults = _importStorageProvider.RetrieveImportResults();

            // transformResultsContainer.Events = _eventRowTransformer.Transform(importResults.EventRows);
            _logger.LogInformation("finished transforming EventRows to Events");

            //transformResultsContainer.Missions = _missionRowTransformer.Transform(importResults.MissionRows);
            _logger.LogInformation("finished transforming MissionRows to Missions");

            //transformResultsContainer.Experiences = _experienceRowTransformer.Transform(importResults.ExperienceRows);
            _logger.LogInformation("finished transforming ExperienceRows to a single Experience object in a list");

            //transformResultsContainer.Dungeons = _dungeonRowTransformer.Transform(importResults.DungeonRows);
            _logger.LogInformation("finished transforming DungeonRows to Dungeons");

            //transformResultsContainer.MagiciteSkills = _magiciteSkillRowTransformer.Transform(importResults.MagiciteSkillRows);
            _logger.LogInformation("finished transforming MagiciteSkillRows to MagiciteSkills");

            //transformResultsContainer.Magicites = _magiciteRowTransformer.Transform(importResults.MagiciteRows);
            _logger.LogInformation("finished transforming MagiciteRows to Magicites");

            //transformResultsContainer.Others = _otherRowTransformer.Transform(importResults.OtherRows);
            _logger.LogInformation("finished transforming OtherRows to Others");

            transformResultsContainer.Commands = _commandRowTransformer.Transform(importResults.CommandRows);
            _logger.LogInformation("finished transforming CommandRows to Commands");

            //transformResultsContainer.SoulBreaks = _soulBreakRowTransformer.Transform(importResults.SoulBreakRows);
            _logger.LogInformation("finished transforming SoulBreakRows to SoulBreaks");

            //transformResultsContainer.Relics = _relicRowTransformer.Transform(importResults.RelicRows);
            _logger.LogInformation("finished transforming RelicRows to Relics");

            //transformResultsContainer.Abilities = _abilityRowTransformer.Transform(importResults.AbilityRows);
            _logger.LogInformation("finished transforming AbilityRows to Abilities");

            return transformResultsContainer;
        } 
        #endregion
    }
}
