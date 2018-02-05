using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    public class Mission: IModelDescriptor
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; } 
        #endregion

        public int MissionType { get; set; }
        public string AssociatedEvent { get; set; }
        public int AssociatedEventId { get; set; }
        public IEnumerable<ItemWithCountAndStarLevel> Rewards { get; set; }
    }


}
