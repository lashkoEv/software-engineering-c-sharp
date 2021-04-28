using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPI_LR2
{
    class TestCollections
    {
        private List<Person> listPersons;
        private List<string> listStrings;
        private Dictionary<Person, Student> dictionaryPersonStudent;
        private Dictionary<string, Student> dictionaryStringStudent;

        static Student genericInit(int count)
        {
            string firstName = $"FirstName{count}";
            string lastName = $"LastName{count}";
           return new Student(new Person(firstName, lastName, new DateTime()), Education.Вachelor, 5);
        }

        public TestCollections(int count)
        {
            listPersons = new List<Person>();
            listStrings = new List<string>();
            dictionaryPersonStudent = new Dictionary<Person, Student>();
            dictionaryStringStudent = new Dictionary<string, Student>();
            for (int i = 0; i < count; i++)
            {
                Student student = genericInit(i);
                listPersons.Add(student.Person);
                listStrings.Add(student.ToString());
                dictionaryPersonStudent.Add(student.Person, student);
                dictionaryStringStudent.Add(student.ToString(), student);
            }
        }

        public void checkTime(int index)
        {
            Student student = genericInit(index);
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            if (listPersons.Contains(student.Person))
            {
                stopWatch.Stop();
                Console.WriteLine($"Time for list of persons: {stopWatch.Elapsed}");
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine($"No item! Time: {stopWatch.Elapsed}");
            }


            stopWatch.Restart();
            if (listStrings.Contains(student.ToString()))
            {
                stopWatch.Stop();
                Console.WriteLine($"Time for list of strings: {stopWatch.Elapsed}");
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine($"No item! Time: {stopWatch.Elapsed}");
            }

            stopWatch.Restart();
            if (dictionaryPersonStudent.ContainsKey(student.Person))
            {
                stopWatch.Stop();
                Console.WriteLine($"Time for dictionary Person Student (key): {stopWatch.Elapsed}");
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine($"No item! Time: {stopWatch.Elapsed}");
            }

            stopWatch.Restart();
            if (dictionaryStringStudent.ContainsKey(student.ToString()))
            {
                stopWatch.Stop();
                Console.WriteLine($"Time for dictionary String Student (key): {stopWatch.Elapsed}");
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine($"No item! Time: {stopWatch.Elapsed}");
            }

            stopWatch.Restart();
            if (dictionaryPersonStudent.ContainsValue(student))
            {
                stopWatch.Stop();
                Console.WriteLine($"Time for dictionary Person Student (value): {stopWatch.Elapsed}");
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine($"No item! Time: {stopWatch.Elapsed}");
            }

            stopWatch.Restart();
            if (dictionaryStringStudent.ContainsValue(student))
            {
                stopWatch.Stop();
                Console.WriteLine($"Time for dictionary String Student (value): {stopWatch.Elapsed}");
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine($"No item! Time: {stopWatch.Elapsed}");
            }
        }
    }
}
