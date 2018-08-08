using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Printers
{
    public abstract class Printer : IEquatable<Printer>
    {
        #region Properties
        public abstract string Name { get; }
        public string Model { get; }
        #endregion

        #region Events
        public event EventHandler<PrinterEventArgs> PrintStarted = delegate (object source, PrinterEventArgs args) { };
        public event EventHandler<PrinterEventArgs> PrintFinished = delegate (object source, PrinterEventArgs args) { };

        protected virtual void OnPrintStarted(object source, PrinterEventArgs args)
            => PrintStarted(source, args);

        protected virtual void OnPrintFinished(object source, PrinterEventArgs args)
            => PrintFinished(source, args);
        #endregion

        #region .ctors
        public Printer(string model)
        {
            if (string.IsNullOrEmpty(model))
            {
                throw new ArgumentException($"{nameof(model)} can't be equal to null or empty!");
            }

            Model = model;
        }
        #endregion

        #region Public API
        public void Print(FileStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException($"{nameof(stream)} can't be equal to null!");
            }

            OnPrintStarted(this, new PrinterEventArgs(this, $"{this.ToString()} start printing!"));
            PrintEmulation(stream);
            OnPrintFinished(this, new PrinterEventArgs(this, $"{this.ToString()} finish printing!"));
        }

        public override int GetHashCode()
        {
            int result = 0;

            foreach(char c in Name.ToCharArray())
            {
                result += c;
            }

            foreach(char c in Model.ToCharArray())
            {
                result += c;
            }

            int salt = Convert.ToInt32(DateTime.Now.Ticks.ToString().Substring(0, 5));

            return result + salt;
        }

        public override bool Equals(object obj)
        {
            if (this is null)
            {
                return false;
            }

            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return Equals((Printer)obj);
        }

        public bool Equals(Printer other)
        {
            if (this is null)
            {
                return false;
            }

            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return (Name == other.Name) && (Model == other.Model);
        }

        public override string ToString() => $"{GetType().Name}: {Name} {Model}";
        #endregion

        #region Abstract methods
        protected abstract void PrintEmulation(FileStream stream);
        #endregion
    }
}
