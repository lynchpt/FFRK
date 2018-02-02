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
        IActionResult GetMissionsByMissionType(string missionType); //todo change to int
        IActionResult GetMissionsByEventId(string eventId); //todo change to int
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
        [SwaggerOperation(nameof(GetMissionsById))]
        [ProducesResponseType(typeof(IEnumerable<D.Mission>), (int)HttpStatusCode.OK)]
        public IActionResult GetMissionsById(int missionId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMissionsById)}");

            IEnumerable<Mission> model = _missionsLogic.GetMissionsById(missionId);

            IEnumerable<D.Mission> result = _mapper.Map<IEnumerable<D.Mission>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MissionsRoute_MissionType)]
        [SwaggerOperation(nameof(GetMissionsByMissionType))]
        [ProducesResponseType(typeof(IEnumerable<D.Mission>), (int)HttpStatusCode.OK)]
        public IActionResult GetMissionsByMissionType(string missionType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMissionsByMissionType)}");

            IEnumerable<Mission> model = _missionsLogic.GetMissionsByMissionType(missionType);

            IEnumerable<D.Mission> result = _mapper.Map<IEnumerable<D.Mission>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MissionsRoute_Event)]
        [SwaggerOperation(nameof(GetMissionsByEventId))]
        [ProducesResponseType(typeof(IEnumerable<D.Mission>), (int)HttpStatusCode.OK)]
        public IActionResult GetMissionsByEventId(string eventId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMissionsByEventId)}");

            IEnumerable<Mission> model = _missionsLogic.GetMissionsByEventId(eventId);

            IEnumerable<D.Mission> result = _mapper.Map<IEnumerable<D.Mission>>(model);

            return new ObjectResult(result);
        }

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
