using System;
using System.Linq;
using System.ServiceModel;
using Accord.Math;
using Accord.Math.Decompositions;
using System.Numerics;

namespace MathService
{
    public class Math : IMath
    {
        public bool Prime(int value)
        {
            // Si el valor es menor o igual a 1 no es primo 
            if (value <= 1) return false;

            // Recorre los numeros desde 2 hasta la raiz cuadrada del numero (si es mas alto no es divisible)
            for (int i = 2; i <= System.Math.Sqrt(value); i++)
            {
                //Si el valor es divisible por cualquier numero entre 2 y su raiz cuadrada tampoco es primo
                if (value % i == 0) 
                    return false;
            }
            return true;
        }
        public Tuple SumTuple(Tuple tuple)
        {
            // Suma los elementos de la tupla
            double suma = tuple.Data != null ? tuple.Data.Sum() : 0;

            // Crear la tupla de resultado: un vector con la suma
            // y el nombre suma de ...
            return new Tuple
            {
                Data = new double[] { suma },
                Name = "Suma de " + string.Join(", ", tuple.Data)
            };
        }

        public double[] SolveLinearSystem(LinearSystem system)
        {
            double[][] coefficients = system.Coefficients; // Matriz de coeficientes (A)
            double[] constants = system.Constants; // Vector de constantes (b)

            int rows = coefficients.Length; // Numero de filas (A)
            int columns = coefficients[0].Length; // Numero de columnas (A)

            // Crear una matriz de coeficientes
            double[,] matrix = new double[rows, columns];

            // Rellenar la matriz con los valores de los coeficientes
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    matrix[i, j] = coefficients[i][j];

            //Descomposicion LU de la matriz de coeficientes . Mas info en:https://learn.microsoft.com/es-es/archive/msdn-magazine/2012/december/csharp-matrix-decomposition
            var lu = new Accord.Math.Decompositions.LuDecomposition(matrix);
            return lu.Solve(constants);
        }
    }
}

