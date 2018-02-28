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
    public interface IEventsLogic
    {

        IEnumerable<Event> GetAllEvents();
        IEnumerable<Event> GetEventsById(int eventId);
        IEnumerable<Event> GetEventsByName(string eventName);
        IEnumerable<Event> GetEventsByRealm(int realmType);
        IEnumerable<Event> GetEventsByEventType(int eventType);
        IEnumerable<Event> GetEventsByHeroRecords(string characterName);
        IEnumerable<Event> GetEventsByMemoryCrystal1(string characterName);
        IEnumerable<Event> GetEventsByMemoryCrystal2(string characterName);
        IEnumerable<Event> GetEventsByMemoryCrystal3(string characterName);
        IEnumerable<Event> GetEventsBySoulOfHero();
        IEnumerable<Event> GetEventsByMemoryLode1();
        IEnumerable<Event> GetEventsByMemoryLode2();
        IEnumerable<Event> GetEventsByMemoryLode3();
        IEnumerable<Event> GetEventsByWardrobeRecord(string characterName);
        IEnumerable<Event> GetEventsByAbilities(string abilityName);

    }

    public class EventsLogic : IEventsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<EventsLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public EventsLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<EventsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region IEventsLogic Implementation

        public IEnumerable<Event> GetAllEvents()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllEvents)}");

            string cacheKey = $"{nameof(GetAllEvents)}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Events;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Event> GetEventsById(int eventId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsById)}");

            string cacheKey = $"{nameof(GetEventsById)}:{eventId}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.Id == eventId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByName(string eventName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByName)}");

            string cacheKey = $"{nameof(GetEventsByName)}:{eventName}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = new List<Event>();

                if (!String.IsNullOrWhiteSpace(eventName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.EventName.ToLower().Contains(eventName.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByRealm)}");

            string cacheKey = $"{nameof(GetEventsByRealm)}:{realmType}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.RealmId == realmType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByEventType(int eventType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByEventType)}");

            string cacheKey = $"{nameof(GetEventsByEventType)}:{eventType}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.EventTypeId == eventType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByHeroRecords(string characterName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByHeroRecords)}");

            string cacheKey = $"{nameof(GetEventsByHeroRecords)}:{characterName}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = new List<Event>();

                if (!String.IsNullOrWhiteSpace(characterName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.HeroRecordsAwarded.Any(wr => wr.ToLower().Contains(characterName.ToLower())));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByMemoryCrystal1(string characterName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByMemoryCrystal1)}");

            string cacheKey = $"{nameof(GetEventsByMemoryCrystal1)}:{characterName}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = new List<Event>();

                if (!String.IsNullOrWhiteSpace(characterName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.MemoryCrystalsLevel1Awarded.Any(wr => wr.ToLower().Contains(characterName.ToLower())));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByMemoryCrystal2(string characterName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByMemoryCrystal2)}");

            string cacheKey = $"{nameof(GetEventsByMemoryCrystal2)}:{characterName}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = new List<Event>();

                if (!String.IsNullOrWhiteSpace(characterName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.MemoryCrystalsLevel2Awarded.Any(wr => wr.ToLower().Contains(characterName.ToLower())));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByMemoryCrystal3(string characterName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByMemoryCrystal3)}");

            string cacheKey = $"{nameof(GetEventsByMemoryCrystal3)}:{characterName}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = new List<Event>();

                if (!String.IsNullOrWhiteSpace(characterName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.MemoryCrystalsLevel3Awarded.Any(wr => wr.ToLower().Contains(characterName.ToLower())));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Event> GetEventsBySoulOfHero()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsBySoulOfHero)}");

            string cacheKey = $"{nameof(GetEventsBySoulOfHero)}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.SoulOfHerosAwarded > 0);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByMemoryLode1()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByMemoryLode1)}");

            string cacheKey = $"{nameof(GetEventsByMemoryLode1)}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.MemoryCrystalLodesLevel1Awarded > 0);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByMemoryLode2()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByMemoryLode2)}");

            string cacheKey = $"{nameof(GetEventsByMemoryLode2)}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.MemoryCrystalLodesLevel2Awarded > 0);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByMemoryLode3()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByMemoryLode3)}");

            string cacheKey = $"{nameof(GetEventsByMemoryLode3)}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.MemoryCrystalLodesLevel3Awarded > 0);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByWardrobeRecord(string characterName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByWardrobeRecord)}");

            string cacheKey = $"{nameof(GetEventsByWardrobeRecord)}:{characterName}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = new List<Event>();

                if (!String.IsNullOrWhiteSpace(characterName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.WardrobeRecordsAwarded.Any(wr => wr.ToLower().Contains(characterName.ToLower())));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByAbilities(string abilityName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByAbilities)}");

            string cacheKey = $"{nameof(GetEventsByAbilities)}:{abilityName}";
            IEnumerable<Event> results = _cacheProvider.ObjectGet<IList<Event>>(cacheKey);

            if (results == null)
            {
                results = new List<Event>();

                if (!String.IsNullOrWhiteSpace(abilityName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.AbilitiesAwarded.Any(wr => wr.ToLower().Contains(abilityName.ToLower())));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;        
        }
        #endregion
    }
}
