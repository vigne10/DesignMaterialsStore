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
    public class ItemViewModel : ViewModelBase
    {

        //Fields
        private ItemDAO iDAO;
        private ObservableCollection<Item> _itemsCollection;
        private Item _selectedItem;

        //Commands
        public ICommand AddItemCommand { get; }


        //Constructor
        public ItemViewModel()
        {
            iDAO = DAOFactory.getItemDAO();
            ItemsCollection = iDAO.findAll();
            SelectedItem = new Item();
            AddItemCommand = new ViewModelCommand(ExecuteAddItemCommand);
        }

        //Properties
        public ObservableCollection<Item> ItemsCollection
        {
            get
            {
                return _itemsCollection;
            }
            set
            {
                _itemsCollection = value;
                OnPropertyChanged(nameof(ItemsCollection));
            }
        }

        public Item SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        //Methods
        private void ExecuteAddItemCommand(object obj)
        {
            AddItemView addView = new AddItemView(ItemsCollection);
            addView.Show();
        }

    }//end class
}//end namespace
