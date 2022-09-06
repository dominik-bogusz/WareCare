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

namespace WareCare
{
    /// <summary>
    /// Interaction logic for ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {

        /// <summary>
        /// constructor initializes <c>ProductsWindow</c> object
        /// </summary>
        public ProductsWindow()
        {
            InitializeComponent();
            dgridProducts.ItemsSource = GetProducts();
        }

        private List<Product> GetProducts()
        {
            using (WareCareContext db = new WareCareContext(MainWindow.connectionString))
            {
                var products = (from p in db.Products select p).ToList();
                return products;
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ShowDialog();
        }


        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            EditProductWindow editProductWindow = new EditProductWindow();
            editProductWindow.ShowDialog();
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgridProducts.SelectedItem != null)
            {
                try
                {
                    using (WareCareContext db = new WareCareContext(MainWindow.connectionString))
                    {
                        Product productToDelete = (Product)dgridProducts.SelectedItem;
                        db.Remove(productToDelete);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You need to delete product from available products first.");
                }
                dgridProducts.ItemsSource = GetProducts();
            }
        }

        private void AddToAvailable_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
