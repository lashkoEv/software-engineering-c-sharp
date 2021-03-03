using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_LR3
{
    class Person : IDateAndCopy
    {
        protected string firstName;
        protected string lastName;
        protected DateTime birth;

        public string FirstName { get => this.firstName; set => this.firstName = value; }

        public string LastName { get => this.lastName; set => this.lastName = value; }

       // public DateTime Birth { get => birth; set => this.birth = value; }

        public int Year
        {
            get { return birth.Year; }
            set
            {
                birth = new DateTime(value, birth.Month, birth.Day);
            }
        }

        public DateTime Date { get => birth; set => this.birth = value; }

        public Person()
        {
            this.FirstName = "First name";
            this.LastName = "Last name";
            this.Date = DateTime.Now;
        }

        public Person(string firstName, string lastName, DateTime birth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Date = birth;
        }

        public override string ToString()
        {
            return $"First name: {FirstName}\nLast name: {LastName}\nBirth: {Date}";
        }

        public virtual string ToShortString()
        {
            return $"First name: {FirstName}\nLast name: {LastName}";
        }

        public virtual string ToLongString()
        {
            return $"First name: {FirstName}\nLast name: {LastName}\nBirth: {Date}\nYear: {Year}";
        }

        public override bool Equals(object obj)
        {
            if (obj != null && GetType() == obj.GetType())
            {
                Person person = (Person)obj;
                if (FirstName == person.FirstName && LastName == person.LastName && Date.Date == person.Date.Date && Year == person.Year)
                {
                    return true;
                }
                //if (ToLongString() == person.ToLongString())
                //{
                //    return true;
                //}
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ToLongString().GetHashCode();
        }

        public virtual object DeepCopy()
        {
            Person person = (Person)this.MemberwiseClone();
            person.FirstName = String.Copy(this.FirstName);
            person.LastName = String.Copy(this.LastName);
            person.Date = this.Date;
            person.Year = this.Year;
            return person;
        }

        public static bool operator ==(Person p1, Person p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !p1.Equals(p2);
        } 
    }
}
