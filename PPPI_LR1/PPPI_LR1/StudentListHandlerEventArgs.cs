using System;

namespace PPPI_LR1
{
    class StudentListHandlerEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Student StudentRefference { get; set; }
       
        public StudentListHandlerEventArgs(string name, string type, Student student)
        {
            Name = name;
            Type = type;
            StudentRefference = student;
        }

        public override string ToString()
        {
            return $"Name: {Name} Type: {Type} Student: {StudentRefference}";
        }
    }
}