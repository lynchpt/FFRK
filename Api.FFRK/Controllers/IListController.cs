using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IListController
    {
        IList<KeyValuePair<int, string>> GetAbilityTypeList();
    }
}
