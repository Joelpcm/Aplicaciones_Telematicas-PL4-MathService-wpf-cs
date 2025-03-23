using System.Runtime.Serialization;
using System.ServiceModel;

namespace MathService
{
    [ServiceContract]
    public interface IMath
    {
        [OperationContract]
        bool Prime(int value);

        // Añadir la operacion SumTuple
        [OperationContract]
        Tuple SumTuple(Tuple tuple);

        // Añadir la operacion SolveLinearSystem
        [OperationContract]
        double[] SolveLinearSystem(double[][] coefficients, double[] constants);
    }

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
}
