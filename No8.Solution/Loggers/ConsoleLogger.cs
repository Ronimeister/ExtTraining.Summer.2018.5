using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Printers;

namespace No8.Solution.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(object sender, PrinterEventArgs args)
        {
            Console.WriteLine($"LOG {DateTime.Now}: {args.Message}");
        }

        public void Warn(string message)
        {
            Console.WriteLine($"WARN {DateTime.Now}: {message}");
        }

        public void Register(Printer printer)
        {
            printer.PrintStarted += Log;
            printer.PrintFinished += Log;
        }

        public void Unregister(Printer printer)
        {
            printer.PrintStarted -= Log;
            printer.PrintFinished -= Log;
        }
    }
}
