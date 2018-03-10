using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FFRKApi.Api.FFRK.Constants;
using FFRKApi.Logic.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using D = FFRKApi.Dto.Api;
using FFRKApi.Model.EnlirTransform;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IMissionsController
    {
        IActionResult GetAllMissions();
        IActionResult GetMissionsById(int missionId);
        IActionResult GetMissionsByMissionType(int missionType);
        IActionResult GetMissionsByEventId(int eventId);
        IActionResult GetMissionsByDescription(string description);
        IActionResult GetMissionsByReward(string rewardName);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class MissionsController : Controller, IMissionsController
    {
        #region Class Variables

        private readonly IMissionsLogic _missionsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<MissionsController> _logger;
        #endregion

        #region Constructors

        public MissionsController(IMissionsLogic missionsLogic, IMapper mapper, ILogger<MissionsController> logger)
        {
            _missionsLogic = missionsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IMissionsController Implementation

        /// <summary>
        /// Gets all Missions and their associated data.
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of Missions, it is faster to get each individual Mission instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Missions (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Mission&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MissionsRoute_All)]
        [SwaggerOperation(nameof(GetAllMissions))]
        [ProducesResponseType(typeof(IEnumerable<D.Mission>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllMissions()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllMissions)}");

            IEnumerable<Mission> model = _missionsLogic.GetAllMissions();

            IEnumerable<D.Mission> result = _mapper.Map<IEnumerable<D.Mission>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one Mission by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Mission for "Create Shellga"
        /// - You first call /api/v1.0/IdLists/Mission to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Create Shellga" in the IdList (the id is 12 in this case)
        /// - Finally you call this api: api/v1.0/Missions/12
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Missions/12 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="missionId">the integer id for the desired Mission; it can be found in the Mission IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Mission&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MissionsRoute_Id)]
        [SwaggerOperation(nameof(GetMissionsById))]
        [ProducesResponseType(typeof(IEnumerable<D.Mission>), (int)HttpStatusCode.OK)]
        public IActionResult GetMissionsById(int missionId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMissionsById)}");

            IEnumerable<Mission> model = _missionsLogic.GetMissionsById(missionId);

            IEnumerable<D.Mission> result = _mapper.Map<IEnumerable<D.Mission>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Missions that have the specified MissionType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Missions that have the MissionType of "Normal"
        /// - You first call /api/v1.0/TypeLists/MissionType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Normal" in the TypeList (the id is 1 in this case)
        /// - Finally you call this api: api/v1.0/Missions/MissionType/1
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Missions/MissionType/1 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="missionType">the integer id for the desired MissionType; it can be found in the MissionType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Missions&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MissionsRoute_MissionType)]
        [SwaggerOperation(nameof(GetMissionsByMissionType))]
        [ProducesResponseType(typeof(IEnumerable<D.Mission>), (int)HttpStatusCode.OK)]
        public IActionResult GetMissionsByMissionType(int missionType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMissionsByMissionType)}");

            IEnumerable<Mission> model = _missionsLogic.GetMissionsByMissionType(missionType);

            IEnumerable<D.Mission> result = _mapper.Map<IEnumerable<D.Mission>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Missions that associated with the specified Event
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Missions were associated with the "Mired in Crisis" Event
        /// - You first call /api/v1.0/IdLists/Event to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Mired in Crisis" in the IdList (the id is 199 in this case)
        /// - Finally you call this api: api/v1.0/Missions/Event/199
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Missions/Event/199 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="eventId">the integer id for the desired Event that Missions are associated with; it can be found in the Event IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Mission&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MissionsRoute_Event)]
        [SwaggerOperation(nameof(GetMissionsByEventId))]
        [ProducesResponseType(typeof(IEnumerable<D.Mission>), (int)HttpStatusCode.OK)]
        public IActionResult GetMissionsByEventId(int eventId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMissionsByEventId)}");

            IEnumerable<Mission> model = _missionsLogic.GetMissionsByEventId(eventId);

            IEnumerable<D.Mission> result = _mapper.Map<IEnumerable<D.Mission>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Missions whose Description contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Missions with "Create" in their description.
        /// - You can straight away call this api: api/v1.0/Missions/Description/create";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Missions/Description/create (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="description">the string that must be a part of a Mission's description in order for them to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Mission&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MissionsRoute_Description)]
        [SwaggerOperation(nameof(GetMissionsByDescription))]
        [ProducesResponseType(typeof(IEnumerable<D.Mission>), (int)HttpStatusCode.OK)]
        public IActionResult GetMissionsByDescription(string description)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMissionsByDescription)}");

            IEnumerable<Mission> model = _missionsLogic.GetMissionsByDescription(description);

            IEnumerable<D.Mission> result = _mapper.Map<IEnumerable<D.Mission>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Missions whose Reward contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Missions that reward "Dexterity Mote".
        /// - You can straight away call this api: api/v1.0/Missions/Reward/dexterity%20mote";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Missions/Reward/dexterity%20mote (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="rewardName">the string that must be a part of a Mission's reward text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Mission&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MissionsRoute_Reward)]
        [SwaggerOperation(nameof(GetMissionsByReward))]
        [ProducesResponseType(typeof(IEnumerable<D.Mission>), (int)HttpStatusCode.OK)]
        public IActionResult GetMissionsByReward(string rewardName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMissionsByReward)}");

            IEnumerable<Mission> model = _missionsLogic.GetMissionsByReward(rewardName);

            IEnumerable<D.Mission> result = _mapper.Map<IEnumerable<D.Mission>>(model);

            return new ObjectResult(result);
        }
        #endregion
    }
}
