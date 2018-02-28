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
    public interface IRecordSpheresLogic
    {
        IEnumerable<RecordSphere> GetAllRecordSpheres();
        IEnumerable<RecordSphere> GetRecordSpheresById(int recordSphereId);
        IEnumerable<RecordSphere> GetRecordSpheresByRealm(int realmType);
        IEnumerable<RecordSphere> GetRecordSpheresByCharacter(int characterId);
        IEnumerable<RecordSphere> GetRecordSpheresByBenefit(string benefit);
        IEnumerable<RecordSphere> GetLRecordSpheresByRequiredMotes(string moteType1, string moteType2);
        IEnumerable<RecordSphere> GetRecordSpheresBySearch(RecordSphere searchPrototype);
    }

    public class RecordSpheresLogic : IRecordSpheresLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<RecordSpheresLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public RecordSpheresLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<RecordSpheresLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region IRecordSpheresLogic Implementation

        public IEnumerable<RecordSphere> GetAllRecordSpheres()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllRecordSpheres)}");

            string cacheKey = $"{nameof(GetAllRecordSpheres)}";
            IEnumerable<RecordSphere> results = _cacheProvider.ObjectGet<IList<RecordSphere>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordSpheres;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<RecordSphere> GetRecordSpheresById(int recordSphereId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordSpheresById)}");

            string cacheKey = $"{nameof(GetRecordSpheresById)}:{recordSphereId}";
            IEnumerable<RecordSphere> results = _cacheProvider.ObjectGet<IList<RecordSphere>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordSpheres.Where(e => e.Id == recordSphereId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<RecordSphere> GetRecordSpheresByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordSpheresByRealm)}");

            string cacheKey = $"{nameof(GetRecordSpheresByRealm)}:{realmType}";
            IEnumerable<RecordSphere> results = _cacheProvider.ObjectGet<IList<RecordSphere>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordSpheres.Where(e => e.Realm == realmType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<RecordSphere> GetRecordSpheresByCharacter(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordSpheresByCharacter)}");

            string cacheKey = $"{nameof(GetRecordSpheresByCharacter)}:{characterId}";
            IEnumerable<RecordSphere> results = _cacheProvider.ObjectGet<IList<RecordSphere>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordSpheres.Where(e => e.CharacterId == characterId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<RecordSphere> GetRecordSpheresByBenefit(string benefit)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordSpheresByBenefit)}");

            string cacheKey = $"{nameof(GetRecordSpheresByBenefit)}:{benefit}";
            IEnumerable<RecordSphere> results = _cacheProvider.ObjectGet<IList<RecordSphere>>(cacheKey);

            if (results == null)
            {
                results = new List<RecordSphere>();

                if (!String.IsNullOrWhiteSpace(benefit))
                {
                    results = _enlirRepository.GetMergeResultsContainer().RecordSpheres.Where(
                        l => l.RecordSphereLevels.Any(i => i.Benefit.ToLower().Contains(benefit.ToLower())));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<RecordSphere> GetLRecordSpheresByRequiredMotes(string moteType1, string moteType2)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLRecordSpheresByRequiredMotes)}");

            string cacheKey = $"{nameof(GetLRecordSpheresByRequiredMotes)}:{moteType1}:{moteType2}";
            IEnumerable<RecordSphere> results = _cacheProvider.ObjectGet<IList<RecordSphere>>(cacheKey);

            if (results == null)
            {
                results = new List<RecordSphere>();

                if (!String.IsNullOrWhiteSpace(moteType1) && !String.IsNullOrWhiteSpace(moteType2))
                {
                    results = _enlirRepository.GetMergeResultsContainer().RecordSpheres.Where(
                        l => l.RecordSphereLevels.Any(i => i.RequiredMotes.Any(m => m.ItemName.ToLower() == moteType1.ToLower()) &&
                                    l.RecordSphereLevels.Any(j => j.RequiredMotes.Any(m => m.ItemName.ToLower() == moteType2.ToLower())
                                    )));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<RecordSphere> GetRecordSpheresBySearch(RecordSphere searchPrototype)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordSpheresBySearch)}");


            //ignore: all but Realm and Character
            var query = _enlirRepository.GetMergeResultsContainer().RecordSpheres;

            if (searchPrototype.Realm != 0)
            {
                query = query.Where(l => l.Realm == searchPrototype.Realm);
            }
            if (searchPrototype.CharacterId != 0)
            {
                query = query.Where(l => l.CharacterId == searchPrototype.CharacterId);
            }
            if (searchPrototype.RecordSphereLevels != null && searchPrototype.RecordSphereLevels.Any() && !String.IsNullOrWhiteSpace(searchPrototype.RecordSphereLevels.First().Benefit))
            {
                query = query.Where(
                    l => l.RecordSphereLevels.Any(i => i.Benefit.ToLower().Contains(searchPrototype.RecordSphereLevels.First().Benefit.ToLower())));
            }

            return query;
        }

        #endregion
    }
}
