using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreWebApplicationMVCTemplate.Models
{
    // Extensions methods require that the class be static
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    Name = "Lisa Simpson",
                    Email = "lisa@yahoo.com",
                    Branch = Branch.CSE
                },
                new Student
                {
                    StudentId = 2,
                    Name = "Homer Simpson",
                    Email = "homer@yahoo.com",
                    Branch = Branch.CSE
                }
            );
        }
    }
}
