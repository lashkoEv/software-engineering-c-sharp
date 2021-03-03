using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_LR3
{
    class Student : Person, IDateAndCopy, IEnumerable
    {
        private Education education;
        private int group;
        private List<Test> tests;
        private List<Exam> exams;

        public Education Education { get => education; set => education = value; }

        public int Group
        {
            get => group; 
            set
            {
                if (value <= 1 || value > 100)
                {
                    throw new Exception("Range [1, 100]!");
                }
                this.group = value;
            }
        }

        public List<Exam> Exams { get => this.exams; set => exams = value; }
        public List<Test> Tests { get => this.tests; set => tests = value; }

        public Person Person
        {
            get
            { 
                return new Person(base.FirstName, base.LastName, base.Date);
            }

            set
            {
                base.FirstName = value.FirstName;
                base.LastName = value.LastName;
                base.Date = value.Date;
                base.Year = value.Year;
            }
        }
        public double AverageGrade
        {
            get
            {
                if (Exams == null || Exams.Count == 0)
                {
                    return 0;
                }

                int count = Exams.Count;
                int grades = 0;
                for (int i = 0; i < count; i++)
                {
                    grades += Exams[i].Grade;
                };
                return Math.Round((double)grades / count, 2);
            }
        }

        public Student() 
        {
            this.Education = Education.Вachelor;
            this.Group = 5;
            Exams = new List<Exam>();
            Tests = new List<Test>();
            Date = new DateTime();
        }

        public Student(Person person, Education education, int group) 
            : base(person.FirstName, person.LastName, person.Date)
        {
            this.Education = education;
            this.Group = group;
            Exams = new List<Exam>();
            Tests = new List<Test>();
        }

        public void AddExams(params Exam[] addExams)
        {
            foreach (var item in addExams)
            {
                Exams.Add(item);
            }
        }

        public void AddTests(params Test[] addTests)
        {
            foreach (var item in addTests)
            {
                Tests.Add(item);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{base.ToString()}\nEducation: {Education}\nExams:");

            foreach (var item in exams)
            {
                stringBuilder.Append("\n");
                stringBuilder.Append(item.ToString());
            }

            stringBuilder.Append("\nTests: ");
            foreach (var item in tests)
            {
                stringBuilder.Append("\n");
                stringBuilder.Append(item.ToString());
            }

            return stringBuilder.ToString();
        }

        public new virtual string ToShortString()
        {
            return $"{base.ToString()}\nEducation: {Education}\nAverage grade: {this.AverageGrade}";
        }

        public override object DeepCopy()
        {
            Student student = new Student();
            student.Group = this.Group;
            student.Date = this.Date;
            this.Exams.ForEach(delegate (Exam item)
            {
                student.AddExams((Exam)item.DeepCopy());
            });
            student.FirstName = String.Copy(this.FirstName);
            student.LastName = String.Copy(this.LastName);
            student.Year = this.Year;
            this.Tests.ForEach(delegate (Test item)
            {
                student.AddTests(item);
            });
            return student;
        }

        public IEnumerable UnionIterator()
        {
            foreach (Exam ex in exams)
            {
                yield return ex;
            }
            foreach (Test t in tests)
            {
                yield return t;
            }
        }

        public IEnumerable ParameterIterator(int value)
        {
            foreach (Exam ex in exams)
            {
                if (ex.Grade > value)
                {
                    yield return ex;
                }
            }
        }

        public IEnumerable PassedIterator()
        {
            int min = 2;
            foreach (Exam ex in exams)
            {
                if (ex.Grade > min)
                {
                    yield return ex;
                }
            }
            foreach (Test t in tests)
            {
                if (t.IsDone)
                {
                    yield return t;
                }
            }
        }

        public IEnumerable PassedTestIterator()
        {
            int min = 2;
            IEnumerable<Test> passed = (from t in Tests 
                                        join e in Exams on t.Name equals e.Name 
                                        where t.IsDone == true
                                        where e.Grade > min
                                        select t).Distinct();
            foreach(var p in passed)
            {
                yield return p;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(this);
        }
    }
}
