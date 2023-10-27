using DesignMaterialsStore.DAO.implement;
using DesignMaterialsStore.DAO;
using DesignMaterialsStore.Model;
using DesignMaterialsStore.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesignMaterialsStore.ViewModel
{
    public class AddClientViewModel : ViewModelBase
    {
        //Fields
        private string _name;
        private string _surname;
        private string _address;
        private string _errorMessage;
        private ClientDAO _clientDAO;
        private ObservableCollection<Client> _clientCollection;

        //Commands
        public ICommand AddClientCommand { get; }

        //Constructor
        public AddClientViewModel(ObservableCollection<Client> cCollection)
        {
            ClientDAO = DAOFactory.getClientDAO();
            AddClientCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
            ClientCollection = cCollection;
        }

        //Properties
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
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

        public ObservableCollection<Client> ClientCollection
        {
            get
            {
                return _clientCollection;
            }
            set
            {
                _clientCollection = value;
                OnPropertyChanged(nameof(ClientCollection));
            }
        }

        //Command methods
        private bool CanExecuteAddCommand(object obj)
        {
            bool validData;

            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Surname))
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        private void ExecuteAddCommand(object obj)
        {

            Client c = new Client(Name, Surname, Address);
            c.UpperLowerMethod();
            if (!ClientDAO.CheckIfExist(c.Name, c.Surname))
            {
                string message = c.CheckNameAndSurname();
                if (message == null)
                {
                    ClientDAO.create(c);
                    c = ClientDAO.findByNameAndSurname(c.Name, c.Surname);
                    ClientCollection.Add(c);
                    CloseWindow();
                }
                else
                {
                    ErrorMessage = message;
                }
            }
            else
            {
                ErrorMessage = $"L'utilisateur {c.Surname} {c.Name} existe déjà !";
            }

        }

        private void CloseWindow()
        {
            var window = System.Windows.Application.Current.Windows.OfType<AddClientView>().FirstOrDefault();
            if (window != null)
            {
                window.Close();
            }
        }

    }//end class
}//end namespace
