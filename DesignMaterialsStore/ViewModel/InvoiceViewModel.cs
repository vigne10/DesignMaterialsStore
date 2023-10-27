using DesignMaterialsStore.DAO.implement;
using DesignMaterialsStore.DAO;
using DesignMaterialsStore.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DesignMaterialsStore.Model;

namespace DesignMaterialsStore.ViewModel
{
    public class InvoiceViewModel : ViewModelBase
    {

        //Fields
        private InvoiceDAO iDAO;
        private ObservableCollection<Invoice> _invoiceCollection;
        private Invoice _selectedInvoice;

        //Commands
        public ICommand AddInvoiceCommand { get; }


        //Constructor
        public InvoiceViewModel()
        {
            iDAO = DAOFactory.getInvoiceDAO();
            InvoiceCollection = iDAO.findAll();
            SelectedInvoice = new Invoice();
            AddInvoiceCommand = new ViewModelCommand(ExecuteAddInvoiceCommand);
        }

        //Properties
        public ObservableCollection<Invoice> InvoiceCollection
        {
            get
            {
                return _invoiceCollection;
            }
            set
            {
                _invoiceCollection = value;
                OnPropertyChanged(nameof(InvoiceCollection));
            }
        }

        public Invoice SelectedInvoice
        {
            get
            {
                return _selectedInvoice;
            }
            set
            {
                _selectedInvoice = value;
                OnPropertyChanged(nameof(SelectedInvoice));
            }
        }

        //Methods
        private void ExecuteAddInvoiceCommand(object obj)
        {
            AddInvoiceView addView = new AddInvoiceView(InvoiceCollection);
            addView.Show();
        }

    }//end class
}//end namespace
