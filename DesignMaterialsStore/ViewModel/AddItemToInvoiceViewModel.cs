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
using System.Windows;
using System.Windows.Input;

namespace DesignMaterialsStore.ViewModel
{
    public class AddItemToInvoiceViewModel : ViewModelBase
    {

        //Fields
        private int _itemID;
        private Item _item;
        private int _quantity;
        private ItemDAO _itemDAO;
        private string _errorMessage;
        private ObservableCollection<InvoiceItem> _invoiceItemCollection;

        //Constructor
        public AddItemToInvoiceViewModel(ObservableCollection<InvoiceItem> itc)
        {
            ItemDAO = DAOFactory.getItemDAO();
            AddItemCommand = new ViewModelCommand(ExecuteAddItemCommand, CanExecuteAddItemCommand);
            InvoiceItemCollection = itc;
        }

        //Commands
        public ICommand AddItemCommand { get; }

        //Properties
        public int ItemID
        {
            get { return _itemID; }
            set 
            { 
                _itemID = value;
                OnPropertyChanged(nameof(ItemID));
            }
        }

        public Item Item
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged(nameof(Item));
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public ItemDAO ItemDAO
        {
            get { return _itemDAO; }
            set
            {
                _itemDAO = value;
                OnPropertyChanged(nameof(ItemDAO));
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
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

        //Methods
        /// <summary>
        /// Check if the item is already in the invoice or not
        /// </summary>
        /// <param name="invoiceItem">Item to check</param>
        /// <returns>True if it's already in the invoice, false if it's not</returns>
        private bool CheckIfExist(InvoiceItem invoiceItem)
        {
            foreach (InvoiceItem i in InvoiceItemCollection)
            {
                if (i.Item.Id == invoiceItem.Item.Id)
                {
                    i.Quantity += invoiceItem.Quantity;
                    i.Price = i.Item.Price * i.Quantity;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Search an item with the id entry by user in the associated view and show ErrorMessage if the item doesn't exist
        /// </summary>
        public void SearchItem()
        {
            ErrorMessage = "";
            Item = ItemDAO.findById(ItemID);
            if (Item == null)
            {
                ErrorMessage = "* Article inexistant";
            }
        }

        //Command methods
        private bool CanExecuteAddItemCommand(object obj)
        {
            bool validData;

            if (Item == null || Quantity < 1)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        private void ExecuteAddItemCommand(object obj)
        {
            InvoiceItem i = new InvoiceItem(Item, Quantity);
            if (!CheckIfExist(i))
            {

                InvoiceItemCollection.Add(i);
            }
            CloseWindow();
        }

        private void CloseWindow()
        {
            var window = System.Windows.Application.Current.Windows.OfType<AddItemToInvoiceView>().FirstOrDefault();
            if (window != null)
            {
                window.Close();
            }
        }

    }//end class
}//end namespace
