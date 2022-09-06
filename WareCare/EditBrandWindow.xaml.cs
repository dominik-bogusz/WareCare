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
    /// Interaction logic for EditBrandWindow.xaml
    /// </summary>
    public partial class EditBrandWindow : Window
    {

        /// <summary>
        /// constructor initializees <c>EditBrandWindow</c> object
        /// </summary>
        public EditBrandWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            using (WareCareContext db = new WareCareContext(MainWindow.connectionString))
            {
                if (!String.IsNullOrWhiteSpace(tbxName.Text))
                {
                    try
                    {
                        Brand brandToEdit = (from b in db.Brands where b.ID == Int32.Parse(tbxID.Text) select b).FirstOrDefault();
                        brandToEdit.Name = tbxName.Text;
                        db.Update(brandToEdit);
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
