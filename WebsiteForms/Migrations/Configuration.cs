namespace WebsiteForms.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Reflection;
    using WebsiteForms.Database;
    using WebsiteForms.Database.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<WebsiteFormsContext>
    {
        private readonly string[] EXCEPT_COLUMNS_UPDATE = new string[] { "CreatedAt" };
        private  WebsiteFormsContext Context { get; set; }


        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebsiteFormsContext context)
        {
            Context = context;

            AddOrUpdateRange(Initializer.GetUsers());
            AddOrUpdateRange(Initializer.GetRequestTypes());
        }

        private void AddOrUpdateRange<T>(IEnumerable<T> entities) where T: BaseEntity
        {
            var entitiesList = (List<T>)entities;
            entitiesList.ForEach(x => AddOrUpdate(x));
        }

        private void AddOrUpdate<T>(T entity) where T : BaseEntity
        {
            var DbSet = Context.Set<T>();
            var originalEntity = DbSet.FirstOrDefault(x => x.Id == entity.Id);

            if (originalEntity == null) Add(entity);
            else Modify(originalEntity, entity);
        }

        private void Modify<T>(T originalEntity, T newEntity) where T: BaseEntity
        {
            PropertyInfo[] originalProperties = originalEntity.GetType().GetProperties();
            PropertyInfo[] newProperties = newEntity.GetType().GetProperties();

            foreach (PropertyInfo property in originalProperties)
            {
                var found = newProperties.FirstOrDefault(p => !EXCEPT_COLUMNS_UPDATE.Any(x => x == p.Name) && p.Name == property.Name);
                if(found != null)
                {
                    property.SetValue(originalEntity, found.GetValue(newEntity));
                }
            }
        }

        private void Add<T>(T entity) where T: BaseEntity
        {
            var DbSet = Context.Set<T>();
            DbSet.Add(entity);
        }
    }
}
