using No8.Solution.Loggers;
using No8.Solution.Printers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace No8.Solution
{
    public class PrinterManager
    {
        #region Private fields
        private readonly ILogger _logger;
        #endregion

        #region Properties
        public HashSet<Printer> Printers { get; }
        #endregion

        #region .ctors
        public PrinterManager(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} can't be equal to null!");
            Printers = new HashSet<Printer>();
        }
        #endregion

        #region Public API
        public void Add(Printer printer)
        {
            if (printer == null)
            {
                string exceptionMessage = $"{nameof(printer)} can't be equal to null or empty!";
                _logger.Warn(exceptionMessage);

                throw new ArgumentNullException(exceptionMessage);
            }

            if (Printers.Contains(printer))
            {
                string exceptionMessage = $"{nameof(printer)} is already in the printers list!";
                _logger.Warn(exceptionMessage);

                throw new ArgumentException(exceptionMessage);
            }

            _logger.Register(printer);
            Printers.Add(printer);
        }

        public void Print(Printer printer)
        {
            if (printer == null)
            {
                string exceptionMessage = $"{nameof(printer)} can't be equal to null!";
                _logger.Warn(exceptionMessage);

                throw new ArgumentNullException(exceptionMessage);
            }

            if (!Printers.Contains(printer))
            {
                string exceptionMessage = $"There is no such {nameof(printer)} in the printers list!";
                _logger.Warn(exceptionMessage);

                throw new ArgumentException(exceptionMessage);
            }

            PrintInner(printer);
        }

        public void Remove(Printer printer)
        {
            if (printer == null)
            {
                string exceptionMessage = $"{nameof(printer)} can't be equal to null or empty!";
                _logger.Warn(exceptionMessage);

                throw new ArgumentNullException(exceptionMessage);
            }

            if (!Printers.Contains(printer))
            {
                string exceptionMessage = $"There is no such {nameof(printer)} in the printers list!";
                _logger.Warn(exceptionMessage);

                throw new ArgumentException(exceptionMessage);
            }

            Printers.Remove(printer);
        }
        #endregion

        #region Private methods
        private void PrintInner(Printer printer)
        {
            using (OpenFileDialog o = new OpenFileDialog())
            {
                o.ShowDialog();
                using (var stream = File.OpenRead(o.FileName))
                {
                    printer.Print(stream);
                }
            }
        }
        #endregion
    }
}