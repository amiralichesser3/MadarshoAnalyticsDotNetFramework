using MadarshoAnalyticsDotNetFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MadarshoAnalyticsDotNetFramework.Context
{
    public class AnalyticsContext : DbContext
    {
        public AnalyticsContext()
        {
            Database.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection_string"];
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Action> Actions { get; set; }
        public DbSet<UserAction> UserActions { get; set; }
    }
}