using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_LR3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Person == != GetHashCode()");
            Console.WriteLine("---------------------------------------------");
            Person p1 = new Person("New", "Person", new DateTime());
            Person p2 = new Person("New", "Person", new DateTime());
            Console.WriteLine(p1 == p2);
            Console.WriteLine(p1 != p2);
            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(p2.GetHashCode());

            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("Student, add tests and exams");
            Console.WriteLine("---------------------------------------------");
            Student student = new Student();
            student.AddExams(new Exam(), new Exam());
            student.AddTests(new Test(), new Test());
            Console.WriteLine(student.ToString());
            Console.WriteLine(student.ToShortString());
            
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("student.Person.ToString()");
            Console.WriteLine("---------------------------------------------"); 
            Console.WriteLine(student.Person.ToString());
           
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("DeepCopy()");
            Console.WriteLine("---------------------------------------------");
            Student cstudent = (Student)student.DeepCopy();
            cstudent.FirstName = "NewName";
            cstudent.Exams[0].Name = "KPZ";
            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(cstudent);

            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("try/catch");
            Console.WriteLine("---------------------------------------------");
            try
            {
                student.Group = -1;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            student.Exams[1].Grade = 2;
            student.AddTests(new Test("KPZ", true), new Test("OOP", true));
            student.AddExams(new Exam("KPZ", 5, new DateTime()), new Exam("OOP", 5, new DateTime()));
            student.AddTests(new Test("KPZ_2", false));


            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("All tests and exams iterator");
            Console.WriteLine("---------------------------------------------");
            foreach (Object o in student.UnionIterator())
            {
                Console.WriteLine(o);
            }

            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("Parameter iterator (grade > 3)");
            Console.WriteLine("---------------------------------------------");
            foreach (Exam ex in student.ParameterIterator(3))
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("StudentEnumerator (subject with test and exam)");
            Console.WriteLine("---------------------------------------------");
            foreach (Object o in student)
            {
                Console.WriteLine(o);
            }

            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("Passed tests and exams iterator");
            Console.WriteLine("---------------------------------------------");
            foreach (Object o in student.PassedIterator())
            {
                Console.WriteLine(o);
            }

            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("Passed tests iterator");
            Console.WriteLine("---------------------------------------------");
            foreach (Test t in student.PassedTestIterator())
            {
                Console.WriteLine(t);
            }
            Console.ReadKey();
        }
    }
}
