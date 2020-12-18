using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreWebApplicationMVCTemplate.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _studentList;

        public MockStudentRepository()
        {
            _studentList = new List<Student>()
            {
                new Student() {
                    StudentId = 101,
                    Name = "Seth",
                    Branch = Branch.CSE,
                    Section = "A",
                    Gender = Gender.Male
                },
                new Student() {
                    StudentId = 102,
                    Name = "Bill",
                    Branch = Branch.CSE,
                    Section = "B",
                    Gender = Gender.Male
                },
                new Student() {
                    StudentId = 103,
                    Name = "Astrid",
                    Branch = Branch.CSE,
                    Section = "B",
                    Gender = Gender.Female
                }
            };
        }

        public Student GetStudent(int Id)
        {
            return _studentList.FirstOrDefault(obj => obj.StudentId == Id);
            /*return null;*/
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentList;
        }

        public Student Add(Student student)
        {
            // create a student id
            student.StudentId = _studentList.Max(s => s.StudentId) + 1;

            _studentList.Add(student);
            return student;
        }

        public Student Update(Student studentChanges)
        {
            Student student = _studentList.FirstOrDefault(s => s.StudentId == studentChanges.StudentId);
            if (student != null)
            {
                student.Name = studentChanges.Name;
                student.Email = studentChanges.Email;
                student.Branch = studentChanges.Branch;
                student.Gender = studentChanges.Gender;
                student.Section = studentChanges.Section;
                student.Address = studentChanges.Address;
            }
            return student;
        }

        public Student Delete(int id)
        {
            Student student = _studentList.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                _studentList.Remove(student);
            }
            return student;
        }
    }
}
