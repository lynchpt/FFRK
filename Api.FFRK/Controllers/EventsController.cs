using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FFRKApi.Api.FFRK.Constants;
using FFRKApi.Logic.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;
using D = FFRKApi.Dto.Api;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IEventsController
    {
        IActionResult GetAllEvents();
        IActionResult GetEventsById(int eventId);
        IActionResult GetEventsByName(string eventName);
        IActionResult GetEventsByRealm(int realmType);
        IActionResult GetEventsByEventType(int eventType);
        IActionResult GetEventsByHeroRecords(string characterName);
        IActionResult GetEventsByMemoryCrystal1(string characterName);
        IActionResult GetEventsByMemoryCrystal2(string characterName);
        IActionResult GetEventsByMemoryCrystal3(string characterName);
        IActionResult GetEventsBySoulOfHero();
        IActionResult GetEventsByMemoryLode1();
        IActionResult GetEventsByMemoryLode2();
        IActionResult GetEventsByMemoryLode3();
        IActionResult GetEventsByWardrobeRecord(string characterName);
        IActionResult GetEventsByAbilities(string chaabilityNameracterName);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class EventsController : Controller, IEventsController
    {
        #region Class Variables

        private readonly IEventsLogic _eventsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<EventsController> _logger;
        #endregion

        #region Constructors

        public EventsController(IEventsLogic eventsLogic, IMapper mapper, ILogger<EventsController> logger)
        {
            _eventsLogic = eventsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IEventsController Implementation

        [HttpGet]
        [Route(RouteConstants.EventsRoute_All)]
        [SwaggerOperation(nameof(GetAllEvents))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllEvents()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllEvents)}");

            IEnumerable<Event> model = _eventsLogic.GetAllEvents();

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.EventsRoute_Id)]
        [SwaggerOperation(nameof(GetEventsById))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventsById(int eventId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventsById)}");

            IEnumerable<Event> model = _eventsLogic.GetEventsById(eventId);

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.EventsRoute_Name)]
        [SwaggerOperation(nameof(GetEventsByName))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventsByName(string eventName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventsByName)}");

            IEnumerable<Event> model = _eventsLogic.GetEventsByName(eventName);

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.EventsRoute_RealmType)]
        [SwaggerOperation(nameof(GetEventsByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventsByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventsByRealm)}");

            IEnumerable<Event> model = _eventsLogic.GetEventsByRealm(realmType);

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.EventsRoute_EventType)]
        [SwaggerOperation(nameof(GetEventsByEventType))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventsByEventType(int eventType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventsByEventType)}");

            IEnumerable<Event> model = _eventsLogic.GetEventsByEventType(eventType);

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.EventsRoute_HeroRecords)]
        [SwaggerOperation(nameof(GetEventsByHeroRecords))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventsByHeroRecords(string characterName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventsByHeroRecords)}");

            IEnumerable<Event> model = _eventsLogic.GetEventsByHeroRecords(characterName);

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.EventsRoute_MemoryCrystal1)]
        [SwaggerOperation(nameof(GetEventsByMemoryCrystal1))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventsByMemoryCrystal1(string characterName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventsByMemoryCrystal1)}");

            IEnumerable<Event> model = _eventsLogic.GetEventsByMemoryCrystal1(characterName);

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.EventsRoute_MemoryCrystal2)]
        [SwaggerOperation(nameof(GetEventsByMemoryCrystal2))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventsByMemoryCrystal2(string characterName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventsByMemoryCrystal2)}");

            IEnumerable<Event> model = _eventsLogic.GetEventsByMemoryCrystal2(characterName);

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.EventsRoute_MemoryCrystal3)]
        [SwaggerOperation(nameof(GetEventsByMemoryCrystal3))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventsByMemoryCrystal3(string characterName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventsByMemoryCrystal3)}");

            IEnumerable<Event> model = _eventsLogic.GetEventsByMemoryCrystal3(characterName);

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.EventsRoute_SoulOfHero)]
        [SwaggerOperation(nameof(GetEventsBySoulOfHero))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventsBySoulOfHero()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventsBySoulOfHero)}");

            IEnumerable<Event> model = _eventsLogic.GetEventsBySoulOfHero();

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.EventsRoute_MemoryLode1)]
        [SwaggerOperation(nameof(GetEventsByMemoryLode1))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventsByMemoryLode1()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventsByMemoryLode1)}");

            IEnumerable<Event> model = _eventsLogic.GetEventsByMemoryLode1();

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.EventsRoute_MemoryLode2)]
        [SwaggerOperation(nameof(GetEventsByMemoryLode2))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventsByMemoryLode2()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventsByMemoryLode2)}");

            IEnumerable<Event> model = _eventsLogic.GetEventsByMemoryLode2();

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.EventsRoute_MemoryLode3)]
        [SwaggerOperation(nameof(GetEventsByMemoryLode3))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventsByMemoryLode3()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventsByMemoryLode3)}");

            IEnumerable<Event> model = _eventsLogic.GetEventsByMemoryLode3();

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.EventsRoute_WardrobeRecord)]
        [SwaggerOperation(nameof(GetEventsByWardrobeRecord))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventsByWardrobeRecord(string characterName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventsByWardrobeRecord)}");

            IEnumerable<Event> model = _eventsLogic.GetEventsByWardrobeRecord(characterName);

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.EventsRoute_Abilities)]
        [SwaggerOperation(nameof(GetEventsByAbilities))]
        [ProducesResponseType(typeof(IEnumerable<D.Event>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventsByAbilities(string abilityName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventsByAbilities)}");

            IEnumerable<Event> model = _eventsLogic.GetEventsByAbilities(abilityName);

            IEnumerable<D.Event> result = _mapper.Map<IEnumerable<D.Event>>(model);

            return new ObjectResult(result);
        }

        #endregion
    }
}
