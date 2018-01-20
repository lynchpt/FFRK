using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.Api
{
    public class TypeListBundle
    {
        public IEnumerable<KeyValuePair<int, string>> AbilityType { get; set; }
        public IEnumerable<KeyValuePair<int, string>> AutoTargetType { get; set; }
        public IEnumerable<KeyValuePair<int, string>> DamageFormulaType { get; set; }
        public IEnumerable<KeyValuePair<int, string>> ElementType { get; set; }
        public IEnumerable<KeyValuePair<int, string>> EquipmentType { get; set; }
        public IEnumerable<KeyValuePair<int, string>> EventType { get; set; }
        public IEnumerable<KeyValuePair<int, string>> MissionType { get; set; }
        public IEnumerable<KeyValuePair<int, string>> OrbType { get; set; }
        public IEnumerable<KeyValuePair<int, string>> RealmType { get; set; }
        public IEnumerable<KeyValuePair<int, string>> RelicType { get; set; }
        public IEnumerable<KeyValuePair<int, string>> SchoolType { get; set; }
        public IEnumerable<KeyValuePair<int, string>> SoulBreakTierType { get; set; }
        public IEnumerable<KeyValuePair<int, string>> TargetType { get; set; }
    }
}
