namespace MadarshoAnalyticsDotNetFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MadarshoAnalyticsDotNetFramework.Context.AnalyticsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MadarshoAnalyticsDotNetFramework.Context.AnalyticsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Actions.AddOrUpdate(a=>a.Name, 
                new Models.Action("FirstOpen"),
                new Models.Action("AppOpen"),
                new Models.Action("CantResolve"),
                new Models.Action("RegisterPregnant"),
                new Models.Action("RegisterTtc"),
                new Models.Action("RegisterNone"),
                new Models.Action("InvalidRegisteration"),
                new Models.Action("Login"),
                new Models.Action("ForgotPass"),
                new Models.Action("VerifyPhone"),
                new Models.Action("InvalidLogin"),
                new Models.Action("ViewSection"),
                new Models.Action("Get401"),
                new Models.Action("EnterWeight"),
                new Models.Action("EnterSymptom"),
                new Models.Action("EnterPrenatalCare"),
                new Models.Action("RemoveWeight"),
                new Models.Action("RemoveSymptom"),
                new Models.Action("RemovePrenatalCare"),
                new Models.Action("ViewedUrl"),
                new Models.Action("AddedPhoto"),
                new Models.Action("ChangedPhoto"),
                new Models.Action("ViewProfileDemographic"),
                new Models.Action("ViewProfileHealth"),
                new Models.Action("ChangeProfileHealth"),
                new Models.Action("ChangeProfileDemographic"),
                new Models.Action("ShareApp"),
                new Models.Action("ShareLink"),
                new Models.Action("Logout")
                );
            context.SaveChanges();
        }
    }
}
