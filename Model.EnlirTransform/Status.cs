using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    public class Status : IModelDescriptor
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public int StatusId { get; set; }
        public string CommonName { get; set; }
        public string Effects { get; set; }
        public int DefaultDuration { get; set; }
        public double MindModifier { get; set; }
        public IEnumerable<string> ExclusiveStatuses { get; set; }
        public string CodedName { get; set; }
        public string Notes { get; set; }
    }
}
