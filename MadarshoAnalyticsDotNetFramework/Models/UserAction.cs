using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MadarshoAnalyticsDotNetFramework.Models
{
    public class UserAction
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; } 
        public virtual User User { get; set; }
        public long ActionId { get; set; }
        public virtual Action Action { get; set; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }
        public long Date { get; set; }
    }
}