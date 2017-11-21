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

        private readonly IImportStorageProvider _importStorageProvider;
        private readonly ILogger<TransformManager> _logger;

        #endregion

        #region Constructors

        public TransformManager(IRowTransformer<EventRow, Event> eventRowTransformer, IRowTransformer<MissionRow, Mission> missionRowTransformer,
            IRowTransformer<ExperienceRow, Experience> experienceRowTransformer, IRowTransformer<DungeonRow, Dungeon> dungeonRowTransformer,
            IRowTransformer<MagiciteSkillRow, MagiciteSkill> magiciteSkillRowTransformer, IRowTransformer<MagiciteRow, Magicite> magiciteRowTransformer,
            IImportStorageProvider importStorageProvider, ILogger<TransformManager> logger)
        {
            _eventRowTransformer = eventRowTransformer;
            _missionRowTransformer = missionRowTransformer;
            _experienceRowTransformer = experienceRowTransformer;
            _dungeonRowTransformer = dungeonRowTransformer;
            _magiciteSkillRowTransformer = magiciteSkillRowTransformer;
            _magiciteRowTransformer = magiciteRowTransformer;

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

            transformResultsContainer.Missions = _missionRowTransformer.Transform(importResults.MissionRows);
            _logger.LogInformation("finished transforming MissionRows to Missions");

            //transformResultsContainer.Experiences = _experienceRowTransformer.Transform(importResults.ExperienceRows);
            _logger.LogInformation("finished transforming ExperienceRows to a single Experience object in a list");

            //transformResultsContainer.Dungeons = _dungeonRowTransformer.Transform(importResults.DungeonRows);
            _logger.LogInformation("finished transforming DungeonRows to Dungeons");

            //transformResultsContainer.MagiciteSkills = _magiciteSkillRowTransformer.Transform(importResults.MagiciteSkillRows);
            _logger.LogInformation("finished transforming MagiciteSkillRows to MagiciteSkills");

            //transformResultsContainer.Magicites = _magiciteRowTransformer.Transform(importResults.MagiciteRows);
            _logger.LogInformation("finished transforming MagiciteSkillRows to MagiciteSkills");
            return transformResultsContainer;
        } 
        #endregion
    }
}
