using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
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
        #endregion

        #region Constructors

        public EventsLogic(IEnlirRepository enlirRepository, ILogger<EventsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IEventsLogic Implementation

        public IEnumerable<Event> GetAllEvents()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllEvents)}");

            return _enlirRepository.GetMergeResultsContainer().Events;
        }

        public IEnumerable<Event> GetEventsById(int eventId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsById)}");

            return _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.Id == eventId);
        }

        public IEnumerable<Event> GetEventsByName(string eventName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByName)}");

            IEnumerable<Event> results = new List<Event>();

            if (!String.IsNullOrWhiteSpace(eventName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.EventName.ToLower().Contains(eventName.ToLower()));
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByRealm)}");

            return _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.RealmId == realmType);
        }

        public IEnumerable<Event> GetEventsByEventType(int eventType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByEventType)}");

            return _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.EventTypeId == eventType);
        }

        public IEnumerable<Event> GetEventsByHeroRecords(string characterName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByHeroRecords)}");

            IEnumerable<Event> results = new List<Event>();

            if (!String.IsNullOrWhiteSpace(characterName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.HeroRecordsAwarded.Any(wr => wr.ToLower().Contains(characterName.ToLower())));
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByMemoryCrystal1(string characterName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByMemoryCrystal1)}");

            IEnumerable<Event> results = new List<Event>();

            if (!String.IsNullOrWhiteSpace(characterName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.MemoryCrystalsLevel1Awarded.Any(wr => wr.ToLower().Contains(characterName.ToLower())));
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByMemoryCrystal2(string characterName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByMemoryCrystal2)}");

            IEnumerable<Event> results = new List<Event>();

            if (!String.IsNullOrWhiteSpace(characterName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.MemoryCrystalsLevel2Awarded.Any(wr => wr.ToLower().Contains(characterName.ToLower())));
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByMemoryCrystal3(string characterName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByMemoryCrystal3)}");

            IEnumerable<Event> results = new List<Event>();

            if (!String.IsNullOrWhiteSpace(characterName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.MemoryCrystalsLevel3Awarded.Any(wr => wr.ToLower().Contains(characterName.ToLower())));
            }

            return results;
        }

        public IEnumerable<Event> GetEventsBySoulOfHero()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsBySoulOfHero)}");

            return _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.SoulOfHerosAwarded > 0);
        }

        public IEnumerable<Event> GetEventsByMemoryLode1()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByMemoryLode1)}");

            return _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.MemoryCrystalLodesLevel1Awarded > 0);
        }

        public IEnumerable<Event> GetEventsByMemoryLode2()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByMemoryLode2)}");

            return _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.MemoryCrystalLodesLevel2Awarded > 0);
        }

        public IEnumerable<Event> GetEventsByMemoryLode3()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByMemoryLode3)}");

            return _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.MemoryCrystalLodesLevel3Awarded > 0);
        }

        public IEnumerable<Event> GetEventsByWardrobeRecord(string characterName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByWardrobeRecord)}");

            IEnumerable<Event> results = new List<Event>();

            if (!String.IsNullOrWhiteSpace(characterName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.WardrobeRecordsAwarded.Any(wr => wr.ToLower().Contains(characterName.ToLower())));
            }

            return results;
        }

        public IEnumerable<Event> GetEventsByAbilities(string abilityName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventsByAbilities)}");

            IEnumerable<Event> results = new List<Event>();

            if (!String.IsNullOrWhiteSpace(abilityName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Events.Where(e => e.AbilitiesAwarded.Any(wr => wr.ToLower().Contains(abilityName.ToLower())));
            }

            return results;
        }
        #endregion
    }
}
