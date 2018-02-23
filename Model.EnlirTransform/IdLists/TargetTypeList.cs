using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class TargetTypeList : ITypeList
    {
        private readonly IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                                      {
                                                                          new KeyValuePair<int, string>(0, "Unknown"),
                                                                          new KeyValuePair<int, string>(1, String.Empty),
                                                                          new KeyValuePair<int, string>(2, "-"),
                                                                          new KeyValuePair<int, string>(3, "All allies"),
                                                                          new KeyValuePair<int, string>(4, "All enemies"),
                                                                          new KeyValuePair<int, string>(5, "Ally with status"),
                                                                          new KeyValuePair<int, string>(6, "Another ally"),
                                                                          new KeyValuePair<int, string>(7, "Lowest HP% ally"),
                                                                          new KeyValuePair<int, string>(8, "Random ally"),
                                                                          new KeyValuePair<int, string>(9, "Random enemies"),
                                                                          new KeyValuePair<int, string>(10, "Random enemy"),
                                                                          new KeyValuePair<int, string>(11, "Self"),
                                                                          new KeyValuePair<int, string>(12, "Single"),
                                                                          new KeyValuePair<int, string>(13, "Single ally"),
                                                                          new KeyValuePair<int, string>(14, "Single enemy")
                                                                      };


        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
