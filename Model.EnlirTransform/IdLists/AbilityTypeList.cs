using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class AbilityTypeList : ITypeList
    {
        private readonly IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                             {
                                                                 new KeyValuePair<int, string>(0, "Unknown"),
                                                                 new KeyValuePair<int, string>(1, "?"),
                                                                 new KeyValuePair<int, string>(2, "BLK"),
                                                                 new KeyValuePair<int, string>(3, "BLU"),
                                                                 new KeyValuePair<int, string>(4, "NAT"),
                                                                 new KeyValuePair<int, string>(5, "NIN"),
                                                                 new KeyValuePair<int, string>(6, "PHY"),
                                                                 new KeyValuePair<int, string>(7, "SUM"),
                                                                 new KeyValuePair<int, string>(8, "WHT")
                                                             };


        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
