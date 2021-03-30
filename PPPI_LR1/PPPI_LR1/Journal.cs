using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPI_LR1
{
    class Journal
    {
        List<JournalEntry> entries;

        public Journal()
        {
            entries = new List<JournalEntry>();
        }

        public void StudentsCountChanged(object sender, StudentListHandlerEventArgs e)
        {
            if(sender is StudentCollection studentCollection)
            {
                entries.Add(new JournalEntry(e.Name, e.Type, e.StudentRefference.ToShortString()));
            }
        }

        public void StudentReferenceChanged(object sender, StudentListHandlerEventArgs e)
        {
            if (sender is StudentCollection studentCollection)
            {
                entries.Add(new JournalEntry(e.Name, e.Type, e.StudentRefference.ToShortString()));
            }
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
