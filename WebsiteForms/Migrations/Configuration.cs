namespace WebsiteForms.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebsiteForms.Database.WebsiteFormsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebsiteForms.Database.WebsiteFormsContext context)
        {
            context.RequestTypes.AddRange(Initializer.GetRequestTypes());
            context.Users.AddRange(Initializer.GetUsers());
        }
    }
}
