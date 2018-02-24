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
    public interface IAbilitiesLogic
    {
        IEnumerable<Ability> GetAllAbilities();
        IEnumerable<Ability> GetAbilitiesById(int abilityId);
        IEnumerable<Ability> GetAbilitiesByAbilityType(int abilityType);
        IEnumerable<Ability> GetAbilitiesByRarity(int rarity);
        IEnumerable<Ability> GetAbilitiesBySchool(int schoolType);
        IEnumerable<Ability> GetAbilitiesByElement(int elementType);
        IEnumerable<Ability> GetAbilitiesBySearch(Ability searchPrototype);
    }

    public class AbilitiesLogic : IAbilitiesLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<AbilitiesLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public AbilitiesLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<AbilitiesLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region IAbilitiesLogic Implementation
   
        public IEnumerable<Ability> GetAllAbilities()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllAbilities)}");

            IList<Ability> results = _cacheProvider.ObjectGet<IList<Ability>>(nameof(GetAllAbilities));

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Abilities.ToList();

                _cacheProvider.ObjectSet(nameof(GetAllAbilities), results);
            }

            return results;
        }

        public IEnumerable<Ability> GetAbilitiesById(int abilityId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesById)}");

            return _enlirRepository.GetMergeResultsContainer().Abilities.Where(a => a.Id == abilityId);
        }

        public IEnumerable<Ability> GetAbilitiesByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesByAbilityType)}");

            return _enlirRepository.GetMergeResultsContainer().Abilities.Where(a => a.AbilityType == abilityType);
        }

        public IEnumerable<Ability> GetAbilitiesByRarity(int rarity)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesByRarity)}");

            return _enlirRepository.GetMergeResultsContainer().Abilities.Where(a => a.Rarity == rarity);
        }

        public IEnumerable<Ability> GetAbilitiesBySchool(int schoolType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesBySchool)}");

            return _enlirRepository.GetMergeResultsContainer().Abilities.Where(a => a.School == schoolType);
        }

        public IEnumerable<Ability> GetAbilitiesByElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesByElement)}");

            return _enlirRepository.GetMergeResultsContainer().Abilities.Where(a => a.Elements.Contains(elementType));
        }

        public IEnumerable<Ability> GetAbilitiesBySearch(Ability searchPrototype)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesBySearch)}");


            //ignore: Description, Effects, EnlirId, Id, ImagePath, IntroducingEventId, IntroducingEventName, IsChecked, IsCounterable, SoulBreakPointsGainedJapan
            var query = _enlirRepository.GetMergeResultsContainer().Abilities;

            if (!string.IsNullOrWhiteSpace(searchPrototype.AbilityName))
            {
                query = query.Where(a => a.AbilityName.ToLower().Contains(searchPrototype.AbilityName.ToLower()));
            }
            if (searchPrototype.AbilityType != 0)
            {
                query = query.Where(a => a.AbilityType == searchPrototype.AbilityType);
            }
            if (searchPrototype.AutoTargetType != 0)
            {
                query = query.Where(a => a.AutoTargetType == searchPrototype.AutoTargetType);
            }
            if (searchPrototype.CastTime != 0)
            {
                query = query.Where(a => a.CastTime <= searchPrototype.CastTime);
            }
            if (searchPrototype.DamageFormulaType != 0)
            {
                query = query.Where(a => a.DamageFormulaType == searchPrototype.DamageFormulaType);
            }
            if (searchPrototype.Elements != null && searchPrototype.Elements.Any())
            {
                query = query.Where(a => a.Elements.Contains(searchPrototype.Elements.First()));
            }
            if (searchPrototype.Multiplier != 0)
            {
                query = query.Where(a => a.Multiplier >= searchPrototype.Multiplier);
            }
            if (searchPrototype.OrbRequirements != null && searchPrototype.OrbRequirements.Any())
            {
                query = query.Where(a => a.OrbRequirements.Select(or => or.OrbId).Contains(searchPrototype.OrbRequirements.First().OrbId));
            }
            if (searchPrototype.Rarity != 0)
            {
                query = query.Where(a => a.Rarity == searchPrototype.Rarity);
            }
            if (searchPrototype.School != 0)
            {
                query = query.Where(a => a.School == searchPrototype.School);
            }
            if (searchPrototype.SoulBreakPointsGained != 0)
            {
                query = query.Where(a => a.SoulBreakPointsGained >= searchPrototype.SoulBreakPointsGained);
            }
            if (searchPrototype.TargetType != 0)
            {
                query = query.Where(a => a.TargetType == searchPrototype.TargetType);
            }

            return query;
        }
        #endregion
    }
}
