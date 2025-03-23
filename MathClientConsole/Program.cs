using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClientConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MathClient client = new MathClient("NetTcpBinding_IMath");

            int x = 23;

            if (client.Prime(x))
                Console.WriteLine("{0} es primo", x);
            else
                Console.WriteLine("{0} no es primo", x);
        }
    }
}
