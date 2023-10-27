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
using System.Windows.Forms;

namespace DesignMaterialsStore.ViewModel
{
    public class AddInvoiceViewModel : ViewModelBase
    {

        //Fields
        private int _workerID;
        private Worker _worker;
        private int _clientID;
        private Client _client;
        private DateTime _date;
        private double _price;
        private string _errorMessage;
        private InvoiceDAO _invoiceDAO;
        private InvoiceItemDAO _invoiceItemDAO;
        private WorkerDAO _workerDAO;
        private ClientDAO _clientDAO;
        private ObservableCollection<Invoice> _invoiceCollection;
        private ObservableCollection<InvoiceItem> _invoiceItemCollection;
        private InvoiceItem _selectedInvoiceItem;


        //Commands
        public ICommand AddInvoiceCommand { get; }
        public ICommand AddItemToInvoiceCommand { get; }

        //Constructor
        public AddInvoiceViewModel(ObservableCollection<Invoice> iCollection)
        {
            InvoiceDAO = DAOFactory.getInvoiceDAO();
            InvoiceItemDAO = DAOFactory.getInvoiceItemDAO();
            WorkerDAO = DAOFactory.getWorkerDAO();
            ClientDAO = DAOFactory.getClientDAO();

            AddInvoiceCommand = new ViewModelCommand(ExecuteAddInvoiceCommand, CanExecuteAddInvoiceCommand);
            AddItemToInvoiceCommand = new ViewModelCommand(ExecuteAddItemToInvoiceCommand);

            Date = DateTime.Now;
            Price = 0;

            InvoiceCollection = iCollection;
            InvoiceItemCollection = new ObservableCollection<InvoiceItem>();
        }

        //Properties
        public int WorkerID
        {
            get
            {
                return _workerID;
            }
            set
            {
                _workerID = value;
                OnPropertyChanged(nameof(WorkerID));
            }
        }

        public Worker Worker
        { 
            get 
            { 
                return _worker; 
            }
            set
            {
                _worker = value;
                OnPropertyChanged(nameof(Worker));
            }
        }

        public int ClientID
        {
            get
            {
                return _clientID;
            }
            set
            {
                _clientID = value;
                OnPropertyChanged(nameof(ClientID));
            }
        }

        public Client Client
        {
            get
            { 
                return _client; 
            }
            set
            {
                _client = value;
                OnPropertyChanged(nameof(Client));
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public InvoiceDAO InvoiceDAO
        {
            get
            {
                return _invoiceDAO;
            }
            set
            {
                _invoiceDAO = value;
                OnPropertyChanged(nameof(InvoiceDAO));
            }
        }

        public InvoiceItemDAO InvoiceItemDAO
        {
            get
            {
                return _invoiceItemDAO;
            }
            set
            {
                _invoiceItemDAO = value;
                OnPropertyChanged(nameof(InvoiceItemDAO));
            }
        }

        public WorkerDAO WorkerDAO
        {
            get
            {
                return _workerDAO;
            }
            set
            {
                _workerDAO = value;
                OnPropertyChanged(nameof(WorkerDAO));
            }
        }

        public ClientDAO ClientDAO
        {
            get
            {
                return _clientDAO;
            }
            set
            {
                _clientDAO = value;
                OnPropertyChanged(nameof(ClientDAO));
            }
        }

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

        public ObservableCollection<InvoiceItem> InvoiceItemCollection
        {
            get
            {
                return _invoiceItemCollection;
            }
            set
            {
                _invoiceItemCollection = value;
                OnPropertyChanged(nameof(InvoiceItemCollection));
            }
        }

        public InvoiceItem SelectedInvoiceItem
        {
            get
            {
                return _selectedInvoiceItem;
            }
            set
            {
                _selectedInvoiceItem = value;
                OnPropertyChanged(nameof(SelectedInvoiceItem));
            }
        }

        //Methods

        /// <summary>
        /// Search a worker with the id entry by user in the associated view and show ErrorMessage if the worker doesn't exist
        /// </summary>
        public void SearchWorker()
        {
            ErrorMessage = "";
            Worker = WorkerDAO.findById(WorkerID);
            if (Worker == null)
            {
                ErrorMessage = "* Employé inexistant";
            }
        }

        /// <summary>
        /// Search a client with the id entry by user in the associated view and show ErrorMessage if the client doesn't exist
        /// </summary>
        public void SearchClient()
        {
            ErrorMessage = "";
            Client = ClientDAO.findById(ClientID);
            if (Client == null)
            {
                ErrorMessage = "* Client inexistant";
            }
        }

        /// <summary>
        /// Calculate the total price of the invoice according to the items and their quantities
        /// </summary>
        public void CalculatePrice()
        {
            Price = 0;

            foreach (InvoiceItem invoiceItem in InvoiceItemCollection)
            {
                Price += invoiceItem.Price;
            }
        }

        //Commands methods
        private bool CanExecuteAddInvoiceCommand(object obj)
        {
            bool validData;

            if (Worker == null || Client == null || Price == 0)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;

        }

        private void ExecuteAddInvoiceCommand(object obj)
        {

            Invoice i = new Invoice(Worker, Client, Date, Price);
            InvoiceDAO.create(i);
            i = InvoiceDAO.findByWorkerClientDatePrice(i.Worker, i.Client, i.Date, i.Price);
            foreach(InvoiceItem invoiceItem in InvoiceItemCollection)
            {
                invoiceItem.Invoice = i;
                InvoiceItemDAO.create(invoiceItem);
            }
            InvoiceCollection.Add(i);
            CloseWindow();
        }

        private void ExecuteAddItemToInvoiceCommand(object obj)
        {
            AddItemToInvoiceView addView = new AddItemToInvoiceView(InvoiceItemCollection);
            addView.Show();
            addView.IsVisibleChanged += (s, ev) =>
            {
                if (addView.IsVisible == false)
                {
                   CalculatePrice();
                }
            };
        }

        private void CloseWindow()
        {
            var window = System.Windows.Application.Current.Windows.OfType<AddInvoiceView>().FirstOrDefault();
            if (window != null)
            {
                window.Close();
            }
        }

    }//end class
}//end namespace
