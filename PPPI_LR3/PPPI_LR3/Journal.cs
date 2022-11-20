using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPI_LR3
{
    class Journal<TKey>
    {
        private List<JournalEntry> entries;
        public Journal()
        {
            entries = new List<JournalEntry>();
        }
        public void StudentChanged(object sender, StudentsChangedEventArgs<TKey> handlerEventArgs)
        {
            JournalEntry entry = new JournalEntry(handlerEventArgs.Name,
                handlerEventArgs.CurrentAction, handlerEventArgs.Property, handlerEventArgs.Key.ToString());
            entries.Add(entry);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in entries)
            {
                stringBuilder.AppendLine(item.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
