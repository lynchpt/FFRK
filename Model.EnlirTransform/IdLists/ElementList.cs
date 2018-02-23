using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class ElementList : ITypeList
    {
        private IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                                {
                                                                    new KeyValuePair<int, string>(0, "Unknown"),
                                                                    new KeyValuePair<int, string>(1, String.Empty),
                                                                    new KeyValuePair<int, string>(2, "-"),
                                                                    new KeyValuePair<int, string>(3, "Dark"),
                                                                    new KeyValuePair<int, string>(4, "Earth"),
                                                                    new KeyValuePair<int, string>(5, "Fire"),
                                                                    new KeyValuePair<int, string>(6, "Holy"),
                                                                    new KeyValuePair<int, string>(7, "Ice"),
                                                                    new KeyValuePair<int, string>(8, "Lightning"),
                                                                    new KeyValuePair<int, string>(9, "NE"),
                                                                    new KeyValuePair<int, string>(10, "Poison"),
                                                                    new KeyValuePair<int, string>(11, "Posion"),
                                                                    new KeyValuePair<int, string>(12, "Water"),
                                                                    new KeyValuePair<int, string>(13, "Wind")
                                                                };

        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
