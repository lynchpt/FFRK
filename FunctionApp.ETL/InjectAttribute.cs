
using System;
using Microsoft.Azure.WebJobs.Description;


namespace FunctionApp.ETL

{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class InjectAttribute : Attribute    
    {

    }

}