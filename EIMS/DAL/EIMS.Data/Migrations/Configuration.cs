using System.Data.Entity.Migrations;

namespace EIMS.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EIMSDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EIMS.Data.EIMSDataContext";
        }

        protected override void Seed(EIMSDataContext context)
        {
            context.Departments.AddOrUpdate(
                p => p.Name,
                new Department {Name = "Finance", Description = "Finance department"},
                new Department {Name = "HR", Description = "Human resource department"},
                new Department {Name = "Purchase", Description = "Purchase department"},
                new Department {Name = "Sales and Marketing", Description = "Sales and marketing department"},
                new Department {Name = "Manufacturing", Description = "Manufacturing department"},
                new Department {Name = "Customer Support", Description = "Customer support department"}
                );
        }
    }
}