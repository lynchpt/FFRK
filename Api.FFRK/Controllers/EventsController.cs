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

        /// <summary>
        /// Gets all Events and their associated data.
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of Events, it is faster to get each individual Event instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Dungeons (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets one Event by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Event named "To Slay a Sorceress"
        /// - You first call /api/v1.0/IdLists/Event to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "To Slay a Sorceress" in the IdList (the id is 10 in this case)
        /// - Finally you call this api: api/v1.0/Events/10
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Events/10 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="eventId">the integer id for the desired Event; it can be found in the Event IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Events whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Dungeons with "Reborn" in their name.
        /// - You can straight away call this api: api/v1.0/Events/Name/reborn";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Events/Name/reborn (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="eventName">the string that must be a part of a Events's name in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Events that belong to the specified Realm
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Events in the Realm of FF VI
        /// - You first call /api/v1.0/TypeLists/RealmType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "VI" in the IdList (the id is 6 in this case)
        /// - Finally you call this api: api/v1.0/Events/RealmType/6
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Events/RealmType/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="realmType">the integer id for the desired Realm; it can be found in the RealmType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Events that have the specified EventType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Events that have the EventType of "Challenge Event"
        /// - You first call /api/v1.0/TypeLists/EventType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Challenge Event" in the TypeList (the id is 1 in this case)
        /// - Finally you call this api: api/v1.0/Events/EventType/1
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Events/EventType/1 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="eventType">the integer id for the desired EventType; it can be found in the EventType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Events that reward Hero Records for Characters whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Events that reward Hero Records for a Character whose name includes "Cid".
        /// - You can straight away call this api: api/v1.0/Events/HeroRecords/cid";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Events/HeroRecords/cid (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterName">the string that must be a part of a Character's name that has a Hero Record rewarded in an Event for that Event to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Events that reward Memory Crystal 1 for Characters whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Events that reward Memory Crystal 1 for a Character whose name includes "Cid".
        /// - You can straight away call this api: api/v1.0/Events/MemoryCrystal1/cid";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Events/MemoryCrystal1/cid (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterName">the string that must be a part of a Character's name that has a Memory Crystal 1 rewarded in an Event for that Event to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Events that reward Memory Crystal 2 for Characters whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Events that reward Memory Crystal 2 for a Character whose name includes "Cid".
        /// - You can straight away call this api: api/v1.0/Events/MemoryCrystal2/cid";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Events/MemoryCrystal2/cid (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterName">the string that must be a part of a Character's name that has a Memory Crystal 2 rewarded in an Event for that Event to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Events that reward Memory Crystal 3 for Characters whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Events that reward Memory Crystal 2 for a Character whose name includes "Cid".
        /// - You can straight away call this api: api/v1.0/Events/MemoryCrystal3/cid";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Events/MemoryCrystal3/cid (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterName">the string that must be a part of a Character's name that has a Memory Crystal 3 rewarded in an Event for that Event to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Events that reward a Soul of Hero
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Events that reward a Soul of Hero.
        /// - You can straight away call this api: api/v1.0/Events/SoulOfHero";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Events/SoulOfHero (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Events that reward a Memory Lode 1
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Events that reward a Memory Lode 1.
        /// - You can straight away call this api: api/v1.0/Events/MemoryLode1";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Events/MemoryLode1 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Events that reward a Memory Lode 2
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Events that reward a Memory Lode 2.
        /// - You can straight away call this api: api/v1.0/Events/MemoryLode2";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Events/MemoryLode2 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Events that reward a Memory Lode 3
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Events that reward a Memory Lode 3.
        /// - You can straight away call this api: api/v1.0/Events/MemoryLode3";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Events/MemoryLode3 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Events that reward Wardrobe Records for Characters whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Events that reward Wardrobe Records for an Event whose name includes "Cid".
        /// - You can straight away call this api: api/v1.0/Events/WardrobeRecord/cid";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Events/WardrobeRecord/cid (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterName">the string that must be a part of a Character's name that has a Wardrobe Record rewarded in an Event for that Event to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Events that reward Abilities whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Events that reward Abilities whose name includes "Fir".
        /// - You can straight away call this api: api/v1.0/Events/Abilities/fir";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Events/Abilities/fir (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="abilityName">the string that must be a part of an Ability's name that is awarded in an Event for that Event to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Event&gt;</see>
        /// </response>
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
