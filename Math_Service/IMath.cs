using System.Runtime.Serialization;
using System.ServiceModel;

namespace MathService
{
    [ServiceContract]
    public interface IMath
    {
        // Esto añade la operacion Prime
        [OperationContract]
        bool Prime(int value);

        // Añadir la operacion SumTuple
        [OperationContract]
        Tuple SumTuple(Tuple tuple);

        // Añade la operacion SolveLinearSystem
        [OperationContract]
        double[] SolveLinearSystem(LinearSystem system);
    }

    // Contrato de datos para las tuplas
    [DataContract]
    public class Tuple
    {
        double[] _data;
        string _name;

        [DataMember]
        public double[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }

    // Contrato de datos para los sistemas de ecuaciones lineales
    [DataContract]
    public class LinearSystem
    {
        public double[][] _coefficients;
        public double[] _constants;

        [DataMember]
        public double[][] Coefficients 
        {
            get { return _coefficients; }
            set {_coefficients = value; }
        }

        [DataMember]
        public double[] Constants 
        {
            get { return _constants; }
            set { _constants = value; }
        }
    }
}
