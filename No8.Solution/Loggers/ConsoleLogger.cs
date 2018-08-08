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
        #region Singleton
        private static readonly Lazy<ConsoleLogger> instance =
            new Lazy<ConsoleLogger>(() => new ConsoleLogger());

        private ConsoleLogger() { }

        public static ConsoleLogger GetInstance()
            => instance.Value;
        #endregion

        #region Public logger API
        public void Log(object sender, PrinterEventArgs args)
        {
            Console.WriteLine($"LOG {DateTime.Now}: {args.Message}");
        }

        public void Warn(string message)
        {
            Console.WriteLine($"WARN {DateTime.Now}: {message}");
        }
        #endregion

        #region Public events API
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
        #endregion
    }
}
