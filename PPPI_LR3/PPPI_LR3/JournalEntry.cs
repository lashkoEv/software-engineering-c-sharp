using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPI_LR3
{
    class JournalEntry
    {
        private string Name { get; set; }
        private Action CurrentAction { get; set; }
        public string Property { get; set; }
        public string Key { get; set; }

        public JournalEntry(string name, Action action, string property, string key)
        {
            this.Name = name;
            this.CurrentAction = action;
            this.Property = property;
            this.Key = key;
        }

        public override string ToString()
        {
            return $"Name : {Name}, Action: {CurrentAction}, Property: {Property}, Key: {Key}";
        }

    }
}
