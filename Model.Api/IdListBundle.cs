using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.Api
{
    public class IdListBundle
    {
        public IEnumerable<KeyValuePair<int, string>> Ability { get; set; }
        public IEnumerable<KeyValuePair<int, string>> Character { get; set; }
        public IEnumerable<KeyValuePair<int, string>> Command { get; set; }
        public IEnumerable<KeyValuePair<int, string>> Dungeon { get; set; }
        public IEnumerable<KeyValuePair<int, string>> Event { get; set; }
        public IEnumerable<KeyValuePair<int, string>> Experience { get; set; }
        public IEnumerable<KeyValuePair<int, string>> LegendMateria { get; set; }
        public IEnumerable<KeyValuePair<int, string>> LegendSphere { get; set; }
        public IEnumerable<KeyValuePair<int, string>> Magicite { get; set; }
        public IEnumerable<KeyValuePair<int, string>> MagiciteSkill { get; set; }
        public IEnumerable<KeyValuePair<int, string>> Mission { get; set; }
        public IEnumerable<KeyValuePair<int, string>> Other { get; set; }
        public IEnumerable<KeyValuePair<int, string>> RecordMateria { get; set; }
        public IEnumerable<KeyValuePair<int, string>> RecordSphere { get; set; }
        public IEnumerable<KeyValuePair<int, string>> Relic { get; set; }
        public IEnumerable<KeyValuePair<int, string>> SoulBreak { get; set; }
        public IEnumerable<KeyValuePair<int, string>> Status { get; set; }
    }
}
