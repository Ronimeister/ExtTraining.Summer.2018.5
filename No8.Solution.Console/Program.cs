using No8.Solution.Loggers;
using No8.Solution.Printers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Console
{
    class Program
    {
        private static bool isFinished = false;
        private static readonly PrinterManager manager = new PrinterManager(new ConsoleLogger());

        [STAThread]
        static void Main(string[] args)
        {
            do
            {
                ShowMenu();
                MenuAction(System.Console.ReadKey());
                System.Console.WriteLine();
            }
            while (!isFinished);
        }

        private static void ShowMenu()
        {
            System.Console.WriteLine("Menu:");
            System.Console.WriteLine("1. Show printers list.");
            System.Console.WriteLine("2. Add new printer.");
            System.Console.WriteLine("3. Print files.");
            System.Console.WriteLine("4. Exit.");
        }

        private static void MenuAction(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.D1)
            {
                System.Console.Clear();
                System.Console.WriteLine("----------------------------------------");
                ShowPrinters();
                System.Console.WriteLine("----------------------------------------");
            }

            if (key.Key == ConsoleKey.D2)
            {
                AddNewPrinter();
            }

            if (key.Key == ConsoleKey.D3)
            {
                PrintFiles();
            }

            if (key.Key == ConsoleKey.D4)
            {
                isFinished = true;
            }
        }

        private static void ShowPrinters()
        {
            int i = 1;
            foreach (Printer p in manager.Printers)
            {
                System.Console.WriteLine("#" + i++ + "  " + p.ToString());
            }
        }

        private static void AddNewPrinter()
        {
            System.Console.Clear();
            System.Console.WriteLine("Choose printer to create: ");
            System.Console.WriteLine("1. Canon.");
            System.Console.WriteLine("2. Epson.");

            ConsoleKeyInfo key = System.Console.ReadKey();
            System.Console.WriteLine();

            if (key.Key == ConsoleKey.D1)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Enter printer name: ");
                string name = System.Console.ReadLine();

                System.Console.WriteLine();
                System.Console.WriteLine("Enter printer model: ");
                string model = System.Console.ReadLine();
                manager.Add(new CanonPrinter(name, model));

                System.Console.Clear();
                System.Console.WriteLine("Printer have been succesfully added!");
            }

            if (key.Key == ConsoleKey.D2)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Enter printer name: ");
                string name = System.Console.ReadLine();

                System.Console.WriteLine();
                System.Console.WriteLine("Enter printer model: ");
                string model = System.Console.ReadLine();
                manager.Add(new EpsonPrinter(name, model));

                System.Console.Clear();
                System.Console.WriteLine("Printer have been succesfully added!");
            }
        }

        private static void PrintFiles()
        {
            System.Console.Clear();
            System.Console.WriteLine("Choose files to each printer:");
            foreach(Printer p in manager.Printers)
            {
                manager.Print(p);
            }

            System.Console.WriteLine();
        }
    }
}