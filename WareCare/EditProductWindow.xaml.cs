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
    public partial class EditProductWindow : Window
    {
        /// <summary>
        /// constructor initializees <c>EditProductWindow</c> object
        /// </summary>
        public EditProductWindow()
        {
            InitializeComponent();
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
                        var productToEdit = (from p in db.Products where p.ID == Int32.Parse(tbxID.Text) select p).FirstOrDefault();
                        productToEdit.Name = tbxName.Text;
                        int brandID = (from d in db.Brands where d.Name == cmbBrand.SelectedValue.ToString() select d.ID).FirstOrDefault();
                        productToEdit.BrandID = brandID;
                        productToEdit.Description = tbxDescription.Text;
                        db.Update(productToEdit);
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
