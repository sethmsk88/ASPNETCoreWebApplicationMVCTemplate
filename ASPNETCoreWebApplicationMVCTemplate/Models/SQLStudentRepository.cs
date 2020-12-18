using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreWebApplicationMVCTemplate.Models
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;

        public SQLStudentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Student Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }

        public Student Delete(int id)
        {
            Student student = context.Students.Find(id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return context.Students;
        }

        public Student GetStudent(int id)
        {
            return context.Students.Find(id);
        }

        public Student Update(Student studentChanges)
        {
            var student = context.Students.Attach(studentChanges);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return studentChanges;
        }
    }
}
