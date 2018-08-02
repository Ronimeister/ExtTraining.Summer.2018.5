using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Printers
{
    public class EpsonPrinter : Printer
    {
        public EpsonPrinter(string name, string model) : base(name, model) { }

        protected override void PrintEmulation(FileStream stream)
        {
            using (stream)
            {
                for (int i = 0; i < stream.Length; i++)
                {
                    stream.ReadByte();
                }
            }
        }
    }
}
