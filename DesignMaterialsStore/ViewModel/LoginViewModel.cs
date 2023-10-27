using DesignMaterialsStore.DAO;
using DesignMaterialsStore.DAO.implement;
using DesignMaterialsStore.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesignMaterialsStore.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private WorkerDAO _workerDAO;


        //Commands
        public ICommand LoginCommand { get; }

        //Constructor
        public LoginViewModel()
        {
            WorkerDAO = DAOFactory.getWorkerDAO();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        //Properties
        public string Username
        {
            get
            {
                 return _username;
            }
            set
            {

                _username = value;
                OnPropertyChanged(nameof(Username));
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

        //Methods
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if(string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        //private void ExecuteLoginCommand(object obj)
        //{
        //    var isValidUser = WorkerDAO.AuthenticateWorker(new System.Net.NetworkCredential(Username, Password));
        //    if(isValidUser)
        //    {
        //        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
        //        IsViewVisible = false;
        //    }
        //    else
        //    {
        //        ErrorMessage = "* Identifiant ou mot de passe incorrect";
        //    }
        //}

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = WorkerDAO.AuthenticateWorker(Username, Password);
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Identifiant ou mot de passe incorrect";
            }
        }

    }//end class
}//end namespace
