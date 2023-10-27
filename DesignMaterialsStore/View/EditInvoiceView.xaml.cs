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
    /// Logique d'interaction pour EditInvoiceView.xaml
    /// </summary>
    public partial class EditInvoiceView : Window
    {
        //Fields
        private EditInvoiceViewModel viewModel;

        //Constructor
        public EditInvoiceView(Invoice invoice, ObservableCollection<InvoiceItem> invoiceItems)
        {
            InitializeComponent();
            viewModel = new EditInvoiceViewModel(invoice, invoiceItems);
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

        //Method that executes when the user double click on the data grid
        private void DataGridInvoiceItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is EditInvoiceViewModel editInvoiceViewModel && editInvoiceViewModel.SelectedInvoiceItem != null)
            {
                //Open a view where we can modify the quantity of an item or delete an item of the invoice
                EditInvoiceItemViewModel editInvoiceItemVM = new EditInvoiceItemViewModel(editInvoiceViewModel.InvoiceItemsToEdit, editInvoiceViewModel.SelectedInvoiceItem);
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

        //Method that executes when the user presses the enter key while he is in the worker id field
        private void TextBoxIdWorker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                viewModel.SearchWorker();
            }
        }

        //Method that executes when the user presses the enter key while he is in the client id field
        private void TextBoxIdClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                viewModel.SearchClient();
            }
        }

    }//end class
}//end namespace
