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
    /// Logique d'interaction pour AddInvoiceView.xaml
    /// </summary>
    public partial class AddInvoiceView : Window
    {
        
        //Fields
        private AddInvoiceViewModel viewModel;

        //Constructor
        public AddInvoiceView(ObservableCollection<Invoice> invoices)
        {
            InitializeComponent();
            viewModel = new AddInvoiceViewModel(invoices);
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

        //Method that executes when the user presses the enter key while he is in the worker id field
        private void TextBoxWorkerID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                viewModel.SearchWorker();
            }
        }

        //Method that executes when the user presses the enter key while he is in the client id field
        private void TextBoxClientID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                viewModel.SearchClient();
            }
        }

        //Method that executes when the user double click on the data grid
        private void DataGridInvoiceItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is AddInvoiceViewModel addInvoiceViewModel && addInvoiceViewModel.SelectedInvoiceItem != null)
            {
                //Open a view where we can modify the quantity of an item or delete an item of the invoice
                EditInvoiceItemViewModel editInvoiceItemVM = new EditInvoiceItemViewModel(addInvoiceViewModel.InvoiceItemCollection, addInvoiceViewModel.SelectedInvoiceItem);
                EditInvoiceItemView editInvoiceItemVIEW = new EditInvoiceItemView();
                editInvoiceItemVIEW.DataContext = editInvoiceItemVM;
                editInvoiceItemVIEW.Show();

                //if the edit window is closed, the total price of the invoice is automatically recalculate
                editInvoiceItemVIEW.IsVisibleChanged += (s, ev) =>
                {
                    if (editInvoiceItemVIEW.IsVisible == false)
                    {
                        viewModel.CalculatePrice();
                    }
                };
            }
        }

    }//end class
}//end namespace
