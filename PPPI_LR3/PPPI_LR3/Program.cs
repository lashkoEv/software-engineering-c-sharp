using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPI_LR3
{
    class Program
    {
        delegate int qq(int x);
        static void Main(string[] args)
        {


            qq qqq = new qq((st) => { return 1; });
            Console.WriteLine(qqq(1));

            //Student student = new Student(new Person("First", "Second", DateTime.Now), Education.SecondEducation, 10);
            //student.AddExams(new Exam(), new Exam(), new Exam());
            //Console.WriteLine($"Primordial student: {student}");
            //Console.WriteLine();
            //Console.WriteLine($"Deep copy student: {student.DeepCopyS()}");
            //Console.WriteLine();

            //Console.Write("Enter a filename: ");
            //string filename = Console.ReadLine();
            //if (File.Exists(filename)) {
            //    Console.WriteLine("File exists."); 
            //    student.Load(filename);
            //}
            //else
            //{
            //    Console.WriteLine("File does not exist.");
            //    student.Save(filename);
            //}
            //Console.WriteLine(student);
            //Console.WriteLine();

            //student.AddFromConsole();
            //student.Save(filename);
            //Console.WriteLine(student);
            //Console.WriteLine();

            //Console.Write("Enter a new filename: ");
            //string newFilename = Console.ReadLine();
            //Student.Save(newFilename, student);
            //Student.Load(newFilename, out student);
            //student.AddFromConsole();
            //Student.Save(newFilename, student);
            //Console.WriteLine(student);
            Console.ReadLine();
        }
    }
}
