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
                                                                          new KeyValuePair<int, string>(1, "-"),
                                                                          new KeyValuePair<int, string>(2, "All allies"),
                                                                          new KeyValuePair<int, string>(3, "All enemies"),
                                                                          new KeyValuePair<int, string>(4, "Ally with status"),
                                                                          new KeyValuePair<int, string>(5, "Another ally"),
                                                                          new KeyValuePair<int, string>(6, "Lowest HP% ally"),
                                                                          new KeyValuePair<int, string>(7, "Random ally"),
                                                                          new KeyValuePair<int, string>(8, "Random enemies"),
                                                                          new KeyValuePair<int, string>(9, "Random enemy"),
                                                                          new KeyValuePair<int, string>(10, "Self"),
                                                                          new KeyValuePair<int, string>(11, "Single"),
                                                                          new KeyValuePair<int, string>(12, "Single ally"),
                                                                          new KeyValuePair<int, string>(13, "Single enemy")
                                                                          //new KeyValuePair<int, string>(14, "")
                                                                      };


        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
