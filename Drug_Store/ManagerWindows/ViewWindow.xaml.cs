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
using Drug_Store.Models;

namespace Drug_Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Product> products = new List<Product>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dragMe(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void productsView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Product product = new Product();

            product = products[productsView.SelectedIndex];

            Dialog dialog = new Dialog(product);

            dialog.Show();

            dialog.Closed += Dialog_Closed;
        }

        private void Dialog_Closed(object sender, EventArgs e)
        {
          
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertWindow window = new InsertWindow();

            window.Show();

            window.Closed += Window_Closed;
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
