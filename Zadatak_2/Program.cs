using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_2
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<string> stringlist = new GenericList<string>();
            stringlist.Add("Larac");
            Console.WriteLine(stringlist.GetElement(0));
            Console.WriteLine(stringlist.GetElement(0).Equals("Larac"));
            Console.WriteLine(stringlist.Count == 1);
            Console.WriteLine(stringlist.Contains("Larac"));
            Console.ReadKey();
        }
    }
}
