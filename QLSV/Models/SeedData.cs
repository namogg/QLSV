using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using QLSV.Data;

namespace QLSV.Models;
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new QLSVContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<QLSVContext>>()))
            {
                // Look for any movies.
                if (context.Employee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Employee.AddRange(
                    new Employee
                    {
                        //EmployeeId = 10,
                        Name = "Nam",
                        room = "A-1",
                        gender = "M",
                        adress = "203 Nguyen Huy Tuong",
                        Birth = DateTime.Parse("12/10/2002")

                    },
                    new Employee
                    {
                        //EmployeeId = 2,
                        Name = "A",
                        room = "A-2",
                        gender = "M",
                        adress = "203 Nguyen Trai",
                        Birth = DateTime.Parse("10/10/2003")

                    },
                    new Employee
                    {
                       // EmployeeId = 3,
                        Name = "B",
                        room = "A-2",
                        gender = "F",
                        adress = "1 Nguyen Trai",
                        Birth = DateTime.Parse("9/10/2004")

                    },
                    new Employee
                    {
                        //EmployeeId = 4,
                        Name = "N",
                        room = "B-1",
                        gender = "M",
                        adress = "1 Tran Dai Nghia",
                        Birth = DateTime.Parse("7/4/2002")

                    },
                    new Employee
                    {
                        //EmployeeId = 5,
                        Name = "Nguyen Van A",
                        room = "A-5",
                        gender = "F",
                        adress = "so 1 Nguyen Tuan",
                        Birth = DateTime.Parse("9/10/2002")

                    }
                ) ; 
                context.SaveChanges();
            }
        }
    }
