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
using System.Windows.Shapes;
using Drug_Store.Models;

namespace Drug_Store
{
    /// <summary>
    /// Логика взаимодействия для Dialog.xaml
    /// </summary>
    public partial class Dialog : Window
    {
        Product product = new Product();

        public Dialog(Product prod)
        {
            InitializeComponent();

            product = prod;
            SelectedProd.Text = prod.NameProduct;
            priceProduct.Text = prod.PriceProduct.ToString();
        }

        private void countBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void priceProduct_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            product.PriceProduct = decimal.Parse(priceProduct.Text);
            product.CountProduct = int.Parse(countBox.Text);

            this.Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
