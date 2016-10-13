using SimpleTaskSystem.People;
using System.Data.Entity.Migrations;

namespace SimpleTaskSystem.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SimpleTaskSystem.EntityFramework.SimpleTaskSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SimpleTaskSystem";
        }

        protected override void Seed(SimpleTaskSystem.EntityFramework.SimpleTaskSystemDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
            context.People.AddOrUpdate(p => p.Name,
                new Person { Name = "Isaac Asimov" },
                new Person { Name = "Thomas More" },
                new Person { Name = "George Orwell" },
                new Person { Name= "Douglas Adams" });
        }
    }
}
