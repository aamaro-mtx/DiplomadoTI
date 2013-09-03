using PaganaSoft.SerializacionCSV.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaganaSoft.SerializacionCSV
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Serializar();
        }

        private void Serializar()
        {
            var prod = new Product()
            {
                ID = 1,
                Nombre = "Refresco 2L",
                Marca = "Coca-Cola",
                Cantidad = 25,
                UnidadDeMedida = "Litro",
                PrecioUnitario = 25
            };

            IFormatter formater = new CommaSeparatedValueFormatter();
            FileStream fs = File.Create(@"c:\tmp\producto.csv");
            formater.Serialize(fs, prod);
            fs.Close();

        }

        private void bnt_Serializar(object sender, RoutedEventArgs e)
        {
            Serializar();
        }

        private void btn_DeSerializar(object sender, RoutedEventArgs e)
        {

        }
    }
}
