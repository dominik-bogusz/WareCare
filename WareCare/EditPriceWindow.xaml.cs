using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for EditQuantity.xaml
    /// </summary>
    public partial class EditPriceWindow : Window
    {
        /// <summary>
        /// constructor initializees <c>EditPriceWindow</c> object
        /// </summary>
        public EditPriceWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.OfType<MainWindow>().Any())
            {
                foreach (MainWindow mainWindow in Application.Current.Windows.OfType<MainWindow>()) // get the MainWindow object
                {
                    using (WareCareContext db = new WareCareContext(MainWindow.connectionString))
                    {
                        Product selectedProduct = (Product)mainWindow.dgridAvailability.SelectedItem;
                        var availability = (from a in db.AvailableProducts where a.ProductID == selectedProduct.ID select a).FirstOrDefault();
                        try
                        {
                            if (!string.IsNullOrEmpty(tbxPrice.Text) && Decimal.Parse(tbxPrice.Text) >= 0) // if not empty proceed
                                availability.Price = Decimal.Parse(tbxPrice.Text);
                            else availability.Price = 0; // else make price 0

                            db.SaveChanges();
                            mainWindow.dgridAvailability.Items.Refresh();
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Invalid price format.");
                        }
                    }
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private Boolean TextAllowed(String s) // regex; only numbers & control keys allowed
        {
            foreach (Char c in s.ToCharArray())
            {
                if (Char.IsNumber(c) || c == ',' || Char.IsControl(c)) continue; // change ',' to '.' in accordance to the system's language respectively
                else return false;
            }
            return true;
        }

        private void PreviewTextInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextAllowed(e.Text);
        }

        private void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            String s = (String)e.DataObject.GetData(typeof(int));
            if (!TextAllowed(s)) e.CancelCommand();
        }
    }
}
