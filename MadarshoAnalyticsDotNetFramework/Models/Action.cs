using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MadarshoAnalyticsDotNetFramework.Models
{
    public class Action
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserAction> UserActions { get; set; }

        public Action()
        {

        }

        public Action(string name)
        {
            Name = name;
        }
    }
}