using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPI_LR1
{
    class JournalEntry
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string StudentInfo { get; set; }

        public JournalEntry(string name, string type, string studentInfo)
        {
            Name = name;
            Type = type;
            StudentInfo = studentInfo;
        }

        public override string ToString()
        {
            return $"Name: {Name} Type: {Type} Student: {StudentInfo}";
        }
    }
}
