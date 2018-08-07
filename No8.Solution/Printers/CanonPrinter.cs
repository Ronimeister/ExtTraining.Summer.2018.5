using System;
using System.IO;

namespace No8.Solution.Printers
{
    public class CanonPrinter : Printer
    {
        public CanonPrinter(string model) : base(model) { }

        public override string Name => "Canon";

        protected override void PrintEmulation(FileStream stream)
        {
            using (stream)
            {
                for(int i = 0; i < stream.Length; i++)
                {
                    stream.ReadByte();
                }
            }
        }
    }
}
