using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum MissionColumn
    {
        Type = 0,
        Event = 1,
        Description = 2,
        Reward = 3
    }


    public class MissionRow
    {
        public string Type { get; set; }
        public string Event { get; set; }
        public string Description { get; set; }
        public string Reward { get; set; }
    }
}
