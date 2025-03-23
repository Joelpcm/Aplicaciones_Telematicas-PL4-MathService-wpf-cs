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
            if (value <= 1) return false;
            for (int i = 2; i <= System.Math.Sqrt(value); i++)
            {
                if (value % i == 0) return false;
            }
            return true;
        }
        public Tuple SumTuple(Tuple tuple)
        {
            // Suma los elementos del array usando LINQ (o un bucle, si prefieres)
            double suma = tuple.Data != null ? tuple.Data.Sum() : 0;

            // Crear la tupla de resultado: un vector con un solo elemento (la suma)
            // y un nombre que indique la operación realizada
            return new Tuple
            {
                Data = new double[] { suma },
                Name = tuple.Name
            };
        }

        public double[] SolveLinearSystem(double[][] coefficients, double[] constants)
        {
            // Convierte el array  a una matriz 
            double[,] matrix = new double[coefficients.Length, coefficients[0].Length];

            // Copia los datos de coefficients a matriz
            for (int i = 0; i < coefficients.Length; i++)
            {
                for (int j = 0; j < coefficients[i].Length; j++)
                {
                    matrix[i, j] = coefficients[i][j];
                }
            }

            // Usa la factorizacion LU
            var lu = new LuDecomposition(matrix);

            // Resuelve el sistema Ax = b
            double[] solution = lu.Solve(constants);

            return solution;
        }
    }
}

