using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.SheetsApiHelper;
using Google.Apis.Sheets.v4.Data;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.EnlirImport
{
    public interface IGoogleSheetsDataValidator
    {
        void LoadSpreadsheetMetadata(string spreadsheetId);
        bool ValidateWorksheetMetadata(ImporterOptions importerOptions);
    }

    public class GoogleSheetsDataValidator : IGoogleSheetsDataValidator
    {
        #region Class Variables

        private Spreadsheet _spreadsheet;
        private readonly ISheetsApiHelper _sheetsApiHelper;
        private readonly ILogger<GoogleSheetsDataValidator> _logger;
        #endregion

        #region Constants

        private const string RangeExpressionColumnSeparator = ":";
        private const string MultiWordWorksheetNameDelimiter = "'";
        #endregion

        #region Constructors

        public GoogleSheetsDataValidator(ISheetsApiHelper sheetsApiHelper, ILogger<GoogleSheetsDataValidator> logger)
        {
            _sheetsApiHelper = sheetsApiHelper;
            _logger = logger;
        }
        #endregion

        #region IGoogleSheetsDataValidator Implementation
        public void LoadSpreadsheetMetadata(string spreadsheetId)
        {
            _spreadsheet = _sheetsApiHelper.GetSpreadsheetMetadata(spreadsheetId);
        }

        public bool ValidateWorksheetMetadata(ImporterOptions importerOptions)
        {
            bool isValid = false;

            if (_spreadsheet == null) throw new InvalidOperationException("Spreadsheet object must be loaded by call to LoadSpreadsheetMetadata prioir to calling ValidateSpreadsheetMetadata");

            string lastColumnName = importerOptions.RangeExpression.Substring(importerOptions.RangeExpression.IndexOf(RangeExpressionColumnSeparator, StringComparison.InvariantCulture)+1);
            int expectedColumnCount = _sheetsApiHelper.ExcelColumnNameToNumber(lastColumnName);

            string sanitizedWorksheetName = importerOptions.WorkSheetName.Replace(MultiWordWorksheetNameDelimiter, String.Empty);

            Sheet sheet = _spreadsheet.Sheets.FirstOrDefault(w => w.Properties.Title == sanitizedWorksheetName);

            //validate expected column count matches actual
            if (sheet?.Properties.GridProperties.ColumnCount != null)
            {
                var actualColumnCount = sheet.Properties.GridProperties.ColumnCount.Value;

                //modify actualColumnCount lower for chart at the end (as in Experience)
                if (sheet.Charts != null && sheet.Charts.Any())
                {
                    int? anchorCellColumnIndex = sheet.Charts.First().Position.OverlayPosition.AnchorCell.ColumnIndex;
                    if (anchorCellColumnIndex != null)
                    {
                        actualColumnCount = (int)anchorCellColumnIndex;
                    }                        
                }

                if (actualColumnCount == expectedColumnCount)
                {
                    isValid = true;
                }
            }

            return isValid;
        } 
        #endregion
    }
}
