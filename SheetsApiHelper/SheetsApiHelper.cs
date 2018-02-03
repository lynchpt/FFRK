using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FFRKApi.SheetsApiHelper
{
    public interface ISheetsApiHelper
    {
        ValueRange GetSheetsData(string spreadsheetId, string worksheetName, string rangeExpression);

        Spreadsheet GetSpreadsheetMetadata(string spreadsheetId);

        int ExcelColumnNameToNumber(string columnName);
    }

    public class SheetsApiHelper : ISheetsApiHelper
    {
        private readonly SheetsServiceOptions _sheetsServiceOptions;
        private readonly SheetsService _sheetsService;
        private readonly ILogger<SheetsApiHelper> _logger;

        public SheetsApiHelper(IOptions<SheetsServiceOptions> sheetsServiceOptionsAccessor, ILogger<SheetsApiHelper> logger)
        {
            _logger = logger;
            _sheetsServiceOptions = sheetsServiceOptionsAccessor.Value;

            _sheetsService = new SheetsService(new BaseClientService.Initializer()
                {
                    ApplicationName = _sheetsServiceOptions.Name,
                    ApiKey = _sheetsServiceOptions.ApiKey
                });

            _logger.LogInformation("SheetsService instance initialized for {ApplicationName}", _sheetsServiceOptions.Name);
        }



        #region ISheetsApiHelper Implementation
        public ValueRange GetSheetsData(string spreadsheetId, string worksheetName, string rangeExpression)
        {
            SpreadsheetsResource.ValuesResource.GetRequest request = GetSheetsRequest(spreadsheetId, worksheetName, rangeExpression);

            ValueRange response = request.Execute();


            _logger.LogInformation("SheetsService instance retrieved {RowCount} rows of data for request for {SpreadsheetId}, {WorksheetName}, {RangeExpression}", 
                response.Values.Count, spreadsheetId, worksheetName, rangeExpression);

            return response;
        }

        public Spreadsheet GetSpreadsheetMetadata(string spreadsheetId)
        {
            Spreadsheet spreadsheet = _sheetsService.Spreadsheets.Get(spreadsheetId).Execute();

            return spreadsheet;
        }

        public int ExcelColumnNameToNumber(string columnName)
        {
            if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException("columnName");

            columnName = columnName.ToUpperInvariant();

            int sum = 0;

            for (int i = 0; i < columnName.Length; i++)
            {
                sum *= 26;
                sum += (columnName[i] - 'A' + 1);
            }

            return sum;
        }

        #endregion

        #region Private Methods
        private SpreadsheetsResource.ValuesResource.GetRequest GetSheetsRequest(string spreadsheetId, string worksheetName, string rangeExpression)
        {
            string range = $"{worksheetName}!{rangeExpression}";

            SpreadsheetsResource.ValuesResource.GetRequest request = _sheetsService.Spreadsheets.Values.Get(spreadsheetId, range);
            request.ValueRenderOption = SpreadsheetsResource.ValuesResource.GetRequest.ValueRenderOptionEnum.FORMULA;
            return request;
        }

        #endregion
    }


    //public class SheetsApiHelper
    //{
    //    // If modifying these scopes, delete your previously saved credentials
    //    // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
    //    private static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
    //    private const string ApplicationName = "FFRKApi";
    //    private const string ApiKey = "AIzaSyDRM4pp81uWhzvtDb5pI0n4y_8GVNFb5fM";

    //    public SheetsService GetSheetsService(string applicationName, string apiKey)
    //    {
    //        var sheetsService = new SheetsService(new BaseClientService.Initializer()
    //        {
    //            ApplicationName = applicationName,
    //            ApiKey = apiKey
    //        });

    //        return sheetsService;
    //    }

    //    public SpreadsheetsResource.ValuesResource.GetRequest GetSheetsRequest(SheetsService sheetsService, string spreadsheetId, string worksheetName, string rangeExpression)
    //    {
    //        string range = $"{worksheetName}!{rangeExpression}";

    //        SpreadsheetsResource.ValuesResource.GetRequest request = sheetsService.Spreadsheets.Values.Get(spreadsheetId, range);

    //        return request;
    //    }

    //    public ValueRange GetSheetsData(SheetsService sheetsService, string spreadsheetId, string worksheetName, string rangeExpression)
    //    {
    //        SpreadsheetsResource.ValuesResource.GetRequest request = GetSheetsRequest(sheetsService, spreadsheetId, worksheetName, rangeExpression);

    //        ValueRange response = request.Execute();

    //        return response;
    //    }
    //}
}
