using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFRKApi.Api.FFRK.Constants
{
    public class RouteConstants
    {
        public const string ContentType_ApplicationJson = "application/json";

        public const string BaseRoute = "api/v1.0/[controller]"; //to handle versioning

        //IdList Routes
        public const string IdListsRoute_AbilityType = "AbilityType";



        //Maintenance Routes
        public const string MaintenanceRoute_DataStatus = "DataStatus";
    }
}
