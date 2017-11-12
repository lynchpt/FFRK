using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    public class Experience : IModelDescriptor
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public IEnumerable<ExperienceByLevelInfo> GenericCharacterLevelInfo { get; set; }   
        public IEnumerable<ExperienceByLevelInfo> TyroCharacterLevelInfo { get; set; }
        public IEnumerable<ExperienceByLevelInfo> Magicite1StarLevelInfo { get; set; }
        public IEnumerable<ExperienceByLevelInfo> Magicite2StarLevelInfo { get; set; }
        public IEnumerable<ExperienceByLevelInfo> Magicite3StarLevelInfo { get; set; }
        public IEnumerable<ExperienceByLevelInfo> Magicite4StarLevelInfo { get; set; }
        public IEnumerable<ExperienceByLevelInfo> Magicite5StarLevelInfo { get; set; }
        public IEnumerable<ExperienceByLevelInfo> Magicite3StarInheritanceLevelInfo { get; set; }
        public IEnumerable<ExperienceByLevelInfo> Magicite4StarInheritanceLevelInfo { get; set; }
        public IEnumerable<ExperienceByLevelInfo> Magicite5StarInheritanceLevelInfo { get; set; }

    }

    public class ExperienceByLevelInfo
    {
        public int Level { get; set; }

        public int ExperienceNeededToReachLevel { get; set; }

        public int ExperienceNeededToReachNextLevel { get; set; }

    }
}
