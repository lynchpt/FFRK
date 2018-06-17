using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IBraveActionsLogic
    {
        IEnumerable<BraveAction> GetAllBraveActions();
        IEnumerable<BraveAction> GetBraveActionsById(int braveActionId);
        IEnumerable<BraveAction> GetBraveActionsByAbilityType(int abilityType);
        IEnumerable<BraveAction> GetBraveActionsByCharacter(int characterId);
        IEnumerable<BraveAction> GetBraveActionsBySchool(int schoolType);
        IEnumerable<BraveAction> GetBraveActionsByElement(int elementType);
        IEnumerable<BraveAction> GetBraveActionsBySearch(BraveAction searchPrototype);
    }

    public class BraveActionsLogic : IBraveActionsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<BraveActionsLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public BraveActionsLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<BraveActionsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region IBraveActionsLogic Implementation
        public IEnumerable<BraveAction> GetAllBraveActions()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllBraveActions)}");

            string cacheKey = $"{nameof(GetAllBraveActions)}";
            IEnumerable<BraveAction> results = _cacheProvider.ObjectGet<IList<BraveAction>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().BraveActions;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<BraveAction> GetBraveActionsById(int braveActionId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetBraveActionsById)}");

            string cacheKey = $"{nameof(GetBraveActionsById)}:{braveActionId}";
            IEnumerable<BraveAction> results = _cacheProvider.ObjectGet<IList<BraveAction>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().BraveActions.Where(c => c.Id == braveActionId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<BraveAction> GetBraveActionsByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetBraveActionsByAbilityType)}");

            string cacheKey = $"{nameof(GetBraveActionsByAbilityType)}:{abilityType}";
            IEnumerable<BraveAction> results = _cacheProvider.ObjectGet<IList<BraveAction>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().BraveActions.Where(c => c.AbilityType == abilityType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<BraveAction> GetBraveActionsByCharacter(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetBraveActionsByCharacter)}");

            string cacheKey = $"{nameof(GetBraveActionsByCharacter)}:{characterId}";
            IEnumerable<BraveAction> results = _cacheProvider.ObjectGet<IList<BraveAction>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().BraveActions.Where(c => c.CharacterId == characterId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<BraveAction> GetBraveActionsBySchool(int schoolType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetBraveActionsBySchool)}");

            string cacheKey = $"{nameof(GetBraveActionsBySchool)}:{schoolType}";
            IEnumerable<BraveAction> results = _cacheProvider.ObjectGet<IList<BraveAction>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().BraveActions.Where(c => c.School == schoolType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<BraveAction> GetBraveActionsByElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetBraveActionsByElement)}");

            string cacheKey = $"{nameof(GetBraveActionsByElement)}:{elementType}";
            IEnumerable<BraveAction> results = _cacheProvider.ObjectGet<IList<BraveAction>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().BraveActions.Where(c => c.Elements.Contains(elementType));

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<BraveAction> GetBraveActionsBySearch(BraveAction searchPrototype)
        {
            //ignore: CharacterName, Description, SourceSoulBreakName, ImagePath, EnlirId, Id, ImagePath, IsChecked, IsCounterable, JapaneseName, SoulBreakPointsGainedJapan
            var query = _enlirRepository.GetMergeResultsContainer().BraveActions;

            if (searchPrototype.CharacterId != 0)
            {
                query = query.Where(c => c.CharacterId == searchPrototype.CharacterId);
            }
            if (searchPrototype.AbilityType != 0)
            {
                query = query.Where(c => c.AbilityType == searchPrototype.AbilityType);
            }
            if (searchPrototype.School != 0)
            {
                query = query.Where(c => c.School == searchPrototype.School);
            }
            if (searchPrototype.Elements != null && searchPrototype.Elements.Any())
            {
                query = query.Where(c => c.Elements.Contains(searchPrototype.Elements.First()));
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.BraveActionName))
            {
                query = query.Where(c => c.BraveActionName.Contains(searchPrototype.BraveActionName));
            }
            if (searchPrototype.AutoTargetType != 0)
            {
                query = query.Where(c => c.AutoTargetType == searchPrototype.AutoTargetType);
            }
            if (searchPrototype.CastTime != 0)
            {
                query = query.Where(c => c.CastTime <= searchPrototype.CastTime);
            }
            if (searchPrototype.DamageFormulaType != 0)
            {
                query = query.Where(c => c.DamageFormulaType == searchPrototype.DamageFormulaType);
            }
            if (searchPrototype.Multiplier != 0)
            {
                query = query.Where(c => c.Multiplier >= searchPrototype.Multiplier);
            }
            if (searchPrototype.SoulBreakPointsGained != 0)
            {
                query = query.Where(c => c.SoulBreakPointsGained >= searchPrototype.SoulBreakPointsGained);
            }
            if (searchPrototype.TargetType != 0)
            {
                query = query.Where(c => c.TargetType == searchPrototype.TargetType);
            }

            return query;
        } 
        #endregion
    }
}
