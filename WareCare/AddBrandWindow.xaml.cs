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
    /// Interaction logic for AddBrandWindow.xaml
    /// </summary>
    public partial class AddBrandWindow : Window
    {
        /// <summary>
        /// constructor initializes <c>AddBrandWindow</c> object
        /// </summary>
        public AddBrandWindow()
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
                        Brand brandToAdd = new Brand();
                        brandToAdd.Name = tbxName.Text;
                        db.Add(brandToAdd);
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
