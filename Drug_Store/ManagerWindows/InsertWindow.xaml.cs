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
    /// Логика взаимодействия для InsertWindow.xaml
    /// </summary>
    public partial class InsertWindow : Window
    {
        Product prod = new Product();
        List<Product> items = new List<Product>();
        
        public InsertWindow()
        {
            InitializeComponent();
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {

            if (items.Count == 0)
            {
                prod.IdProduct = items.Count;
            }
            else
            {
                prod.IdProduct = items.Count + 1;
            }

            prod.NameProduct = nameBox.Text;

            if (nameBox.Text.Length == 0)
            {
                prod.NameProduct = "";
            }
            else
            {
                prod.NameProduct = nameBox.Text;
            }

            if (priceProduct.Text.Length == 0)
            {
                prod.PriceProduct = 0;
            }
            else
            {
                prod.PriceProduct = decimal.Parse(priceProduct.Text);
            }

            if (countBox.Text.Length == 0)
            {
                prod.CountProduct = 0;
            }
            else
            {
                prod.CountProduct = int.Parse(countBox.Text);
            }


            this.Close();
        }

        private void priceProduct_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void countBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
