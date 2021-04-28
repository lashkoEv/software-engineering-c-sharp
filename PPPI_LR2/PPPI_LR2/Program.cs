using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPI_LR2
{
    class Program
    {
        static void Main(string[] args)
        {
            int uniqueKey = 0;
            StudentCollection<string> firstCollection = new StudentCollection<string>(s => s.FirstName + s.LastName + (++uniqueKey).ToString());
            firstCollection.Name = "First Collection";
            StudentCollection<string> secondCollection = new StudentCollection<string>(s => s.FirstName + s.LastName + (++uniqueKey).ToString());
            secondCollection.Name = "Second Collection";
           
            Journal<string> journal = new Journal<string>();
            firstCollection.StudentsChanged += journal.StudentChanged;
            secondCollection.StudentsChanged += journal.StudentChanged;

            firstCollection.AddDefaults(2);
            secondCollection.AddDefaults(2);

            Student st1 = new Student(new Person("FirstName", "LastName", new DateTime()), Education.Вachelor, 100);
            st1.AddExams(new Exam(), new Exam());
            st1.Year = 1999;
            Student st2 = new Student(new Person("FirstName", "LastName", new DateTime(2014, 2, 3)), Education.Вachelor, 100);
            st2.AddExams(new Exam("1", 1, new DateTime()), new Exam("3", 1, new DateTime()), new Exam("2", 8, new DateTime()));
            st2.Year = 2020;
            Student st3 = new Student(new Person("FirstName", "LastName", new DateTime()), Education.Вachelor, 100);
            st3.AddExams(new Exam("Exam", 10, new DateTime()));
            Student st4 = new Student(new Person("FirstName", "LastName", new DateTime()), Education.Вachelor, 100);
            st4.AddExams(new Exam("Exam", 12, new DateTime()));
            firstCollection.AddStudents(st1);
            secondCollection.AddStudents(st2);
            firstCollection.AddStudents(st3);
            secondCollection.AddStudents(st4);
            firstCollection.AddStudents(new Student(new Person("FirstName", "LastName", new DateTime(2019, 2, 2)), Education.Specialist, 92));
            secondCollection.AddStudents(new Student(new Person("FirstName", "LastName", new DateTime(2019, 2, 2)), Education.SecondEducation, 92));

            firstCollection[0].Group = 5;
            secondCollection[0].Education = Education.SecondEducation;

            firstCollection.Remove(st1);
            firstCollection.Remove(st2);
            secondCollection.Remove(st1);
            secondCollection.Remove(st2);

            st1.Group = 8;
            st2.Education = Education.SecondEducation;

            Console.WriteLine("\nJournal ---------------------------------------------");
            Console.WriteLine(journal.ToString());

            Console.WriteLine("\nMethods ---------------------------------------------");

            Console.WriteLine($"Max average grade for first collection: {firstCollection.MaxAverageGrade}");

            Console.WriteLine();
            Console.WriteLine("EducationForm for Вachelor: ");
            foreach (var item in firstCollection.EducationForm(Education.Вachelor))
            {
                Console.WriteLine(item.Value.ToShortString());
            }

            Console.WriteLine();
            Console.WriteLine("Group by Education:");
            firstCollection.AddStudents(new Student(new Person(), Education.Specialist, 90));
            firstCollection.AddStudents(new Student(new Person(), Education.SecondEducation, 92));
            foreach (var tmp in firstCollection.GroupByEducation)
            {
                Console.WriteLine(tmp.Key.ToString() + ":");
                foreach (var item in tmp)
                {
                    Console.WriteLine(item.Value.ToShortString());
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
