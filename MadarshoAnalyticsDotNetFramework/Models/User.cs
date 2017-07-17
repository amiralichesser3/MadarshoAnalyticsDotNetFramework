using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MadarshoAnalyticsDotNetFramework.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string Username { get; set; }
        public string FirebaseToken { get; set; }
        public string AppVersion { get; set; } 
        public long RegisterDate { get; set; } 
        public virtual ICollection<UserAction> UserActions { get; set; }
    }
}