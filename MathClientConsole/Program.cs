using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathService;

namespace MathClientConsole
{
    internal class Program
    {
        static void Main()
        {
            // Crear instancia del cliente WCF usando el endpoint "NetTcpBinding_IMath"
            MathClient client = new MathClient("NetTcpBinding_IMath");

            /*
            //Para probar lo de las Tuplas
            int x = 23;

            if (client.Prime(x))
                Console.WriteLine("{0} es primo", x);
            else
                Console.WriteLine("{0} no es primo", x);
            */


            // Para resolver un sistema de ecuaciones  Ax=b
            // Posibilidad 1
            LinearSystem system = new LinearSystem
            {
                // Esto serian las A
                Coefficients = new double[][] {
                    new double[] { 2, 3 },
                    new double[] { 3, 4 }
                },

                // Esto serian las b
                Constants = new double[] { -1, 0 }
            };

            //Posibilidad 2
            /*
            LinearSystem system = new LinearSystem
            {
                // Esto serian las A
                Coefficients = new double[][] {
                new double[] { 1, 1, 1 },
                new double[] { 2, 3, -4 },
                new double[] { 1, -1, 1 }
                },

                // Esto serian las b
                Constants = new double[] { 1, 9, -1 }
            };
            */

            // Calculamos la x
            double[] solution = client.SolveLinearSystem(system);

            Console.WriteLine("Solución:");
            // Lo imprime en pantalla de manera que  x1= solution[0], x2 = solution[1] ...
            for (int i = 0; i < solution.Length; i++)
            {
                Console.WriteLine($"x{i + 1} = {solution[i]}");
            }
            client.Close();
        }
    }
}
