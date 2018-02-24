using System;
using System.Collections.Generic;
using System.Text;

namespace FFRK.Api.Infra.Options.EnlirETL
{
    public class CachingOptions
    {
        public string ConnectionString { get; set; }
        public string DefaultTimeToLiveInHours { get; set; }
        public string UseCache { get; set; }
        
    }
}
