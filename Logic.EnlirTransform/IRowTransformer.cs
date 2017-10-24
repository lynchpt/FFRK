using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Logic.EnlirTransform
{
    public interface IRowTransformer<TRow, TModel> where TRow : class 
                                                    where TModel : class
    {
        IEnumerable<TModel> Transform(IEnumerable<TRow> importedRows);
    }
}
