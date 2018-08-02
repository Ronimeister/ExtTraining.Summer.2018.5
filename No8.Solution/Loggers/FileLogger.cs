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

        public void Register(PrinterManager manager)
        {
            manager.PrintStarted += Log;
            manager.PrintFinished += Log;
        }

        public void Unregister(PrinterManager manager)
        {
            manager.PrintStarted -= Log;
            manager.PrintFinished -= Log;
        }
    }
}

//C:\Users\Алексей\ExtTraining.Summer.2018.5\No8.Solution\bin\Debug\log.txt