using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Printers.Factories
{
    public abstract class AbstractPrinterFactory
    {
        public abstract Printer CreateNew(string model);
    }
}
