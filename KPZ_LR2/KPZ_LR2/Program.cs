using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_LR2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student();
            Console.WriteLine(student1.ToString());
            Console.WriteLine();
          
            student1.Person = new Person("John", "Doe", new DateTime(2014, 7, 7));
            student1.Education = Education.Specialist;
            student1.Group = 3;
            student1.Exams = new Exam[] { new Exam(), new Exam(), new Exam("New exam", 3, new DateTime(2020, 1, 1)) };
            Console.WriteLine(student1.ToShortString());
            Console.WriteLine();

            Student student2 = new Student(new Person("Helen", "Maxvell", new DateTime(1970, 1, 5)), Education.SecondEducation, 2);
            Console.WriteLine(student2.ToString());
            Console.WriteLine();

            student2.AddExams(new Exam[] { new Exam(), new Exam(), new Exam("New exam", 3, new DateTime(2020, 1, 1)) });
            Console.WriteLine(student2.ToString());
            Console.WriteLine();

            Console.Write("Enter a number of rows and columns (delimiter: !_ *): ");
            string stringToParce = Console.ReadLine();
            string[] numbers = stringToParce.Split(new char[] { ' ', '!', '_', '*'});
            int rows = Int32.Parse(numbers[0]);
            int cols = Int32.Parse(numbers[1]);

            Exam[] exams1 = new Exam[rows * cols];
            for (int i = 0; i < exams1.Length; i++)
            {
                exams1[i] = new Exam();
            }
            
            Exam[,] exams2 = new Exam[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    exams2[i, j] = new Exam();
                }
            }
       
            Exam[][] exams3 = new Exam[rows][];
            for (int i = 0; i < rows; i++)
            {
                exams3[i] = new Exam[cols];
                for (int j = 0; j < cols; j++)
                {
                    exams3[i][j] = new Exam();
                }
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < exams1.Length; i++)
            {
                exams1[i].Grade = 10;
            }
            stopWatch.Stop();
            Console.WriteLine($"Time for one-dimensional array: {stopWatch.Elapsed}");

            stopWatch.Restart();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    exams2[i, j].Grade = 10;
                }
            }
            stopWatch.Stop();
            Console.WriteLine($"Time for rectangular array: {stopWatch.Elapsed}");

            stopWatch.Restart();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    exams3[i][j].Grade = 10;
                }
            }
            stopWatch.Stop();
            Console.WriteLine($"Time for jagged array array: {stopWatch.Elapsed}");

            Console.WriteLine($"Number of rows: {rows}");
            Console.WriteLine($"Number of columns: {cols}");
            
            Console.ReadKey();
        }
    }
}
