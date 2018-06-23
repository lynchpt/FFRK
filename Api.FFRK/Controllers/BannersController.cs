using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FFRKApi.Api.FFRK.Constants;
using FFRKApi.Logic.Api.Banners;
using FFRKApi.Model.Api.Banners;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;
using D = FFRKApi.Dto.Api.Banners;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IBannersController
    {
        IActionResult GetPullResultsData(string bannerId);
        IActionResult GetPullResultsTable(string bannerId);
    }

    [Route(RouteConstants.BaseRoute)]
    public class BannersController: Controller, IBannersController
    {
        #region Class Variables

        private readonly IBannersLogic _bannersLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<BannersController> _logger;
        #endregion

        #region Constructors

        public BannersController(IBannersLogic bannersLogic, IMapper mapper, ILogger<BannersController> logger)
        {
            _bannersLogic = bannersLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion


        /// <summary>
        /// returns the result of a single 11 pull on the specified banner 
        /// </summary>
        /// <remarks>
        /// The banner structure and contents are predefined and associated to an id for convenient invocation
        /// 
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Banners/PullResults/1 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;PullResultRow&gt;</see>
        /// </response>
        [HttpGet]
        [Produces(RouteConstants.ContentType_ApplicationJson)]
        [Route(RouteConstants.BannersRoute_PullResults)]
        [SwaggerOperation(nameof(GetPullResultsData))]
        [ProducesResponseType(typeof(IEnumerable<Dto.Api.Banners.PullResultRow>), (int)HttpStatusCode.OK)]
        public IActionResult GetPullResultsData(string bannerId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetPullResultsData)}");

            IEnumerable<PullResultRow> model = _bannersLogic.GetPullResults(bannerId);

            IEnumerable<D.PullResultRow> result = _mapper.Map<IEnumerable<D.PullResultRow>>(model);

            return new ObjectResult(result);
        }
   

        /// <summary>
        /// returns the result of a single 11 pull on the specified banner 
        /// </summary>
        /// <remarks>
        /// The banner structure and contents are predefined and associated to an id for convenient invocation
        /// 
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Banners/PullResults/1 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;PullResultRow&gt;</see>
        /// </response>
        [HttpGet]
        [Produces("text/html")]
        [Route(RouteConstants.BannersRoute_PullResultsTable)]
        [SwaggerOperation(nameof(GetPullResultsTable))]
        //[ProducesResponseType(typeof(IEnumerable<Dto.Api.Banners.PullResultRow>), (int)HttpStatusCode.OK)]
        public IActionResult GetPullResultsTable(string bannerId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetPullResultsTable)}");

            IEnumerable<PullResultRow> model = _bannersLogic.GetPullResults(bannerId);

            IEnumerable<D.PullResultRow> result = _mapper.Map<IEnumerable<D.PullResultRow>>(model);
            string table = String.Empty;
            


            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<html><body><table style='width:25%'>");
            builder.AppendLine("<tr><th align=left>Relic</th><th align=left>Character</th><th align=left>Type</th><th align=left># Pulled</th></tr>");

            foreach (var item in result)
            {
                builder.AppendLine($"<tr><td>{item.RelicName}</td><td>{item.CharacterName}</td><td>{item.SoulBreakTierName}</td><td>{item.SelectedCount}</td></tr>");
            }

            builder.AppendLine("</table></body></html>");

            table = builder.ToString();

            ContentResult html = new ContentResult();
            html.Content = table;
            html.ContentType = "text/html";
            html.StatusCode = 200;

            return html;

        }
    }
}
