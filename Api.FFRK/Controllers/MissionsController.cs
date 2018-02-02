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
        IActionResult GetAllMissionsById(int missionId);
        IActionResult GetAllMissionsByMissionType(string missionType); //todo change to int
        IActionResult GetAllMissionsByEventId(string eventId); //todo change to int
        IActionResult GetAllMissionsByDescription(string description);
        IActionResult GetAllMissionsByReward(string rewardName);
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

        [HttpGet]
        [Route(RouteConstants.MissionsRoute_Id)]
        [SwaggerOperation(nameof(GetAllMissionsById))]
        [ProducesResponseType(typeof(IEnumerable<D.Mission>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllMissionsById(int missionId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllMissionsById)}");

            IEnumerable<Mission> model = _missionsLogic.GetAllMissionsById(missionId);

            IEnumerable<D.Mission> result = _mapper.Map<IEnumerable<D.Mission>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MissionsRoute_MissionType)]
        [SwaggerOperation(nameof(GetAllMissionsByMissionType))]
        [ProducesResponseType(typeof(IEnumerable<D.Mission>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllMissionsByMissionType(string missionType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllMissionsByMissionType)}");

            IEnumerable<Mission> model = _missionsLogic.GetAllMissionsByMissionType(missionType);

            IEnumerable<D.Mission> result = _mapper.Map<IEnumerable<D.Mission>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MissionsRoute_Event)]
        [SwaggerOperation(nameof(GetAllMissionsByEventId))]
        [ProducesResponseType(typeof(IEnumerable<D.Mission>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllMissionsByEventId(string eventId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllMissionsByEventId)}");

            IEnumerable<Mission> model = _missionsLogic.GetAllMissionsByEventId(eventId);

            IEnumerable<D.Mission> result = _mapper.Map<IEnumerable<D.Mission>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MissionsRoute_Description)]
        [SwaggerOperation(nameof(GetAllMissionsByDescription))]
        [ProducesResponseType(typeof(IEnumerable<D.Mission>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllMissionsByDescription(string description)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllMissionsByDescription)}");

            IEnumerable<Mission> model = _missionsLogic.GetAllMissionsByDescription(description);

            IEnumerable<D.Mission> result = _mapper.Map<IEnumerable<D.Mission>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MissionsRoute_Reward)]
        [SwaggerOperation(nameof(GetAllMissionsByReward))]
        [ProducesResponseType(typeof(IEnumerable<D.Mission>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllMissionsByReward(string rewardName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllMissionsByReward)}");

            IEnumerable<Mission> model = _missionsLogic.GetAllMissionsByReward(rewardName);

            IEnumerable<D.Mission> result = _mapper.Map<IEnumerable<D.Mission>>(model);

            return new ObjectResult(result);
        }
        #endregion
    }
}
