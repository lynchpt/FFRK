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
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public LegendMateriasLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<LegendMateriasLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region ILegendMateriasLogic Implementation

        public IEnumerable<LegendMateria> GetAllLegendMaterias()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllLegendMaterias)}");

            string cacheKey = $"{nameof(GetAllLegendMaterias)}";
            IEnumerable<LegendMateria> results = _cacheProvider.ObjectGet<IList<LegendMateria>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LegendMaterias;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<LegendMateria> GetLegendMateriasById(int legendMateriaId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasById)}");

            string cacheKey = $"{nameof(GetLegendMateriasById)}:{legendMateriaId}";
            IEnumerable<LegendMateria> results = _cacheProvider.ObjectGet<IList<LegendMateria>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LegendMaterias.Where(e => e.Id == legendMateriaId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<LegendMateria> GetLegendMateriasByName(string legendMateriaName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasByName)}");

            string cacheKey = $"{nameof(GetLegendMateriasByName)}:{legendMateriaName}";
            IEnumerable<LegendMateria> results = _cacheProvider.ObjectGet<IList<LegendMateria>>(cacheKey);

            if (results == null)
            {
                results = new List<LegendMateria>();

                if (!String.IsNullOrWhiteSpace(legendMateriaName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().LegendMaterias.Where(e => e.LegendMateriaName.ToLower().Contains(legendMateriaName.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<LegendMateria> GetLegendMateriasByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasByRealm)}");

            string cacheKey = $"{nameof(GetLegendMateriasByRealm)}:{realmType}";
            IEnumerable<LegendMateria> results = _cacheProvider.ObjectGet<IList<LegendMateria>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LegendMaterias.Where(e => e.Realm == realmType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<LegendMateria> GetLegendMateriasByCharacter(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasByCharacter)}");

            string cacheKey = $"{nameof(GetLegendMateriasByCharacter)}:{characterId}";
            IEnumerable<LegendMateria> results = _cacheProvider.ObjectGet<IList<LegendMateria>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LegendMaterias.Where(e => e.CharacterId == characterId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<LegendMateria> GetLegendMateriasByEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasByEffect)}");

            string cacheKey = $"{nameof(GetLegendMateriasByEffect)}:{effectText}";
            IEnumerable<LegendMateria> results = _cacheProvider.ObjectGet<IList<LegendMateria>>(cacheKey);

            if (results == null)
            {
                results = new List<LegendMateria>();

                if (!String.IsNullOrWhiteSpace(effectText))
                {
                    results = _enlirRepository.GetMergeResultsContainer().LegendMaterias.Where(e => e.Effect.ToLower().Contains(effectText.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<LegendMateria> GetLegendMateriasByMasteryBonus(string masteryBonusText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasByMasteryBonus)}");

            string cacheKey = $"{nameof(GetLegendMateriasByMasteryBonus)}:{masteryBonusText}";
            IEnumerable<LegendMateria> results = _cacheProvider.ObjectGet<IList<LegendMateria>>(cacheKey);

            if (results == null)
            {
                results = new List<LegendMateria>();

                if (!String.IsNullOrWhiteSpace(masteryBonusText))
                {
                    results = _enlirRepository.GetMergeResultsContainer().LegendMaterias.Where(e => e.MasteryBonus.ToLower().Contains(masteryBonusText.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<LegendMateria> GetLegendMateriasByRelic(int relicId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriasByRelic)}");

            string cacheKey = $"{nameof(GetLegendMateriasByRelic)}:{relicId}";
            IEnumerable<LegendMateria> results = _cacheProvider.ObjectGet<IList<LegendMateria>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LegendMaterias.Where(e => e.RelicId == relicId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
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
