using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Printers;

namespace No8.Solution.Loggers
{
    public class FileLogger : ILogger
    {
        #region Singleton
        private static readonly Lazy<FileLogger> instance =
            new Lazy<FileLogger>(() => new FileLogger());

        private FileLogger() { }

        public static FileLogger GetInstance()
            => instance.Value;
        #endregion

        #region Public logger API
        public void Log(object sender, PrinterEventArgs args)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true, Encoding.UTF8))
            {
                writer.WriteLine($"LOG {DateTime.Now}: {args.Message}");
            }
        }

        public void Warn(string message)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true, Encoding.UTF8))
            {
                writer.WriteLine($"WARN {DateTime.Now}: {message}");
            }
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