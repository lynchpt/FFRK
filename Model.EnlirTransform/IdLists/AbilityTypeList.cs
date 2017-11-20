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
                                                                 new KeyValuePair<int, string>(1, "BLK"),
                                                                 new KeyValuePair<int, string>(2, "WHT"),
                                                                 new KeyValuePair<int, string>(3, "PHY"),
                                                                 new KeyValuePair<int, string>(4, "NAT"),
                                                                 new KeyValuePair<int, string>(5, "SUM"),
                                                                 new KeyValuePair<int, string>(6, "NIN")
                                                             };


        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
