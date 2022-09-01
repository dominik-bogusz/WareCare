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
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PreviewTextInputHandler(Object sender, TextCompositionEventArgs e)
        {

        }

        private void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            
        }
    }
}
