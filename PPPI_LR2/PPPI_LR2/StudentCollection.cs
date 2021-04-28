using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PPPI_LR2
{
    delegate TKey KeySelector<TKey>(Student st);

    class StudentCollection<TKey>
    {
        public delegate void StudentsChangedHandler<TKey>(object sender, StudentsChangedEventArgs<TKey> args);
        public event StudentsChangedHandler<TKey> StudentsChanged;

        private KeySelector<TKey> keySelector;
        private Dictionary<TKey, Student> students;
        
        public string Name { get; set; }


        public StudentCollection(KeySelector<TKey> selector)
        {
            keySelector = selector;
            this.students = new Dictionary<TKey, Student>();
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
                student.PropertyChanged += StudentChanged;
                students.Add(keySelector(student), student);
                StudentsChanged?.Invoke(this, new StudentsChangedEventArgs<TKey>(Name, Action.Add,
                    "Add default students", keySelector(student)));
            }
        }

        public void AddStudents(params Student[] addStudents)
        {
            foreach (var item in addStudents)
            {
                Student student = (Student)item.DeepCopy();
                student.PropertyChanged += StudentChanged;
                students.Add(keySelector(student), student);
                StudentsChanged?.Invoke(this, new StudentsChangedEventArgs<TKey>(Name, Action.Add,
                    "Add students", keySelector(student)));
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in students.Values)
            {
                stringBuilder.AppendLine("Student: ");
                stringBuilder.AppendLine(item.ToString());
            }
            return stringBuilder.ToString();
        }

        public string ToShortString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in students.Values)
            {
                stringBuilder.AppendLine("Student: ");
                stringBuilder.Append(item.ToShortString());
                stringBuilder.AppendLine($" Exams: {item.Exams.Count} Tests: {item.Tests.Count}");
            }
            return stringBuilder.ToString();
        }

        public bool Remove(Student st)
        {
            try
            {
                foreach (var item in students)
                {
                    if (item.Value.Equals(st))
                    {
                        students[item.Key].PropertyChanged -= StudentChanged;
                        StudentsChanged?.Invoke(this, new StudentsChangedEventArgs<TKey>(Name, Action.Remove,
                            "Remove student", keySelector(students[item.Key])));
                        students.Remove(item.Key);
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void StudentChanged(object sender, PropertyChangedEventArgs handlerEvent)
        {
            StudentsChanged?.Invoke(this, new StudentsChangedEventArgs<TKey>(Name, Action.Property,
                handlerEvent.PropertyName, keySelector((Student)sender)));
        }

        public Student this[int index]
        {
            get
            {
                int count = 0;
                Student tmp = default;
                foreach (var item in students.Values)
                {
                    if (count == index)
                    {
                         tmp = item;
                    }
                    count++;
                }
                return tmp;
            }
        }

        public double MaxAverageGrade { 
            get
            {
                double max = -1;
                max = students.Values.Max(student => student.AverageGrade);
                return max;
            } 
        }

        public IEnumerable<KeyValuePair<TKey, Student>> EducationForm(Education value)
        {
            return students.Where(student => student.Value.Education.Equals(value));
        }

        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> GroupByEducation
        {
            get
            {
                return students.GroupBy(student => student.Value.Education);
            }
        }
    }
}
