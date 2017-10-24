using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FFRKApi.Logic.EnlirImport
{
    public interface IRowImporter<T> where T : class
    {
        IEnumerable<T> Import();
    }
}
