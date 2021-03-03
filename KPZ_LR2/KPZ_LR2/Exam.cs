using System;

namespace KPZ_LR2
{
    class Exam
    {
        public string Name
        {
            get;
            set;
        }

        public int Grade {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public Exam()
        {
            this.Name = "Exam";
            this.Grade = 5;
            this.Date = DateTime.Now;
        }

        public Exam(string name, int grade, DateTime date)
        {
            this.Name = name;
            this.Grade = grade;
            this.Date = date;
        }

        public override string ToString()
        {
            return $"Name: {Name}\tGrade: {Grade}\tDate: {Date}";
        }
    }
}
