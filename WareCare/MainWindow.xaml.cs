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

namespace WareCare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// static string <c>connectionString</c> contains mysql db access path
        /// </summary>
        public static string connectionString = @"Data Source=DESKTOP-VC01PS3\SQLEXPRESS;Initial Catalog=WareCare;Integrated Security=True";

        /// <summary>
        /// constructor initializes <c>MainWindow</c> object
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();
            dgridAvailability.ItemsSource = GetAvailableProducts();
        }

        private static List<Product> GetAvailableProducts()
        {
            using (WareCareContext db = new WareCareContext(connectionString))
            {
                var products = (from t1 in db.Products
                                join t2 in db.AvailableProducts
                                on t1.ID equals t2.ProductID
                                select t1).ToList();
                return products;
            }
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            ProductsWindow productsWindow = new ProductsWindow();
            productsWindow.ShowDialog();
            dgridAvailability.ItemsSource = GetAvailableProducts();
        }

        private void Brands_Click(object sender, RoutedEventArgs e)
        {
            BrandsWindow brandsWindow = new BrandsWindow();
            brandsWindow.ShowDialog();
            dgridAvailability.ItemsSource = GetAvailableProducts();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DecrementQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (dgridAvailability.SelectedItem != null)
            {
                using (WareCareContext db = new WareCareContext(connectionString))
                {
                    Product selectedProduct = (Product)dgridAvailability.SelectedItem;
                    var quantity = (from a in db.AvailableProducts where a.ProductID == selectedProduct.ID select a).FirstOrDefault();
                    if (quantity.Quantity > 0)
                    {
                        quantity.Quantity--;
                    }
                    db.SaveChanges();
                    dgridAvailability.Items.Refresh();
                }
            }
        }

        private void IncrementQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (dgridAvailability.SelectedItem != null)
            {
                using (WareCareContext db = new WareCareContext(connectionString))
                {
                    Product selectedProduct = (Product)dgridAvailability.SelectedItem;
                    var quantity = (from a in db.AvailableProducts where a.ProductID == selectedProduct.ID select a).FirstOrDefault();
                    quantity.Quantity++;
                    db.SaveChanges();
                    dgridAvailability.Items.Refresh();
                }
            }
        }

        private void EditQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (dgridAvailability.SelectedItem != null)
            {
                EditQuantityWindow editQuantityWindow = new EditQuantityWindow();
                Product productToEdit = (Product)dgridAvailability.SelectedItem;
                editQuantityWindow.tbxQuantity.Text = productToEdit.Quantity.ToString();
                editQuantityWindow.ShowDialog();
            }
        }

        private void EditPrice_Click(object sender, RoutedEventArgs e)
        {
            if (dgridAvailability.SelectedItem != null)
            {
                EditPriceWindow editPriceWindow = new EditPriceWindow();
                Product productToEdit = (Product)dgridAvailability.SelectedItem;
                editPriceWindow.tbxPrice.Text = productToEdit.Price.ToString();
                editPriceWindow.ShowDialog();
            }
        }

        private void DeleteFromAvailable_Click(object sender, RoutedEventArgs e)
        {
            if (dgridAvailability.SelectedItem != null)
            {
                try
                {
                    using (WareCareContext db = new WareCareContext(connectionString))
                    {
                        Product product = (Product)dgridAvailability.SelectedItem;
                        AvailableProduct availableProductToDelete = (from p in db.AvailableProducts where p.ProductID == product.ID select p).FirstOrDefault();
                        db.Remove(availableProductToDelete);
                        db.SaveChanges();
                        dgridAvailability.ItemsSource = GetAvailableProducts();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Select available product to delete.");
                }
            }
        }
    }
}
