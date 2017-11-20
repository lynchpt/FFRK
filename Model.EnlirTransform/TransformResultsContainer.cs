using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    public class TransformResultsContainer
    {
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Mission> Missions { get; set; }
        public IEnumerable<Experience> Experiences { get; set; }

        public IEnumerable<MagiciteSkill> MagiciteSkills { get; set; }

        public IEnumerable<Magicite> Magicites { get; set; }
    }
}
