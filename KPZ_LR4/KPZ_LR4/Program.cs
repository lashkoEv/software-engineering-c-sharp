using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_LR4
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection studentCollection = new StudentCollection();
            studentCollection.AddDefaults(2);
            Student st1 = new Student(new Person("a", "a", new DateTime()), Education.Вachelor, 100);
            st1.AddExams(new Exam(), new Exam());
            st1.Year = 1999;
            studentCollection.AddStudents(st1);
            Student st2 = new Student(new Person("c", "c", new DateTime(2014, 2, 3)), Education.Вachelor, 100);
            st2.AddExams(new Exam("1", 1, new DateTime()), new Exam("3", 3, new DateTime()), new Exam("2", 2, new DateTime()));
            st2.Year = 2020;
            studentCollection.AddStudents(st2);
            studentCollection.AddStudents(new Student(new Person("b", "b", new DateTime(2019, 2, 2)), Education.Вachelor, 92));

            Console.WriteLine("\nBefore Sort ---------------------------------------------");
            Console.WriteLine(studentCollection.ToShortString());
            Console.WriteLine("\nLast Name Sort ------------------------------------------");
            studentCollection.LastNameSort();
            Console.WriteLine(studentCollection.ToShortString());
            Console.WriteLine("\nGrade Sort ----------------------------------------------");
            studentCollection.GradeSort();
            Console.WriteLine(studentCollection.ToShortString());
            Console.WriteLine("\nDate Sort -----------------------------------------------");
            studentCollection.DateSort();
            Console.WriteLine(studentCollection.ToShortString());

            Console.WriteLine("\n");
            int count = 50000;
            TestCollections t = new TestCollections(count);
            Console.WriteLine("\nFirst elment --------------------------------------------");
            t.checkTime(0);
            Console.WriteLine("\nMidle elment --------------------------------------------");
            t.checkTime(count / 2);
            Console.WriteLine("\nLast elment ---------------------------------------------");
            t.checkTime(count - 1);
            Console.WriteLine("\nOut of range --------------------------------------------");
            t.checkTime(count + 5);
            Console.ReadKey();
        }
    }
}
