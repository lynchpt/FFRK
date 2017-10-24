using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum LegendSphereColumn
    {

        Realm = 0,
        Character = 1,


        BenefitColumn1 = 2,
        BenefitColumn2 = 3,
        BenefitColumn3 = 4,
        BenefitColumn4 = 5,     

        Mote1Type = 6,
        Mote1AmountColumn1 = 7,
        Mote1AmountColumn2 = 8,
        Mote1AmountColumn3 = 9,
        Mote1AmountColumn4 = 10,


        Mote2Type = 11,
        Mote2AmountColumn1 = 12,
        Mote2AmountColumn2 = 13,
        Mote2AmountColumn3 = 14,
        Mote2AmountColumn4 = 15

    }

    public class LegendSphereRow
    {
        //General
        public string Realm { get; set; }
        public string Character { get; set; }

        //Legend Sphere Benefits
        public string BenefitColumn1 { get; set; }
        public string BenefitColumn2 { get; set; }
        public string BenefitColumn3 { get; set; }
        public string BenefitColumn4 { get; set; }

        //Mote 1
        public string Mote1Type { get; set; }
        public string Mote1AmountColumn1 { get; set; }
        public string Mote1AmountColumn2 { get; set; }
        public string Mote1AmountColumn3 { get; set; }
        public string Mote1AmountColumn4 { get; set; }

        //Mote 2
        public string Mote2Type { get; set; }
        public string Mote2AmountColumn1 { get; set; }
        public string Mote2AmountColumn2 { get; set; }
        public string Mote2AmountColumn3 { get; set; }
        public string Mote2AmountColumn4 { get; set; }
    }
}
