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
    /// Interaction logic for BrandsWindow.xaml
    /// </summary>
    public partial class BrandsWindow : Window
    {
        /// <summary>
        /// constructor initializees <c>BrandsWindow</c> object
        /// </summary>
        public BrandsWindow()
        {
            InitializeComponent();
            dgridBrands.ItemsSource = GetBrands();
        }

        private List<Brand> GetBrands()
        {
            using (WareCareContext db = new WareCareContext(MainWindow.connectionString))
            {
                var brands = (from b in db.Brands select b).ToList();
                return brands;
            }
        }

        private void AddBrand_Click(object sender, RoutedEventArgs e)
        {
            AddBrandWindow addBrandWindow = new AddBrandWindow();
            addBrandWindow.ShowDialog();
            dgridBrands.ItemsSource = GetBrands();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
