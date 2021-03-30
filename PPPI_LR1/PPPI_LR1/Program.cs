using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPI_LR1
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection studentCollection = new StudentCollection("First collection");
            StudentCollection studentCollection2 = new StudentCollection("Second collection");
            
            Journal journal = new Journal();
            studentCollection.StudentsCountChanged += journal.StudentsCountChanged;
            studentCollection.StudentReferenceChanged += journal.StudentReferenceChanged;

            Journal journal2 = new Journal();
            studentCollection.StudentReferenceChanged += journal2.StudentReferenceChanged;
            studentCollection2.StudentReferenceChanged += journal2.StudentReferenceChanged;

            studentCollection.AddDefaults(5);
            studentCollection.AddStudents(new Student(new Person("a", "a", new DateTime()), Education.Вachelor, 100));
            studentCollection2.AddDefaults(5);
            studentCollection2.AddStudents(new Student(new Person("b", "b", new DateTime(2019, 2, 2)), Education.Вachelor, 92));

            studentCollection.RemoveStudent(2);
            studentCollection2.RemoveStudent(2);

            studentCollection[1] = new Student(new Person("NewName", "NewName", new DateTime()), Education.Вachelor, 100);
            studentCollection2[1] = new Student(new Person("NewName", "NewName", new DateTime()), Education.Вachelor, 100);

            Console.WriteLine(journal);
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine(journal2);

            Console.ReadKey();
        }
    }
}
