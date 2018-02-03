using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface ILegendMateriasLogic
    {
        IEnumerable<LegendMateria> GetAllLegendMaterias();
        IEnumerable<LegendMateria> GetLegendMateriasById(int legendMateriaId);
        IEnumerable<LegendMateria> GetLegendMateriasByName(string legendMateriaName);
        IEnumerable<LegendMateria> GetLegendMateriasByRealm(int realmType);
        IEnumerable<LegendMateria> GetLegendMateriasByCharacter(int characterId);
        IEnumerable<LegendMateria> GetLegendMateriasByEffect(string effectText);
        IEnumerable<LegendMateria> GetLegendMateriasByMasteryBonus(string masteryBonusText);
        IEnumerable<LegendMateria> GetLegendMateriasByRelic(int relicId);
        IEnumerable<LegendMateria> GetLegendMateriasBySearch(LegendMateria searchPrototype);
    }

    public class LegendMateriasLogic : ILegendMateriasLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<LegendMateriasLogic> _logger;
        #endregion

        #region Constructors

        public LegendMateriasLogic(IEnlirRepository enlirRepository, ILogger<LegendMateriasLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region ILegendMateriasLogic Implementation

        public IEnumerable<LegendMateria> GetAllLegendMaterias()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllLegendMaterias)}");

            return _enlirRepository.GetMergeResultsContainer().LegendMaterias;
        }

        public IEnumerable<LegendMateria> GetLegendMateriasById(int legendMateriaId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasById)}");

            return _enlirRepository.GetMergeResultsContainer().LegendMaterias.Where(e => e.Id == legendMateriaId);
        }

        public IEnumerable<LegendMateria> GetLegendMateriasByName(string legendMateriaName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasByName)}");

            IEnumerable<LegendMateria> results = new List<LegendMateria>();

            if (!String.IsNullOrWhiteSpace(legendMateriaName))
            {
                results = _enlirRepository.GetMergeResultsContainer().LegendMaterias.Where(e => e.LegendMateriaName.ToLower().Contains(legendMateriaName.ToLower()));
            }

            return results;
        }

        public IEnumerable<LegendMateria> GetLegendMateriasByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasByRealm)}");

            return _enlirRepository.GetMergeResultsContainer().LegendMaterias.Where(e => e.Realm == realmType);
        }

        public IEnumerable<LegendMateria> GetLegendMateriasByCharacter(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasByCharacter)}");

            return _enlirRepository.GetMergeResultsContainer().LegendMaterias.Where(e => e.CharacterId == characterId);
        }

        public IEnumerable<LegendMateria> GetLegendMateriasByEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasByEffect)}");

            IEnumerable<LegendMateria> results = new List<LegendMateria>();

            if (!String.IsNullOrWhiteSpace(effectText))
            {
                results = _enlirRepository.GetMergeResultsContainer().LegendMaterias.Where(e => e.Effect.ToLower().Contains(effectText.ToLower()));
            }
            return results;
        }

        public IEnumerable<LegendMateria> GetLegendMateriasByMasteryBonus(string masteryBonusText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasByMasteryBonus)}");

            IEnumerable<LegendMateria> results = new List<LegendMateria>();

            if (!String.IsNullOrWhiteSpace(masteryBonusText))
            {
                results = _enlirRepository.GetMergeResultsContainer().LegendMaterias.Where(e => e.MasteryBonus.ToLower().Contains(masteryBonusText.ToLower()));
            }
            return results;
        }

        public IEnumerable<LegendMateria> GetLegendMateriasByRelic(int relicId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasByRelic)}");

            return _enlirRepository.GetMergeResultsContainer().LegendMaterias.Where(e => e.RelicId == relicId);
        }

        public IEnumerable<LegendMateria> GetLegendMateriasBySearch(LegendMateria searchPrototype)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasBySearch)}");


            //ignore: Id, Description, LegendMateriaId, JapaneseName, CharacterName, ImagePath, RelicName, IsChecked
            var query = _enlirRepository.GetMergeResultsContainer().LegendMaterias;

            if (searchPrototype.Realm != 0)
            {
                query = query.Where(l => l.Realm == searchPrototype.Realm);
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.LegendMateriaName))
            {
                query = query.Where(l => l.LegendMateriaName.ToLower().Contains(searchPrototype.LegendMateriaName.ToLower()));
            }
            if (searchPrototype.CharacterId != 0)
            {
                query = query.Where(l => l.CharacterId == searchPrototype.CharacterId);
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.Effect))
            {
                query = query.Where(l => l.Effect.ToLower().Contains(searchPrototype.Effect.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.MasteryBonus))
            {
                query = query.Where(l => l.MasteryBonus.ToLower().Contains(searchPrototype.MasteryBonus.ToLower()));
            }
            if (searchPrototype.RelicId != 0)
            {
                query = query.Where(l => l.RelicId == searchPrototype.RelicId);
            }

            return query;
        }

        #endregion
    }
}
