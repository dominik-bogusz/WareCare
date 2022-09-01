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
    }
}
