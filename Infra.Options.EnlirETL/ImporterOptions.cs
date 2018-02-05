using System;
using System.Collections.Generic;
using System.Text;

namespace FFRK.Api.Infra.Options.EnlirETL
{
    public class ImporterOptions
    {
        public string SpreadsheetId { get; set; }
        public string WorkSheetName { get; set; }
        public string RangeExpression { get; set; }
        public int ValueRenderOption { get; set; }
    }
}
