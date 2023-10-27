using DesignMaterialsStore.DAO.implement;
using DesignMaterialsStore.DAO;
using DesignMaterialsStore.Model;
using DesignMaterialsStore.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace DesignMaterialsStore.ViewModel
{
    public class AddWorkerViewModel : ViewModelBase
    {

        //Fields
        private string _name;
        private string _surname;
        private string _address;
        private string _login;
        private SecureString _password;
        private string _errorMessage;
        private WorkerDAO _workerDAO;
        private ObservableCollection<Worker> _workerCollection;

        //Commands
        public ICommand AddWorkerCommand { get; }

        //Constructor
        public AddWorkerViewModel(ObservableCollection<Worker> wCollection)
        {
            WorkerDAO = DAOFactory.getWorkerDAO();
            AddWorkerCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
            WorkerCollection = wCollection;
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

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public SecureString Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
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

        public ObservableCollection<Worker> WorkerCollection
        {
            get
            {
                return _workerCollection;
            }
            set
            {
                _workerCollection = value;
                OnPropertyChanged(nameof(WorkerCollection));
            }
        }

        //Command methods
        private bool CanExecuteAddCommand(object obj)
        {
            bool validData;

            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Surname) || string.IsNullOrWhiteSpace(Login) || SecureString.Equals(Password, null))
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

            Worker w = new Worker(Name, Surname, Address, Login, Password);
            w.UpperLowerMethod();
            if(!WorkerDAO.CheckIfExist(w.Name, w.Surname))
            {
                string message = w.CheckAllProperties();
                if (message == null)
                {
                    WorkerDAO.create(w);
                    w = WorkerDAO.findByLogin(w.Login);
                    WorkerCollection.Add(w);
                    CloseWindow();
                }
                else
                {
                    ErrorMessage = message;
                }
            }
            else
            {
                ErrorMessage = $"L'utilisateur {w.Surname} {w.Name} existe déjà !";
            }
            
        }

        private void CloseWindow()
        {
            var window = System.Windows.Application.Current.Windows.OfType<AddWorkerView>().FirstOrDefault();
            if (window != null)
            {
                window.Close();
            }
        }

    }//end class
}//end namespace
