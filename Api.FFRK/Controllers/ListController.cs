using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFRKApi.Logic.Api;
using Microsoft.AspNetCore.Mvc;

namespace FFRKApi.Api.FFRK.Controllers
{
    [Produces("application/json")]
    [Route("api/Lists")]
    public class ListController : Controller, IListController
    {
        #region Class Variables

        private readonly IListLogic _listLogic;
        #endregion

        #region Constructors

        public ListController(IListLogic listLogic)
        {
            _listLogic = listLogic;
        }
        #endregion

        [Route("AbilityType")]
        public IList<KeyValuePair<int, string>> GetAbilityTypeList()
        {
            return _listLogic.GetAbilityTypeList();
        }
    }
}
