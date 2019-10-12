using System;
using System.Linq;

namespace MikesBank.Models

{
    public static class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Employee.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Employee[]
            {
            new Employee{FirstName="Carson",LastName="Alexander",UpdateTime=DateTime.Parse("2005-09-01")},
            new Employee{FirstName="Meredith",LastName="Alonso",UpdateTime=DateTime.Parse("2002-09-01")},
            new Employee{FirstName="Arturo",LastName="Anand",UpdateTime=DateTime.Parse("2003-09-01")},
            new Employee{FirstName="Gytis",LastName="Barzdukas",UpdateTime=DateTime.Parse("2002-09-01")},
            new Employee{FirstName="Yan",LastName="Li",UpdateTime=DateTime.Parse("2002-09-01")},
            new Employee{FirstName="Peggy",LastName="Justice",UpdateTime=DateTime.Parse("2001-09-01")},
            new Employee{FirstName="Laura",LastName="Norman",UpdateTime=DateTime.Parse("2003-09-01")},
            new Employee{FirstName="Nino",LastName="Olivetto",UpdateTime=DateTime.Parse("2005-09-01")}
            };
            foreach (var s in students)
            {
                context.Employee.Add(s);
            }
            context.SaveChanges();


        }
    }
}