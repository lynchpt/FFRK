using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.Converters
{
    public class StringToBooleanConverter
    {
        #region Constants
        private const string IsCheckedIndicator = "✓";
        #endregion

        #region Public Methods
        public bool ConvertFromStringToBool(string input)
        {
            bool result = false;

            if (!String.IsNullOrWhiteSpace(input))
            {
                switch (input)
                {
                    case "Y":
                        result = true;
                        break;
                    case IsCheckedIndicator:
                        result = true;
                        break;
                    case "N":
                        result = false;
                        break;
                    default:
                        //leave result false, this is as good a default as any
                        break;

                }
            }

            return result;
        } 
        #endregion
    }
}
