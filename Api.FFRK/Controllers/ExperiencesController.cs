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
using Swashbuckle.AspNetCore.SwaggerGen;
using FFRKApi.Model.EnlirTransform;
using D = FFRKApi.Dto.Api;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IExperiencesController
    {
        IActionResult GetAllExperiences();
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class ExperiencesController : Controller, IExperiencesController
    {
        #region Class Variables

        private readonly IExperiencesLogic _experiencesLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<ExperiencesController> _logger;
        #endregion

        #region Constructors

        public ExperiencesController(IExperiencesLogic experiencesLogic, IMapper mapper, ILogger<ExperiencesController> logger)
        {
            _experiencesLogic = experiencesLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IExperiencesController Implementation

        [HttpGet]
        [Route(RouteConstants.EventsRoute_All)]
        [SwaggerOperation(nameof(GetAllExperiences))]
        [ProducesResponseType(typeof(IEnumerable<D.Experience>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllExperiences()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllExperiences)}");

            IEnumerable<Experience> model = _experiencesLogic.GetAllExperiences();

            IEnumerable<D.Experience> result = _mapper.Map<IEnumerable<D.Experience>>(model);

            return new ObjectResult(result);
        }
        #endregion


    }
}
