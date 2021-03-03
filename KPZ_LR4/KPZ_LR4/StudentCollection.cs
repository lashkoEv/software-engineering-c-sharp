using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_LR4
{
    class StudentCollection
    {
        private List<Student> students;

        public StudentCollection()
        {
            students = new List<Student>();
        }

        public void AddDefaults(int number)
        {
            for (int i = 0; i < number; i++)
            {
                string firstName = $"Name{students.Count}";
                string lastName = $"LastName{students.Count}";
                int group = students.Count + 5;
                Student student = new Student(new Person(firstName, lastName, new DateTime()), Education.Вachelor, group);
                student.AddExams(new Exam(firstName, students.Count + 3, new DateTime()));
                students.Add(student);
            }
        }

        public void AddStudents(params Student[] addStudents)
        {
            foreach (var item in addStudents)
            {
                students.Add(item);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in students)
            {
                stringBuilder.AppendLine("Student: ");
                stringBuilder.AppendLine(item.ToString());
            }
            return stringBuilder.ToString();
        }

        public string ToShortString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in students)
            {
                stringBuilder.AppendLine("Student: ");
                stringBuilder.Append(item.ToShortString());
                stringBuilder.AppendLine($" Exams: {item.Exams.Count} Tests: {item.Tests.Count}");
            }
            return stringBuilder.ToString();
        }

        public void LastNameSort()
        {
            students.Sort();
        }

        public void DateSort()
        {
            students.Sort(new Person());
        }

        public void GradeSort()
        {
            students.Sort(new StudentComparer());
        }
    }
}
