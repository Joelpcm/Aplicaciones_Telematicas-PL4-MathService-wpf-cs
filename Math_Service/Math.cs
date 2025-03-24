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
            // Suma los elementos de la tupla
            double suma = tuple.Data != null ? tuple.Data.Sum() : 0;

            // Crear la tupla de resultado: un vector con la suma
            // y el nombre suma de ...
            return new Tuple
            {
                Data = new double[] { suma },
                Name = tuple.Name
            };
        }

        public double[] SolveLinearSystem(LinearSystem system)
        {
            double[][] coefficients = system.Coefficients;
            double[] constants = system.Constants;
            int rows = coefficients.Length;
            int cols = coefficients[0].Length;
            double[,] matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = coefficients[i][j];

            var lu = new Accord.Math.Decompositions.LuDecomposition(matrix);
            return lu.Solve(constants);
        }
    }
}

