using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_LR2
{
    class Student
    {
        private Person person;
        private Education education;
        private int group;
        private Exam[] exams;

        public Person Person 
        { 
            get
            {
                return person;
            }

            set 
            {
                person = value;
            } 
        }
       
        public Education Education
        {
            get
            {
                return education;
            }

            set
            {
                education = value;
            }
        }
       
        public int Group
        {
            get
            {
                return group;
            }

            set
            {
                this.group = value;
            }
        }
        
        public Exam[] Exams
        {
            get
            {
                return this.exams;
            }

            set
            {
                exams = value;
            }
        }
        
        public double AverageGrade
        {
            get
            {
                if(Exams == null || Exams.Length == 0)
                {
                    return 0;
                }

                int count = Exams.Length;
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
            this.Person = new Person();
            this.Education = Education.Вachelor;
            this.Group = 1;
            this.Exams = new Exam[0];
        }

        public Student(Person person, Education education, int group)
        {
            this.Person = person;
            this.Education = education;
            this.Group = group;
            this.Exams = new Exam[0];
        }

        public void AddExams(params Exam[] addExams)
        {
            int j = Exams.Length;
            Array.Resize(ref exams, Exams.Length + addExams.Length);
            for (int i = 0; i < addExams.Length; i++)
            {
                Exams[j++] = addExams[i];
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{Person.ToString()}\nEducation: {Education}\nExams:");

            foreach (var item in exams)
            {
                stringBuilder.Append("\n");
                stringBuilder.Append(item.ToString());
            }
            return stringBuilder.ToString();
        }

        public virtual string ToShortString()
        {
            return $"{Person.ToString()}\nEducation: {Education}\nAverage grade: {this.AverageGrade}";
        }
    }
}
