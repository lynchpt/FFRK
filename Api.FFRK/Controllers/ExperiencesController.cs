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

        /// <summary>
        /// Gets all (there is only one) Experience records.
        /// </summary>
        /// <remarks>
        /// Use Case - There is only one experience record because it contains the entire experience table from Enlir showing 
        /// you how much experience is required to level up Tyro, All other characters (as a group), and Magicites.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Experiences (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Experience&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.ExperiencesRoute_All)]
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
