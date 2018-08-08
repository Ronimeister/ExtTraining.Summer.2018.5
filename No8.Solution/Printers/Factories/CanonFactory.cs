using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Printers.Factories
{
    public class CanonFactory : AbstractPrinterFactory
    {
        public override Printer CreateNew(string model)
            => new CanonPrinter(model);
    }
}
