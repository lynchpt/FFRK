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
                                                                    new KeyValuePair<int, string>(3, "SB"),
                                                                    new KeyValuePair<int, string>(4, "SSB"),
                                                                    new KeyValuePair<int, string>(5, "BSB"),
                                                                    new KeyValuePair<int, string>(6, "OSB"),
                                                                    new KeyValuePair<int, string>(7, "USB"),
                                                                    new KeyValuePair<int, string>(8, "CSB"),
                                                                    new KeyValuePair<int, string>(8, "UOSB"),
                                                                    new KeyValuePair<int, string>(8, "FSB")
                                                             };

        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
