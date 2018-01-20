﻿using System.Collections.Generic;

namespace FFRKApi.Dto.Api
{
    public class RecordSphere
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public string RecordSphereName { get; set; }

        public string CharacterName { get; set; }
        public int CharacterId { get; set; } //filled in during merge phase
        public int Realm { get; set; }

        public string RecordSpherePrerequisites { get; set; }

        public IEnumerable<RecordSphereLevel> RecordSphereLevels { get; set; } 
}

    public class RecordSphereLevel
    {
        public int Level { get; set; }
        public string Benefit { get; set; }

        public IList<ItemWithCountAndStarLevel> RequiredMotes { get; set; }
    }
}
