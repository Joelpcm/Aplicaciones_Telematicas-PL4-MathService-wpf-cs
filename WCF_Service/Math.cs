using System;
using System.Linq;

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
    }
}

