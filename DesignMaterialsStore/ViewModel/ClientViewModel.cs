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
using System.Windows.Input;

namespace DesignMaterialsStore.ViewModel
{
    public class ClientViewModel : ViewModelBase
    {
        //Fields
        private ClientDAO cDAO;
        private ObservableCollection<Client> _clientsCollection;
        private Client _selectedClient;

        //Commands
        public ICommand AddClientCommand { get; }


        //Constructor
        public ClientViewModel() 
        {
            cDAO = DAOFactory.getClientDAO();
            ClientsCollection = cDAO.findAll();
            SelectedClient = new Client();
            AddClientCommand = new ViewModelCommand(ExecuteAddClientCommand);
        }

        //Properties
        public ObservableCollection<Client> ClientsCollection
        {
            get
            { 
                return _clientsCollection; 
            }
            set
            {
                _clientsCollection = value;
                OnPropertyChanged(nameof(ClientsCollection));
            }
        }

        public Client SelectedClient
        {
            get
            {
                return _selectedClient;
            }
            set
            {
                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

        //Methods
        private void ExecuteAddClientCommand(object obj)
        {
            AddClientView addView = new AddClientView(ClientsCollection);
            addView.Show();
        }

    }//end class
}//end namespace
