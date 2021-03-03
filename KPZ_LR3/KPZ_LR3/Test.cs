using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_LR3
{
    class Test : IDateAndCopy
    {
        public string Name { get; set; }

        public bool IsDone { get; set; }

        public DateTime Date { get; set; }

        public Test()
        {
            Name = "New Test";
            IsDone = true;
        }

        public Test(string name, bool isDone)
        {
            Name = name;
            IsDone = isDone;
        }

        public override string ToString()
        {
            return $"Name: {Name}\tIs done: {IsDone}";
        }

        public object DeepCopy()
        {
            Test exam = new Test();
            exam.Name = String.Copy(this.Name);
            exam.IsDone = this.IsDone;
            exam.Date = this.Date;
            return exam;
        }
    }
}
