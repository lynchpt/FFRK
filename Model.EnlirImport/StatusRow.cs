using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum StatusColumn
    {
        ID = 0,
        CommonName = 1,
        Effects = 2,
        DefaultDuration = 3,
        MindModifier = 4,
        ExclusiveStatus = 5,
        CodedName = 6,
        Notes = 7
    }

    public class StatusRow
    {
        public string ID { get; set; }
        public string CommonName { get; set; }
        public string Effects { get; set; }
        public string DefaultDuration { get; set; }
        public string MindModifier { get; set; }
        public string ExclusiveStatus { get; set; }
        public string CodedName { get; set; }
        public string Notes { get; set; }
    }
}
