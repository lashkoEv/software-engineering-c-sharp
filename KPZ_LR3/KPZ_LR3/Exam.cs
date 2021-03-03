using System;

namespace KPZ_LR3
{
    class Exam : IDateAndCopy
    {
        public string Name
        {
            get;
            set;
        }

        public int Grade
        {
            get;
            set;
        }

        public DateTime Date{get;set;}

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

        public object DeepCopy()
        {
            Exam exam = new Exam();
            exam.Name = String.Copy(this.Name);
            exam.Grade = this.Grade;
            exam.Date = this.Date;
            return exam;
        }
    }
}
