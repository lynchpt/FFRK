using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum RecordSphereColumn
    {
        //General
        Realm = 0,
        Character = 1,
        RecordSphereName = 2,

        //Sphere Benefits
        BenefitLevel1 = 3,
        BenefitLevel2 = 4,
        BenefitLevel3 = 5,
        BenefitLevel4 = 6,
        BenefitLevel5 = 7,

        //Prerequisites
        RecordSpherePrerequisites = 8,

        //Motes Required
        Mote1Type = 9,
        Mote1AmountLevel1 = 10,
        Mote1AmountLevel2 = 11,
        Mote1AmountLevel3 = 12,
        Mote1AmountLevel4 = 13,
        Mote1AmountLevel5 = 14,

        Mote2Type = 15,
        Mote2AmountLevel1 = 16,
        Mote2AmountLevel2 = 17,
        Mote2AmountLevel3 = 18,
        Mote2AmountLevel4 = 19,
        Mote2AmountLevel5 = 20,

        Mote3Type = 21,
        Mote3AmountLevel1 = 22,
        Mote3AmountLevel2 = 23,
        Mote3AmountLevel3 = 24,
        Mote3AmountLevel4 = 25,
        Mote3AmountLevel5 = 26,

        Mote4Type = 27,
        Mote4AmountLevel1 = 28,
        Mote4AmountLevel2 = 29,
        Mote4AmountLevel3 = 30,
        Mote4AmountLevel4 = 31,
        Mote4AmountLevel5 = 32
    }

    public class RecordSphereRow
    {
        //General
        public string Realm { get; set; }
        public string Character { get; set; }
        public string RecordSphereName { get; set; }

        //Sphere Benefits
        public string BenefitLevel1 { get; set; }
        public string BenefitLevel2 { get; set; }
        public string BenefitLevel3 { get; set; }
        public string BenefitLevel4 { get; set; }
        public string BenefitLevel5 { get; set; }

        //Prerequisites
        public string RecordSpherePrerequisites { get; set; }

        //Motes Required
        public string Mote1Type { get; set; }
        public string Mote1AmountLevel1 { get; set; }
        public string Mote1AmountLevel2 { get; set; }
        public string Mote1AmountLevel3 { get; set; }
        public string Mote1AmountLevel4 { get; set; }
        public string Mote1AmountLevel5 { get; set; }


        public string Mote2Type { get; set; }
        public string Mote2AmountLevel1 { get; set; }
        public string Mote2AmountLevel2 { get; set; }
        public string Mote2AmountLevel3 { get; set; }
        public string Mote2AmountLevel4 { get; set; }
        public string Mote2AmountLevel5 { get; set; }


        public string Mote3Type { get; set; }
        public string Mote3AmountLevel1 { get; set; }
        public string Mote3AmountLevel2 { get; set; }
        public string Mote3AmountLevel3 { get; set; }
        public string Mote3AmountLevel4 { get; set; }
        public string Mote3AmountLevel5 { get; set; }

        public string Mote4Type { get; set; }
        public string Mote4AmountLevel1 { get; set; }
        public string Mote4AmountLevel2 { get; set; }
        public string Mote4AmountLevel3 { get; set; }
        public string Mote4AmountLevel4 { get; set; }
        public string Mote4AmountLevel5 { get; set; }
    }
}
