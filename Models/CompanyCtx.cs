using Microsoft.EntityFrameworkCore;

namespace Eyouth1.Models
{
    public class CompanyCtx:DbContext
    {
        public CompanyCtx()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\sql19;Initial Catalog=Company5;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new List<Department>
            {
                new Department { Id = 1, Name = "Human Resources", MgrName = "Robert King" },
                new Department { Id = 2, Name = "Finance", MgrName = "Emily Carter" },
                new Department { Id = 3, Name = "IT", MgrName = "Michael Adams" },
                new Department { Id = 4, Name = "Marketing", MgrName = "Sophia Martinez" },
                new Department { Id = 5, Name = "Sales", MgrName = "Daniel Thompson" }
            });

            modelBuilder.Entity<Employee>().HasData(new List<Employee>
            {
                 new Employee { Id = 1, Name = "Alice Johnson", Address = "123 Main St", Salary = 75432.67m, Img = "boy.jpg", DeptId = 3 },
                new Employee { Id = 2, Name = "Bob Smith", Address = "456 Elm St", Salary = 52789.34m, Img = "girl.jpg", DeptId = 1 },
                new Employee { Id = 3, Name = "Charlie Brown", Address = "789 Oak St", Salary = 88123.45m, Img = "boy.jpg", DeptId = 5 },
                new Employee { Id = 4, Name = "David Williams", Address = "101 Maple Ave", Salary = 63543.12m, Img = "girl.jpg", DeptId = 2 },
                new Employee { Id = 5, Name = "Emma Davis", Address = "222 Pine St", Salary = 91876.89m, Img = "girl.jpg", DeptId = 4 },
                new Employee { Id = 6, Name = "Frank Miller", Address = "333 Birch Rd", Salary = 47654.23m, Img = "boy.jpg", DeptId = 3 },
                new Employee { Id = 7, Name = "Grace Wilson", Address = "444 Cedar Ln", Salary = 68789.45m, Img = "girl.jpg", DeptId = 1 },
                new Employee { Id = 8, Name = "Henry Moore", Address = "555 Spruce Ct", Salary = 79999.99m, Img = "boy.jpg", DeptId = 2 },
                new Employee { Id = 9, Name = "Ivy Taylor", Address = "666 Willow Dr", Salary = 56432.78m, Img = "girl.jpg", DeptId = 5 },
                new Employee { Id = 10, Name = "Jack White", Address = "777 Ash Blvd", Salary = 84567.90m, Img = "girl.jpg", DeptId = 4 }
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
