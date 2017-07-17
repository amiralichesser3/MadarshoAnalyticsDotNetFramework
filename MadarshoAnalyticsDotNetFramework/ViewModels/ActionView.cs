using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadarshoAnalyticsDotNetFramework.ViewModels
{
    public class ActionView
    {
        public long ActionId { get; set; }
        public long Date { get; set; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }
    }
}