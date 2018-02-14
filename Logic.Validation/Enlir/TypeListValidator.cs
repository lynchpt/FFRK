using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Logic.Validation.Enlir
{
    /// <summary>
    /// Implementations will provide methods to ensure that the the actual values in the TypeLists
    /// from the Model.EnlirTransform or Model.EnlirMerge libraries exactly match the values found in the 
    /// imported data. If there is a difference, the TypeLists need to be corrected in code
    /// </summary>
    public interface ITypeListValidator
    {
    }

    public class TypeListValidator : ITypeListValidator
    {
    }
}
