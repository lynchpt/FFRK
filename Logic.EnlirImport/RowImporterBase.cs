using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Model.EnlirImport;
using FFRKApi.SheetsApiHelper;
using Google.Apis.Sheets.v4.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FFRKApi.Logic.EnlirImport
{
    public abstract class RowImporterBase<T> : IRowImporter<T> where T : class, new()                                                                     
    {
        #region Class Variables
        private readonly ISheetsApiHelper _sheetsApiHelper;
        private readonly ImporterOptions _importerOptions;
        private readonly ILogger<RowImporterBase<T>> _logger;
        #endregion

        #region Constructors
        protected RowImporterBase(ISheetsApiHelper sheetsApiHelper, IOptions<ImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<T>> logger)
        {
            _sheetsApiHelper = sheetsApiHelper;
            _importerOptions = importerOptionsAccessor.Value;
            _logger = logger;
        }
        #endregion

        #region IRowImporter<T> Implementation
        public IEnumerable<T> Import()
        {
            _logger.LogInformation($"Import invoked and attempting to load sheet data");

            //get the raw data
            ValueRange sheetData = _sheetsApiHelper.GetSheetsData(_importerOptions.SpreadsheetId,
                _importerOptions.WorkSheetName, _importerOptions.RangeExpression);


            //load the raw data into LegendSphereRow instances
            IEnumerable<T> importedRows = LoadRawDataIntoRowList(sheetData);

            return importedRows;
        }
        #endregion


        #region Protected Methods

        protected IEnumerable<T> LoadRawDataIntoRowList(ValueRange sheetData)
        {
            IList<T> importedRows = new List<T>();

            if (sheetData != null && sheetData.Values.Count > 0)
            {
                foreach (var row in sheetData.Values)
                {
                    //Any row will only have columns out to the point where sheet data is blank, so we never know how many columns a row will have.
                    //We need to count how mnay coumns are in each row and not attempt to access non-existant columns.
                    int columnCount = row.Count;

                    //if the row has no columns, there is nothing to load, so skip it
                    if (columnCount == 0) continue;

                    //if the first column is blank, we don't care about the row, so continue to the next row
                    if (String.IsNullOrWhiteSpace(row[0].ToString())) continue;
                 
                    //General
                    //legendSphereRow.Realm = ResolveColumnContents(columnCount, LegendSphereColumn.Realm, row);
                    T importedRow = AssignColumnToProperty(columnCount, row);

                    importedRows.Add(importedRow);

                    _logger.LogDebug("Successfully imported row of type {RowType}", typeof(T).Name);
                }

                _logger.LogInformation("Successfully imported {RowCount} row of type {RowType}", importedRows.Count(), typeof(T).Name);
            }
            else
            {
                _logger.LogWarning($"No data found for invocation of {nameof(RowImporterBase<T>)}.{nameof(Import)}");
            }

            return importedRows;
        }


        protected abstract T AssignColumnToProperty(int columnCount, IList<object> row);

        protected string ResolveColumnContents(int columnCount, Enum columnEnum, IList<object> row)
        {
            object contents = Convert.ToInt32(columnEnum) < columnCount ? (object)row[Convert.ToInt32(columnEnum)] : null;

            string contentString = contents?.ToString();

            //string contents = Convert.ToInt32(columnEnum) < columnCount ? (string)row[Convert.ToInt32(columnEnum)] : null;

            string processedContents = PostProcessColumnContents(contentString);

            return processedContents;
        }
        #endregion

        #region Private Methods

        private string PostProcessColumnContents(string contents)
        {
            const string ImageFunctionMarker = "=image(\"";
            const string FunctionTerminator = "\")";

            string processedContents = contents;

            if (contents != null && contents.StartsWith(ImageFunctionMarker))
            {
                processedContents = contents.Replace(ImageFunctionMarker, String.Empty).Replace(FunctionTerminator, String.Empty);

            }

            return processedContents;
        }
        #endregion
    }
}
