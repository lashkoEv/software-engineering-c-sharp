using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_LR3
{
    class StudentEnumerator : IEnumerator
    {
        IEnumerable<string> names;
        int position = -1;

        public StudentEnumerator(Student student)
        {
            List<string> names1 = new List<string>();
            List<string> names2 = new List<string>();
            foreach (Exam ex in student.Exams)
            {
                names1.Add(ex.Name);
            }
            foreach (Test t in student.Tests)
            {
                names2.Add(t.Name);
            }
            names = (from n1 in names1 join n2 in names2 on n1 equals n2 select n1).Distinct();
        }

        public object Current
        {
            get
            {
                if(position == -1 || position >= names.Count())
                {
                    throw new InvalidOperationException();
                }
                return names.ElementAt(position);
            }
        }

        public bool MoveNext()
        {
            if(position < names.Count() - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
