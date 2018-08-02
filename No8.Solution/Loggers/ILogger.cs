using No8.Solution.Printers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Loggers
{
    public interface ILogger
    {
        void Log(object sender, PrinterEventArgs args);
        void Warn(string message);

        void Register(PrinterManager manager);
        void Unregister(PrinterManager manager);
    }
}
