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
            // Crea la tupla de entrada. Aquí puedes ajustar los datos según necesites.
            var entrada = new MathService.Tuple
            {
                Data = new double[] { 1.0, 2.0, 3.0 },
                Name = TxtNombre.Text
            };

            try
            {
                // Instancia del cliente WCF
                MathService.MathClient client = new MathService.MathClient();

                // Invoca el servicio de forma asíncrona y espera el resultado
                MathService.Tuple resultado = client.SumTupleAsync(entrada).Result;

                // Mostrar resultado en la etiqueta
                LblTuplaResultado.Content = $"Suma: {resultado.Data[0]}, Nombre: {resultado.Name}";

                // Cierra el cliente para liberar recursos
                client.Close();
            }
            catch (Exception ex)
            {
                LblTuplaResultado.Content = $"Error: {ex.Message}";
            }
        }
    }
}