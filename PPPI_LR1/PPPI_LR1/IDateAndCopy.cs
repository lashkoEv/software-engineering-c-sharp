using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPI_LR1
{
    interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
}
