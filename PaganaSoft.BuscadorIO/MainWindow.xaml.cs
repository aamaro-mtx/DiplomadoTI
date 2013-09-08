using PaganaSoft.BuscadorIO.ViewModels;
using System;
using System.Windows;
using FolBrowDia = System.Windows.Forms.FolderBrowserDialog;
using Result = System.Windows.Forms.DialogResult;

namespace PaganaSoft.BuscadorIO
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyViewModel = new DefaultViewModel();
        }

        public DefaultViewModel MyViewModel { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPath.Text) && !string.IsNullOrEmpty(txtParameter.Text))
            {
                MyViewModel.Search(txtPath.Text, txtParameter.Text, chkSub.IsChecked);
                lvwRes.ItemsSource = MyViewModel.FoundsList;
                dgRes.ItemsSource = MyViewModel.ErrorsCollection;
            }
            else
                MessageBox.Show("Verifique los parametros");
        }

        private void btnSelPathClick(object sender, RoutedEventArgs e)
        {
            try
            {
                FolBrowDia dlg = new FolBrowDia();
                if (dlg.ShowDialog() == Result.OK)
                {
                    txtPath.Text = dlg.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error: " + ex.Message);
            }

        }

    }
}
