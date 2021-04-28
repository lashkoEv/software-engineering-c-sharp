using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPI_LR2
{
    class StudentsChangedEventArgs<TKey> : EventArgs
    {
        public string Name { get; set; }
        public Action CurrentAction { get; set; }
        public string Property { get; set; }
        public TKey Key { get; set; }

        public StudentsChangedEventArgs(string name, Action action, string property, TKey key)
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
