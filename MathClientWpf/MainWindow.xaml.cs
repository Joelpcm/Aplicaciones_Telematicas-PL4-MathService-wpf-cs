using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace MathClientWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPrimo_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(TxtNumero.Text, out int Valor))
            {
                // Instancia del cliente WCF
                MathService.MathClient client = new MathService.MathClient();

                // Invocar el servicio
                bool Prime = client.PrimeAsync(Valor).Result;

                // Mostrar resultado en la etiqueta
                LblResultado.Content = Prime ? "Es primo" : "No es primo";
            }
            else
            {
                LblResultado.Content = "Ingrese un número válido";
            }
        }

        private void BtnSumarTupla_Click(object sender, RoutedEventArgs e)
        {
            // Array de tipo String para almacenar los valores de entrada
            String[] data;

            //Se divide la entrada usando la coma como separador
            data = TxtDatos.Text.Split(',');
            double[] Data = new double[data.Length];

            // Se recorre data para convertir cada elemento a double y almacenarlo en el array Data
            for (int i = 0; i < data.Length; i++)
            {
                Data[i] = Convert.ToDouble(data[i]);
            }

            // Crea la tupla que se enviara al servicio
            var entrada = new MathService.Tuple
            {
                Data = Data,
                Name = ""
            };

            try
            {
                // Instancia del cliente WCF
                MathService.MathClient client = new MathService.MathClient();

                // Invoca el servicio y espera el resultado
                MathService.Tuple resultado = client.SumTupleAsync(entrada).Result;

                // Mostrar resultado interfaz grafica
                LblTuplaResultado.Content = $"Suma: {resultado.Data[0]}, Nombre: {resultado.Name}";

                client.Close();
            }
            catch (Exception ex)
            {
                LblTuplaResultado.Content = $"Error: {ex.Message}";
            }
        }
    }
}