using DesignMaterialsStore.DAO;
using DesignMaterialsStore.DAO.implement;
using DesignMaterialsStore.Model;
using DesignMaterialsStore.View;
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
    public class EditInvoiceItemViewModel : ViewModelBase
    {
        //Fields
        private InvoiceItemDAO _invoiceItemDAO;
        private ObservableCollection<InvoiceItem> _invoiceItemCollection;
        private InvoiceItem _invoiceItemToEdit;
        private InvoiceItem _invoiceItemBeforeEdit;
        private string _errorMessage;

        //Commands
        public ICommand DeleteCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        //Constructor
        public EditInvoiceItemViewModel(ObservableCollection<InvoiceItem> invoiceItems, InvoiceItem invoiceItem)
        {
            InvoiceItemDAO = DAOFactory.getInvoiceItemDAO();
            InvoiceItemCollection = invoiceItems;
            InvoiceItemToEdit = invoiceItem;
            InvoiceItemBeforeEdit = BackupInvoiceItem(invoiceItem);
            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand);
            SaveCommand = new ViewModelCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);

        }

        //Properties
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

        public InvoiceItem InvoiceItemToEdit
        {
            get
            {
                return _invoiceItemToEdit;
            }
            set
            {
                _invoiceItemToEdit = value;
                OnPropertyChanged(nameof(InvoiceItem));
            }
        }

        public InvoiceItem InvoiceItemBeforeEdit
        {
            get
            {
                return _invoiceItemBeforeEdit;
            }
            set
            {
                _invoiceItemBeforeEdit = value;
                OnPropertyChanged(nameof(InvoiceItemBeforeEdit));
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
        /// Create a backup of the invoice item to edit
        /// </summary>
        /// <returns>A copy of the invoice item to edit</returns>
        public InvoiceItem BackupInvoiceItem(InvoiceItem invoiceItemToSave)
        {
            InvoiceItem backupInvoiceItem = new InvoiceItem(invoiceItemToSave.Invoice,
                                             invoiceItemToSave.Item,
                                             invoiceItemToSave.Quantity);
            return backupInvoiceItem;
        }

        /// <summary>
        /// Restore the invoice item to edit with the backup
        /// </summary>
        public void RestoreItem(InvoiceItem actualInvoiceItem, InvoiceItem invoiceItemToRestore)
        {
            actualInvoiceItem.Invoice = invoiceItemToRestore.Invoice;
            actualInvoiceItem.Item = invoiceItemToRestore.Item;
            actualInvoiceItem.Quantity = invoiceItemToRestore.Quantity;
            actualInvoiceItem.Price = invoiceItemToRestore.Price;
        }

        //Commands methods
        private void ExecuteDeleteCommand(object obj)
        {
            //Show dialog box to confirm delete
            DialogResult result = System.Windows.Forms.MessageBox.Show("Voulez-vous vraiment supprimer cet article ?", "Confirmation de suppression", MessageBoxButtons.YesNo);

            //Check if user click on yes
            if (result == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < _invoiceItemCollection.Count; i++)
                    {
                        if(InvoiceItemToEdit.Item.Id == InvoiceItemCollection[i].Item.Id)
                        {
                            InvoiceItemCollection.RemoveAt(i);
                            CloseWindow();
                            break;
                        }
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

        private bool CanExecuteSaveCommand(object obj)
        {
            bool validData;

            if(InvoiceItemToEdit.Quantity <= 0)
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
            InvoiceItemToEdit.ComputePrice();
            CloseWindow();
        }

        private void ExecuteCancelCommand(object obj)
        {
            RestoreItem(InvoiceItemToEdit, InvoiceItemBeforeEdit);
            CloseWindow();
        }

        private void CloseWindow()
        {
            var window = System.Windows.Application.Current.Windows.OfType<EditInvoiceItemView>().FirstOrDefault();
            if (window != null)
            {
                window.Close();
            }
        }

    }//end class
}//end namespace
