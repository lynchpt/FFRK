using System.Collections.Generic;

namespace FFRKApi.Dto.Api
{
    public class Mission
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; } 
        #endregion

        public string MissionType { get; set; }
        public string AssociatedEvent { get; set; }
        public IEnumerable<ItemWithCountAndStarLevel> Rewards { get; set; }
    }


}
