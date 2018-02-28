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
    public interface IRecordMateriasLogic
    {
        IEnumerable<RecordMateria> GetAllRecordMaterias();
        IEnumerable<RecordMateria> GetRecordMateriasById(int recordMateriaId);
        IEnumerable<RecordMateria> GetRecordMateriasByName(string recordMateriaName);
        IEnumerable<RecordMateria> GetAllRecordMateriasByRealm(int realmType);
        IEnumerable<RecordMateria> GetRecordMateriasByCharacter(int characterId);
        IEnumerable<RecordMateria> GetRecordMateriasByEffect(string effectText);
        IEnumerable<RecordMateria> GetRecordMateriasByUnlockCriteria(string unlockText);
        IEnumerable<RecordMateria> GetRecordMateriasBySearch(RecordMateria searchPrototype);
    }

    public class RecordMateriasLogic : IRecordMateriasLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<RecordMateriasLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public RecordMateriasLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<RecordMateriasLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region IRecordMateriasLogic Implementation

        public IEnumerable<RecordMateria> GetAllRecordMaterias()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllRecordMaterias)}");

            string cacheKey = $"{nameof(GetAllRecordMaterias)}";
            IEnumerable<RecordMateria> results = _cacheProvider.ObjectGet<IList<RecordMateria>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordMaterias;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<RecordMateria> GetRecordMateriasById(int recordMateriaId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordMateriasById)}");

            string cacheKey = $"{nameof(GetRecordMateriasById)}:{recordMateriaId}";
            IEnumerable<RecordMateria> results = _cacheProvider.ObjectGet<IList<RecordMateria>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordMaterias.Where(r => r.Id == recordMateriaId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<RecordMateria> GetRecordMateriasByName(string recordMateriaName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordMateriasByName)}");

            string cacheKey = $"{nameof(GetRecordMateriasByName)}:{recordMateriaName}";
            IEnumerable<RecordMateria> results = _cacheProvider.ObjectGet<IList<RecordMateria>>(cacheKey);

            if (results == null)
            {
                results = new List<RecordMateria>();

                if (!String.IsNullOrWhiteSpace(recordMateriaName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().RecordMaterias.Where(e => e.RecordMateriaName.ToLower().Contains(recordMateriaName.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<RecordMateria> GetAllRecordMateriasByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllRecordMateriasByRealm)}");

            string cacheKey = $"{nameof(GetAllRecordMateriasByRealm)}:{realmType}";
            IEnumerable<RecordMateria> results = _cacheProvider.ObjectGet<IList<RecordMateria>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordMaterias.Where(r => r.Realm == realmType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<RecordMateria> GetRecordMateriasByCharacter(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordMateriasByCharacter)}");

            string cacheKey = $"{nameof(GetRecordMateriasByCharacter)}:{characterId}";
            IEnumerable<RecordMateria> results = _cacheProvider.ObjectGet<IList<RecordMateria>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordMaterias.Where(r => r.CharacterId == characterId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<RecordMateria> GetRecordMateriasByEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordMateriasByEffect)}");

            string cacheKey = $"{nameof(GetRecordMateriasByEffect)}:{effectText}";
            IEnumerable<RecordMateria> results = _cacheProvider.ObjectGet<IList<RecordMateria>>(cacheKey);

            if (results == null)
            {
                results = new List<RecordMateria>();

                if (!String.IsNullOrWhiteSpace(effectText))
                {
                    results = _enlirRepository.GetMergeResultsContainer().RecordMaterias.Where(e => e.Effect.ToLower().Contains(effectText.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<RecordMateria> GetRecordMateriasByUnlockCriteria(string unlockText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordMateriasByUnlockCriteria)}");

            string cacheKey = $"{nameof(GetRecordMateriasByUnlockCriteria)}:{unlockText}";
            IEnumerable<RecordMateria> results = _cacheProvider.ObjectGet<IList<RecordMateria>>(cacheKey);

            if (results == null)
            {
                results = new List<RecordMateria>();

                if (!String.IsNullOrWhiteSpace(unlockText))
                {
                    results = _enlirRepository.GetMergeResultsContainer().RecordMaterias.Where(e => e.UnlockCriteria.ToLower().Contains(unlockText.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<RecordMateria> GetRecordMateriasBySearch(RecordMateria searchPrototype)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordMateriasBySearch)}");


            //ignore: Id, Description, LegendMateriaId, JapaneseName, CharacterName, ImagePath, RelicName, IsChecked
            var query = _enlirRepository.GetMergeResultsContainer().RecordMaterias;

            if (searchPrototype.Realm != 0)
            {
                query = query.Where(l => l.Realm == searchPrototype.Realm);
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.RecordMateriaName))
            {
                query = query.Where(l => l.RecordMateriaName.ToLower().Contains(searchPrototype.RecordMateriaName.ToLower()));
            }
            if (searchPrototype.CharacterId != 0)
            {
                query = query.Where(l => l.CharacterId == searchPrototype.CharacterId);
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.Effect))
            {
                query = query.Where(l => l.Effect.ToLower().Contains(searchPrototype.Effect.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.UnlockCriteria))
            {
                query = query.Where(l => l.UnlockCriteria.ToLower().Contains(searchPrototype.UnlockCriteria.ToLower()));
            }

            return query;
        }
        #endregion
    }
}
