using PaganaSoft.ORM.Models;
using PaganaSoft.ORM.Models.CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace PaganaSoft.ORM
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
            try
            {
                using (var ctx = new VientolNorteContexto())
                {
                    var c = new Categoria()
                    {
                        NombreCategoria = "Bebidas",
                        Descripcion = "Puras bebidas en esta categoria"
                    };
                    ctx.Categorias.Add(c);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void MenuProductos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuCategorias_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_ImportarClick(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new NrtwdModelFirstCtx())
            {

            }
        }
    }
}
