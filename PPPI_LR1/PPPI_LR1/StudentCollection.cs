using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPI_LR1
{
    class StudentCollection
    {
        private List<Student> students;
        public string Name { get; set; }

        public event EventHandler<StudentListHandlerEventArgs> StudentsCountChanged;
        public event EventHandler<StudentListHandlerEventArgs> StudentReferenceChanged;

        public StudentCollection(string name)
        {
            Name = name;
            students = new List<Student>();
        }

        private void ValidateIndex(int index)
        {
            if (index >= students.Count || index < 1)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public Student this[int index]
        {
            get
            {
                ValidateIndex(index);
                return students[index];
            }

            set
            {
                ValidateIndex(index);
                students[index] = value;
                StudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(Name, "change student", value));
            }
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
                StudentsCountChanged?.Invoke(this, new StudentListHandlerEventArgs(Name, "add default student", student));
            }
        }

        public void AddStudents(params Student[] addStudents)
        {
            foreach (var item in addStudents)
            {
                students.Add(item);
                StudentsCountChanged?.Invoke(this, new StudentListHandlerEventArgs(Name, "add new student", item));
            }
        }

        public bool RemoveStudent(int j)
        {
            if (j >= students.Count || j < 1)
            {
                return false;
            }
            StudentsCountChanged?.Invoke(this, new StudentListHandlerEventArgs(Name, "remove student", students[j]));
            students.RemoveAt(j);
            return true;
        }

    }

    //    public override string ToString()
    //    {
    //        StringBuilder stringBuilder = new StringBuilder();
    //        foreach (var item in students)
    //        {
    //            stringBuilder.AppendLine("Student: ");
    //            stringBuilder.AppendLine(item.ToString());
    //        }
    //        return stringBuilder.ToString();
    //    }

    //    public string ToShortString()
    //    {
    //        StringBuilder stringBuilder = new StringBuilder();
    //        foreach (var item in students)
    //        {
    //            stringBuilder.AppendLine("Student: ");
    //            stringBuilder.Append(item.ToShortString());
    //            stringBuilder.AppendLine($" Exams: {item.Exams.Count} Tests: {item.Tests.Count}");
    //        }
    //        return stringBuilder.ToString();
    //    }

    //    public void LastNameSort()
    //    {
    //        students.Sort();
    //    }

    //    public void DateSort()
    //    {
    //        students.Sort(new Person());
    //    }

    //    public void GradeSort()
    //    {
    //        students.Sort(new StudentComparer());
    //    }
}
