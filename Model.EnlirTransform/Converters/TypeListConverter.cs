using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRKApi.Model.EnlirTransform.IdLists;

namespace FFRKApi.Model.EnlirTransform.Converters
{
    public class TypeListConverter
    {
        private readonly ITypeList _typeList;

        public TypeListConverter(ITypeList typeList)
        {
            _typeList = typeList;
        }

        public int ConvertFromNameToId(string input) 
        {
            int id = 0;

            id = _typeList.TypeList.SingleOrDefault(r => r.Value == input.Trim()).Key;

            return id;
        }
    }
}
