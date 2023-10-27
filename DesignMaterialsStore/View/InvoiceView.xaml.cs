using DesignMaterialsStore.DAO;
using DesignMaterialsStore.DAO.implement;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesignMaterialsStore.View
{
    /// <summary>
    /// Logique d'interaction pour InvoiceView.xaml
    /// </summary>
    public partial class InvoiceView : UserControl
    {
        //Constructor
        public InvoiceView()
        {
            InitializeComponent();
        }

        //Methods

        //Method that executes when the user double click on the datagrid
        private void DataGridInvoice_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is InvoiceViewModel invoiceViewModel && invoiceViewModel.SelectedInvoice != null)
            {

                InvoiceItemDAO invoiceItemDAO = DAOFactory.getInvoiceItemDAO();
                ObservableCollection<InvoiceItem> invoiceItems = invoiceItemDAO.findAllByInvoiceID(invoiceViewModel.SelectedInvoice.Id);

                //Open the view to edit the client
                EditInvoiceView ewV = new EditInvoiceView(invoiceViewModel.SelectedInvoice, invoiceItems);
                ewV.Show();

                //if the edit window is closed, the list of invoices is automatically updated
                ewV.IsVisibleChanged += (s, ev) =>
                {
                    if (ewV.IsVisible == false)
                    {
                        this.DataContext = new InvoiceViewModel();
                    }
                };


            }
        }

    }//end class
}//end namespace
