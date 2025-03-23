using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClientConsole
{
    internal class Program
    {
        static void Main()
        {
            MathClient client = new MathClient("NetTcpBinding_IMath");

            /*
            //Para probar lo de las Tuplas
            int x = 23;

            if (client.Prime(x))
                Console.WriteLine("{0} es primo", x);
            else
                Console.WriteLine("{0} no es primo", x);
            */

            // Para resolver un sistema de ecuaciones
            double[][] coefficients =
            {
                new double[] { 2, -1 },
                new double[] { 1,  3 }
            };

            double[] constants = 
            { 
                1, 
                7 
            };

            double[] solution = client.SolveLinearSystem(coefficients, constants);
            Console.WriteLine("Solución:");
            foreach (var x in solution)
                Console.WriteLine(x);

            client.Close();
        }
    }
}
