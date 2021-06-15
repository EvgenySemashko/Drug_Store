using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
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
    /// Логика взаимодействия для UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public static IEnumerable SortedProduct { private get; set; }
        
        public UserView()
        {
            InitializeComponent();

            using (DrugStore_DContext db = new DrugStore_DContext())
            {
                var products = db.Products.Join(db.AdressesPharmacies,
                    p => p.IdProduct,
                    a => a.IdAdressPharmacy,
                    (p, a) => new
                    {
                        NameProduct = p.NameProduct,
                        PriceProduct = p.PriceProduct,
                        City = a.City,
                        Street = a.Street,
                        NumberBuilding = a.NumberBuilding
                    }).ToList();

                productsView.ItemsSource = products;

                TopBarControl.NotifySelectionChanged += ComboBoxTopBarSelectionChanged_NotifySelectionChanged;
            }         
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            using (DrugStore_DContext db = new DrugStore_DContext())
            {
                var products = db.Products.Join(db.AdressesPharmacies,
                    p => p.IdProduct,
                    a => a.IdAdressPharmacy,
                    (p, a) => new
                    {
                        NameProduct = p.NameProduct,
                        PriceProduct = p.PriceProduct,
                        City = a.City,
                        Street = a.Street,
                        NumberBuilding = a.NumberBuilding
                    }).ToList();

                productsView.ItemsSource = products;
            }
        }

        private void ComboBoxTopBarSelectionChanged_NotifySelectionChanged(IEnumerable collection)
        {
            productsView.ItemsSource = collection;
        }
    }
}
