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
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        /// <summary>
        /// constructor initializes <c>AddProductWindow</c> object
        /// </summary>

        public AddProductWindow()
        {
            InitializeComponent();
            cmbBrand.SelectedIndex = 0;
            cmbBrand.ItemsSource = GetBrands();
        }

        private List<string> GetBrands()
        {
            using (WareCareContext db = new WareCareContext(MainWindow.connectionString))
            {
                var brands = (from d in db.Brands select d).ToList();
                List<string> brandsNames = new List<string>();
                for (int i = 0; i < brands.Count; i++)
                {
                    brandsNames.Add(brands[i].Name);
                }
                return brandsNames;
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            using (WareCareContext db = new WareCareContext(MainWindow.connectionString))
            {
                if (!String.IsNullOrWhiteSpace(tbxName.Text))
                {
                    try
                    {
                        Product productToAdd = new Product();
                        productToAdd.Name = tbxName.Text;
                        int brandID = (from d in db.Brands where d.Name == cmbBrand.SelectedValue.ToString() select d.ID).FirstOrDefault();
                        productToAdd.BrandID = brandID;
                        productToAdd.Description = tbxDescription.Text;
                        db.Add(productToAdd);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid input.");
                    }
                    this.Close();
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
