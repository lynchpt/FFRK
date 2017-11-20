using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public interface ITypeList
    {
        IList<KeyValuePair<int, string>> TypeList { get;  }
    }
}
