using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Printers
{
    public sealed class PrinterEventArgs : EventArgs
    {
        public string Name { get; }
        public string Model { get; }
        public string Message { get; }

        public PrinterEventArgs(Printer printer, string message)
        {
            if (printer == null)
            {
                throw new ArgumentNullException($"{nameof(printer)} can't be equal to null!");
            }
            
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException($"{nameof(message)} can't be equal to null or empty!");
            }

            if (printer.Model == null)
            {
                throw new ArgumentNullException($"{nameof(printer.Model)} can't be equal to null!");
            }

            if (printer.Name == null)
            {
                throw new ArgumentNullException($"{nameof(printer.Name)} can't be equal to null!");
            }

            Name = printer.Name;
            Model = printer.Model;
            Message = message;
        }
    }
}
