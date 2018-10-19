using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class SoulBreakTierList : ITypeList
    {
        private IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                             {
                                                                    new KeyValuePair<int, string>(0, "Unknown"),
                                                                    new KeyValuePair<int, string>(1, "Default"),
                                                                    new KeyValuePair<int, string>(2, "Shared"),
                                                                    new KeyValuePair<int, string>(3, "RW"),
                                                                    new KeyValuePair<int, string>(4, "SB"),
                                                                    new KeyValuePair<int, string>(5, "SSB"),
                                                                    new KeyValuePair<int, string>(6, "BSB"),
                                                                    new KeyValuePair<int, string>(7, "OSB"),
                                                                    new KeyValuePair<int, string>(8, "USB"),
                                                                    new KeyValuePair<int, string>(9, "CSB"),
                                                                    new KeyValuePair<int, string>(10, "Glint"),
                                                                    new KeyValuePair<int, string>(11, "AOSB"),
                                                                 new KeyValuePair<int, string>(12, "AASB")
                                                             };

        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
