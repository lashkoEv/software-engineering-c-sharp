using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPI_LR1
{
    class StudentComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            double first = x.AverageGrade;
            double second = y.AverageGrade;
            return first.CompareTo(second);
        }
    }
}
