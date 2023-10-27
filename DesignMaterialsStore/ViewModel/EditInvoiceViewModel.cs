using DesignMaterialsStore.DAO;
using DesignMaterialsStore.DAO.implement;
using DesignMaterialsStore.Model;
using DesignMaterialsStore.View;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace DesignMaterialsStore.ViewModel
{
    public class EditInvoiceViewModel : ViewModelBase
    {

        //Fields
        private InvoiceDAO _invoiceDAO;
        private InvoiceItemDAO _invoiceItemDAO;
        private WorkerDAO _workerDAO;
        private ClientDAO _clientDAO;

        private Invoice _invoiceToEdit;
        private Invoice _invoiceBeforeEdit;

        private ObservableCollection<InvoiceItem> _invoiceItemsToEdit;
        private ObservableCollection<InvoiceItem> _invoiceItemsBeforeEdit;

        private InvoiceItem _selectedInvoiceItem;

        private string _errorMessage;

        private int _workerID;
        private Worker _worker;
        private int _clientID;
        private Model.Client _client;
        private DateTime _date;
        private double _price;

        //Commands
        public ICommand DeleteCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand AddItemCommand { get; }


        //Constructor
        public EditInvoiceViewModel(Invoice invoice, ObservableCollection<InvoiceItem> invoiceItems)
        {
            InvoiceDAO = DAOFactory.getInvoiceDAO();
            InvoiceItemDAO = DAOFactory.getInvoiceItemDAO();
            WorkerDAO = DAOFactory.getWorkerDAO();
            ClientDAO = DAOFactory.getClientDAO();

            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand);
            SaveCommand = new ViewModelCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);
            AddItemCommand = new ViewModelCommand(ExecuteAddItemCommand);

            InvoiceToEdit = invoice;
            InvoiceBeforeEdit = BackupInvoice();
            InvoiceItemsToEdit = invoiceItems;
            InvoiceItemsBeforeEdit = BackupInvoiceItems();

            WorkerID = invoice.Worker.Id;
            Worker = new Worker(invoice.Worker.Id, invoice.Worker.Name, invoice.Worker.Surname, invoice.Worker.Address, invoice.Worker.Login, invoice.Worker.Password, invoice.Worker.Active);
            ClientID = invoice.Client.Id;
            Client = new Model.Client(invoice.Client.Id, invoice.Client.Name, invoice.Client.Surname, invoice.Client.Address, invoice.Client.Active);
            Date = invoice.Date;
            Price = invoice.Price;
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

        public Model.Client Client
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

        public Invoice InvoiceToEdit
        {
            get
            {
                return _invoiceToEdit;
            }
            set
            {
                _invoiceToEdit = value;
                OnPropertyChanged(nameof(InvoiceToEdit));
            }
        }

        public Invoice InvoiceBeforeEdit
        {
            get
            {
                return _invoiceBeforeEdit;
            }
            set
            {
                _invoiceBeforeEdit = value;
                OnPropertyChanged(nameof(InvoiceBeforeEdit));
            }
        }

        public ObservableCollection<InvoiceItem> InvoiceItemsToEdit
        {
            get
            {
                return _invoiceItemsToEdit;
            }
            set
            {
                _invoiceItemsToEdit = value;
                CalculatePrice();
                OnPropertyChanged(nameof(InvoiceItemsToEdit));
            }
        }

        public ObservableCollection<InvoiceItem> InvoiceItemsBeforeEdit
        {
            get
            {
                return _invoiceItemsBeforeEdit;
            }
            set
            {
                _invoiceItemsBeforeEdit = value;
                OnPropertyChanged(nameof(InvoiceItemsBeforeEdit));
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

        //Methods

        /// <summary>
        /// Create a backup of the invoice to edit
        /// </summary>
        /// <returns>A copy of the invoice to edit</returns>
        public Invoice BackupInvoice()
        {
            Invoice backupInvoice = new Invoice(InvoiceToEdit.Id,
                                             InvoiceToEdit.Worker,
                                             InvoiceToEdit.Client,
                                             InvoiceToEdit.Date,
                                             InvoiceToEdit.Price);
            return backupInvoice;
        }

        /// <summary>
        /// Restore the invoice to edit with the backup
        /// </summary>
        public void RestoreInvoice()
        {
            InvoiceToEdit.Id = InvoiceBeforeEdit.Id;
            InvoiceToEdit.Worker = InvoiceBeforeEdit.Worker;
            InvoiceToEdit.Client = InvoiceBeforeEdit.Client;
            InvoiceToEdit.Worker = InvoiceBeforeEdit.Worker;
            InvoiceToEdit.Worker = InvoiceBeforeEdit.Worker;

        }

        /// <summary>
        /// Create a backup of the invoice items list to edit
        /// </summary>
        /// <returns>A copy of the invoice items list to edit</returns>
        public ObservableCollection<InvoiceItem> BackupInvoiceItems()
        {
            ObservableCollection<InvoiceItem> backupInvoiceItems = new ObservableCollection<InvoiceItem>();

            for(int i=0; i<InvoiceItemsToEdit.Count; i++)
            {
                InvoiceItem item = new InvoiceItem(InvoiceItemsToEdit[i].Invoice, InvoiceItemsToEdit[i].Item, InvoiceItemsToEdit[i].Quantity);
                backupInvoiceItems.Add(item);
            }

            return backupInvoiceItems;
        }

        /// <summary>
        /// Restore the invoice items list to edit with the backup
        /// </summary>
        public void RestoreInvoiceItems()
        {
            InvoiceItemsToEdit.Clear();

            for(int i=0; i<InvoiceItemsBeforeEdit.Count; i++)
            {
                InvoiceItem item = new InvoiceItem(InvoiceItemsBeforeEdit[i].Invoice, InvoiceItemsBeforeEdit[i].Item, InvoiceItemsBeforeEdit[i].Quantity);
                InvoiceItemsToEdit.Add(item);
            }
        }

        /// <summary>
        /// Calculate the total price of the invoice according to the items and their quantities
        /// </summary>
        public void CalculatePrice()
        {
            Price = 0;

            foreach (InvoiceItem invoiceItem in InvoiceItemsToEdit)
            {
                Price += invoiceItem.Price;
            }
        }

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

        //Commands methods
        private void CloseWindow()
        {
            var window = System.Windows.Application.Current.Windows.OfType<EditInvoiceView>().FirstOrDefault();
            if (window != null)
            {
                window.Close();
            }
        }

        private void ExecuteDeleteCommand(object obj)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Voulez-vous vraiment supprimer cette facture ?", "Confirmation de suppression", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                InvoiceItemDAO.deleteAllInvoiceItems(InvoiceToEdit.Id);
                InvoiceDAO.delete(InvoiceToEdit);
                CloseWindow();
            }
        }

        private bool CanExecuteSaveCommand(object obj)
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

        private void ExecuteSaveCommand(object obj)
        {
            InvoiceToEdit.Worker = Worker;
            InvoiceToEdit.Client = Client;
            InvoiceToEdit.Date = Date;
            InvoiceToEdit.Price = Price;
            InvoiceDAO.update(InvoiceToEdit);
            InvoiceItemDAO.updateAllInvoiceItems(InvoiceItemsToEdit);
            CloseWindow();
        }

        private void ExecuteCancelCommand(object obj)
        {
            RestoreInvoice();
            RestoreInvoiceItems();
            CloseWindow();
        }

        private void ExecuteAddItemCommand(object obj)
        {
            AddItemToInvoiceView addView = new AddItemToInvoiceView(InvoiceItemsToEdit);
            addView.Show();
            addView.IsVisibleChanged += (s, ev) =>
            {
                if (addView.IsVisible == false)
                {
                    CalculatePrice();
                }
            };
        }

    }//end class
}//end namespace
