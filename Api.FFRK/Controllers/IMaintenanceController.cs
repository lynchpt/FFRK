using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFRKApi.Model.EnlirMerge;
using Microsoft.AspNetCore.Mvc;

namespace Api.FFRK.Controllers
{
    public interface IMaintenanceController
    {
        IActionResult LoadLatestMergeResultsContainer();
    }
}
