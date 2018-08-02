﻿using System;
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
        public string Name { get; }
        public string Model { get; }
        #endregion

        #region .ctors
        public Printer(string name, string model)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} can't be equal to null or empty!");
            }

            if (string.IsNullOrEmpty(model))
            {
                throw new ArgumentException($"{nameof(model)} can't be equal to null or empty!");
            }

            Name = name;
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
            
            PrintEmulation(stream);
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