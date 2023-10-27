using DesignMaterialsStore.DAO;
using DesignMaterialsStore.DAO.implement;
using DesignMaterialsStore.Model;
using DesignMaterialsStore.View;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DesignMaterialsStore.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {

        //Fields
        private string _name;
        private string _surname;
        private string _address;
        private string _login;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible;
        private WorkerDAO _workerDAO;

        //Commands
        public ICommand RegisterCommand { get; }

        //Constructor
        public RegisterViewModel()
        {
            WorkerDAO = DAOFactory.getWorkerDAO();
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
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

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
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

        //Commands methods
        private bool CanExecuteRegisterCommand(object obj)
        {
            bool validData;

            if(string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Surname) || string.IsNullOrWhiteSpace(Login) || SecureString.Equals(Password, null))
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        private void ExecuteRegisterCommand(object obj)
        {

            string successMessage = "Employé ajouté avec succès !";

            Worker w = new Worker(Name, Surname, Address, Login, Password);
            w.UpperLowerMethod();
            if (!WorkerDAO.CheckIfExist(w.Name, w.Surname))
            {
                string message = w.CheckAllProperties();
                if (message == null)
                {
                    WorkerDAO.create(w);
                    ErrorMessage = successMessage;
                }
                else
                {
                    ErrorMessage = message;
                }
            }
            else
            {
                ErrorMessage = $"L'employé {w.Surname} {w.Name} existe déjà !";
            }

        }

    }//end class
}//end namespace
