using DesignMaterialsStore.Model;
using DesignMaterialsStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DesignMaterialsStore.View
{
    /// <summary>
    /// Logique d'interaction pour AddItemToInvoiceView.xaml
    /// </summary>
    public partial class AddItemToInvoiceView : Window
    {

        //Fields
        private AddItemToInvoiceViewModel viewModel;

        //Constructor
        public AddItemToInvoiceView(ObservableCollection<InvoiceItem> invoiceItems)
        {
            InitializeComponent();
            viewModel = new AddItemToInvoiceViewModel(invoiceItems);
            DataContext = viewModel;
        }

        //Methods
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Method that executes when the user presses the enter key while he is in the item id field
        private void TextBoxId_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                viewModel.SearchItem();
            }
        }

    }//end class
}//end namespace
