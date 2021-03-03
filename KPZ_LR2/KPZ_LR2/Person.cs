using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_LR2
{
    class Person
    {
        private string firstName;
        private string lastName;
        private DateTime birth;

        public string FirstName 
        { 
            get 
            { 
                return this.firstName; 
            } 
            
            set 
            { 
                this.firstName = value; 
            } 
        }
       
        public string LastName 
        {
            get 
            { 
                return this.lastName;
            }

            set 
            {
                this.lastName = value;
            } 
        }
      
        public DateTime Birth 
        { 
            get 
            {
                return birth;
            } 
            
            set 
            {
                // this.birth = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
                this.birth = value;
            } 
        }
      
        public int Year
        {
            get 
            { 
                return birth.Year; 
            }

            set 
            {
                birth = new DateTime(birth.Day, birth.Month, value);
            }
        }

        public Person()
        {
            this.FirstName = "First name";
            this.LastName = "Last name";
            this.Birth = DateTime.Now;
        }

        public Person(string firstName, string lastName, DateTime birth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birth = birth;
        }

        public override string ToString()
        {
            return $"First name: {FirstName}\nLast name: {LastName}\nBirth: {Birth}";
        }

        public virtual string ToShortString()
        {
            return $"First name: {FirstName}\nLast name: {LastName}";
        }

    }
}
