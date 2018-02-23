using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class RealmList : ITypeList
    {       
        private IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                             {
                                                                    new KeyValuePair<int, string>(0, "Unknown"),
                                                                    new KeyValuePair<int, string>(1, "I"),
                                                                    new KeyValuePair<int, string>(2, "II"),
                                                                    new KeyValuePair<int, string>(3, "III"),
                                                                    new KeyValuePair<int, string>(4, "IV"),
                                                                    new KeyValuePair<int, string>(5, "V"),
                                                                    new KeyValuePair<int, string>(6, "VI"),
                                                                    new KeyValuePair<int, string>(7, "VII"),
                                                                    new KeyValuePair<int, string>(8, "VIII"),
                                                                    new KeyValuePair<int, string>(9, "IX"),
                                                                    new KeyValuePair<int, string>(10, "X"),
                                                                    new KeyValuePair<int, string>(11, "XI"),
                                                                    new KeyValuePair<int, string>(12, "XII"),
                                                                    new KeyValuePair<int, string>(13, "XIII"),
                                                                    new KeyValuePair<int, string>(14, "XIV"),
                                                                    new KeyValuePair<int, string>(15, "XV"),
                                                                    new KeyValuePair<int, string>(16, "FFT"),
                                                                    new KeyValuePair<int, string>(17, "Beyond"),
                                                                    new KeyValuePair<int, string>(18, "Type-0"),
                                                                    new KeyValuePair<int, string>(19, "KH"),
                                                                    new KeyValuePair<int, string>(20, "Core"),
                                                                    new KeyValuePair<int, string>(21, "IV:TAY"),
                                                                    new KeyValuePair<int, string>(22, "CC:VII"),
                                                                    new KeyValuePair<int, string>(23, "DC:VII"),
                                                                    new KeyValuePair<int, string>(24, "X-2"),
                                                                    new KeyValuePair<int, string>(25, "XIII-2"),
                                                                    new KeyValuePair<int, string>(26, "-")
                                                                   

                                                             };

        public IList<KeyValuePair<int, string>> TypeList => _typeList;


    }
}
