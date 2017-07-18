using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadarshoAnalyticsDotNetFramework.ViewModels
{
    public class UserActionView
    {
        public long UserId { get; set; }
        public string FirebaseToken { get; set; }
        public string AppVersion { get; set; }
        public ICollection<ActionView> Actions { get; set; }
    }
}