using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace PPPI_LR3
{
    [DataContract]
    [Serializable]
    public class Student : Person, IDateAndCopy, //IEnumerable,
        INotifyPropertyChanged
    {
        private Education education;
        private int group;
        private List<Test> tests;
        private List<Exam> exams;

        public event PropertyChangedEventHandler PropertyChanged;

        [DataMember]
        public Education Education { get => education; 
            set { 
                education = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change education"));
            } 
        }

        [DataMember]
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change group"));
            }
        }

        [DataMember]
        public List<Exam> Exams { get => this.exams; set
            {
                exams = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change exams"));
            }
        }

        [DataMember]
        public List<Test> Tests { get => this.tests; set
            {
                tests = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change tests"));
            }
        }

        [DataMember]
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change person"));
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add exams"));
        }

        public void AddTests(params Test[] addTests)
        {
            foreach (var item in addTests)
            {
                Tests.Add(item);
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add tests"));
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{base.ToString()}\nEducation: {Education}\nGroup: {Group}\nExams:");

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
            return $"{base.ToString()} Education: {Education} Group: {Group} Average grade: {this.AverageGrade}";
        }

        public override object DeepCopy()
        {
            Student student = new Student();
            student.Education = this.Education;
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
            foreach (var p in passed)
            {
                yield return p;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(this);
        }

        public Student DeepCopyS()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, this);
            memoryStream.Seek(0, SeekOrigin.Begin);
            Student newStudent = (Student)binaryFormatter.Deserialize(memoryStream);
            memoryStream.Close();
            return newStudent;
        }
        public bool Save(string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
            Stream stream = null;
            try
            {
                stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                xmlSerializer.Serialize(stream, this);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if(stream != null)
                {
                    stream.Close();
                }
            }
            return true;
        }

        public bool Load(string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
            Stream stream = null;
            Student st = null;
            try
            {
                stream = File.OpenRead(filename);
                st = (Student)xmlSerializer.Deserialize(stream);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            if(st != null)
            {
                this.Education = st.Education;
                this.Group = st.Group;
                this.Date = st.Date;
                this.Exams.Clear();
                st.Exams.ForEach(delegate (Exam item)
                {
                    this.AddExams((Exam)item.DeepCopy());
                });
                this.FirstName = String.Copy(st.FirstName);
                this.LastName = String.Copy(st.LastName);
                this.Year = st.Year;
                this.Tests.Clear();
                st.Tests.ForEach(delegate (Test item)
                {
                    this.AddTests(item);
                });
            }
            return true;
        }

        public static bool Save(string filename, Student st)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Student));
            Stream stream = null;
            try
            {
                stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                jsonSerializer.WriteObject(stream, st);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return true;
        }

        public static bool Load(string filename, out Student st)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Student)); 
            Stream stream = null;
            st = null;
            try
            {
                stream = File.OpenRead(filename);
                st = (Student)jsonSerializer.ReadObject(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return true;
        }

        public bool AddFromConsole()
        {
            Console.Write("Enter a name (eg: Exam1), grade(eg: 12), date(eg: 10.01.2021) (delimiter: !_ *): ");
            string stringToParce = Console.ReadLine();
            string[] words = stringToParce.Split(new char[] { ' ', '!', '_', '*' });
            Exam exam = null;
            try
            {
                exam = new Exam(words[0], Int32.Parse(words[1]), DateTime.Parse(words[2]));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            if(exam != null)
            {
                AddExams(exam);
            }
            return true;
        }
    }
}
