using DesignMaterialsStore.DAO;
using DesignMaterialsStore.DAO.implement;
using DesignMaterialsStore.Model;
using FontAwesome.Sharp;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace DesignMaterialsStore.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private WorkerAccount _currentWorkerAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        private WorkerDAO workerDAO;

        //Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowItemViewCommand { get; }
        public ICommand ShowClientViewCommand { get; }
        public ICommand ShowWorkerViewCommand { get; }
        public ICommand ShowInvoiceViewCommand { get; }


        //Constructor
        public MainViewModel() 
        {
            workerDAO = DAOFactory.getWorkerDAO();
            CurrentWorkerAccount = new WorkerAccount();
            LoadCurrentWorkerData();

            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowItemViewCommand = new ViewModelCommand(ExecuteShowItemViewCommand);
            ShowClientViewCommand = new ViewModelCommand(ExecuteShowClientViewCommand);
            ShowWorkerViewCommand = new ViewModelCommand(ExecuteShowWorkerViewCommand);
            ShowInvoiceViewCommand = new ViewModelCommand(ExecuteShowInvoiceViewCommand);

            //Default view
            ExecuteShowHomeViewCommand(null);

        }

        //Properties
        public WorkerAccount CurrentWorkerAccount
        {
            get
            {
                return _currentWorkerAccount;
            }
            set
            {
                _currentWorkerAccount = value;
                OnPropertyChanged(nameof(CurrentWorkerAccount));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //Methods
        private void LoadCurrentWorkerData()
        {
            var user = workerDAO.findByLogin(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentWorkerAccount.Login = user.Login;
                CurrentWorkerAccount.DisplayName = $"{user.Surname} {user.Name}";

            }
            else
            {
                CurrentWorkerAccount.DisplayName = "Compte invalide, vous n'êtes pas connecté";
                //Hide child views
            }
        }

        private void ExecuteShowInvoiceViewCommand(object obj)
        {
            CurrentChildView = new InvoiceViewModel();
            Caption = "Factures";
            Icon = IconChar.FileInvoiceDollar;
        }

        private void ExecuteShowWorkerViewCommand(object obj)
        {
            CurrentChildView = new WorkerViewModel();
            Caption = "Employés";
            Icon = IconChar.Briefcase;
        }

        private void ExecuteShowClientViewCommand(object obj)
        {
            CurrentChildView = new ClientViewModel();
            Caption = "Clients";
            Icon = IconChar.Users;
        }

        private void ExecuteShowItemViewCommand(object obj)
        {
            CurrentChildView = new ItemViewModel();
            Caption = "Articles";
            Icon = IconChar.CartShopping;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Accueil";
            Icon = IconChar.Home;
        }

    }//end class
}//end namespace
