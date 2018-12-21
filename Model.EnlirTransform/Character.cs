using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    public class Character : IModelDescriptor
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public string CharacterName { get; set; }

        public int Realm { get; set; }

        public IEnumerable<Relic> Relics { get; set; } //filled in during merge phase
        public IEnumerable<RecordSphere> RecordSpheres { get; set; } //filled in during merge phase
        public IEnumerable<LegendSphere> LegendSpheres { get; set; } //filled in during merge phase

        public IEnumerable<RecordMateria> RecordMaterias { get; set; } //filled in during merge phase
        public IEnumerable<LegendMateria> LegendMaterias { get; set; } //filled in during merge phase

        public IEnumerable<StatsByLevelInfo> StatsByLevelInfos { get; set; }

        public StatsByLevelInfo StatIncrementsForRecordSpheres { get; set; }

        public StatsByLevelInfo StatIncrementsForLegendSpheres { get; set; }

        public IEnumerable<SchoolAccessInfo> SchoolAccessInfos { get; set; }

        public IEnumerable<EquipmentAccessInfo> EquipmentAccessInfos { get; set; }

        public string EnlirId { get; set; }
    }

    public class StatsByLevelInfo
    {
        public int Level { get; set; }

        public string IntroducingEvent { get; set; }
        public int IntroducingEventId { get; set; } //filled in during merge phase

        public int HitPoints { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Magic { get; set; }
        public int Resistance { get; set; }
        public int Mind { get; set; }
        public int Accuracy { get; set; }
        public int Evasion { get; set; }
        public int Speed { get; set; }
    }

    public class SchoolAccessInfo
    {
        public int School { get; set; }
        public string SchoolName { get; set; }
        public int AccessLevel { get; set; }
    }

    public class EquipmentAccessInfo
    {
        public int EquipmentType { get; set; }
        public string EquipmentName { get; set; }
        public bool IsWeapon { get; set; }
        public bool CanAccess { get; set; }
    }
}
