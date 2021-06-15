using Drug_Store.Models;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls;
using System.Windows;

namespace Drug_Store
{
    /// <summary>
    /// Логика взаимодействия для TopBarControl.xaml
    /// </summary>
    public partial class TopBarControl : UserControl
    {
        private string _selectedCity = string.Empty;
        private List<Product> _products;
        private List<AdressesPharmacy> _adressesPharmacies;

        public delegate void ComboBoxSelectionChangedHandler(IEnumerable collection);
        public static event ComboBoxSelectionChangedHandler NotifySelectionChanged;

        public TopBarControl()
        {
            InitializeComponent();

            using (DrugStore_DContext db = new DrugStore_DContext())
            {
                comboBoxCities.ItemsSource = db.AdressesPharmacies.Select(c => c.City).Distinct().ToList();

                _products = db.Products.ToList();
                _adressesPharmacies = db.AdressesPharmacies.ToList();
            }
        }

        private void comboBoxCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCity = (string)comboBoxCities.SelectedValue;

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
                   }).Where(a => a.City == _selectedCity).Distinct().ToList();

                NotifySelectionChanged?.Invoke(products);
            }
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchBar.Text.Length == 0)
            {
                var products = _products.Join(_adressesPharmacies,
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

                NotifySelectionChanged?.Invoke(products);
            }
            else if(_selectedCity.Length != 0)
            {
                var searchedProducts = _products.Join(_adressesPharmacies,
                  p => p.IdProduct,
                  a => a.IdAdressPharmacy,
                  (p, a) => new
                  {
                      NameProduct = p.NameProduct,
                      PriceProduct = p.PriceProduct,
                      City = a.City,
                      Street = a.Street,
                      NumberBuilding = a.NumberBuilding
                  }).Where(p => p.NameProduct.Contains(searchBar.Text)).Where(a => a.City == _selectedCity).ToList();

                NotifySelectionChanged?.Invoke(searchedProducts);
            }
            else
            {
                var searchedProducts = _products.Join(_adressesPharmacies,
                  p => p.IdProduct,
                  a => a.IdAdressPharmacy,
                  (p, a) => new
                  {
                      NameProduct = p.NameProduct,
                      PriceProduct = p.PriceProduct,
                      City = a.City,
                      Street = a.Street,
                      NumberBuilding = a.NumberBuilding
                  }).Where(p => p.NameProduct.Contains(searchBar.Text)).ToList();

                NotifySelectionChanged?.Invoke(searchedProducts);
            }
        }

        private void PackIcon_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new();

            mainWindow.Show();
        }
    }
}
