using DesignMaterialsStore.DAO.implement;
using DesignMaterialsStore.DAO;
using DesignMaterialsStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using DesignMaterialsStore.View;

namespace DesignMaterialsStore.ViewModel
{
    public class EditClientViewModel : ViewModelBase
    {

        //Fields
        private ClientDAO cDAO;
        private Client _clientToEdit;
        private Client _clientBeforeEdit;
        private string _errorMessage;

        //Commands
        public ICommand DeleteCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        //Constructor
        public EditClientViewModel(Client cToEdit)
        {
            cDAO = DAOFactory.getClientDAO();
            ClientToEdit = cToEdit;
            ClientBeforeEdit = BackupClient(cToEdit);
            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand);
            SaveCommand = new ViewModelCommand(ExecuteSaveCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);
        }

        //Properties
        public Client ClientToEdit
        {
            get
            {
                return _clientToEdit;
            }
            set
            {
                _clientToEdit = value;
                OnPropertyChanged(nameof(_clientToEdit));
            }
        }

        public Client ClientBeforeEdit
        {
            get
            {
                return _clientBeforeEdit;
            }
            set
            {
                _clientBeforeEdit = value;
                OnPropertyChanged(nameof(ClientBeforeEdit));
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
        /// Restore the client to edit with the backup
        /// </summary>
        public void RestoreClient(Client actualClient, Client clientToRestore)
        {
            actualClient.Name = clientToRestore.Name;
            actualClient.Surname = clientToRestore.Surname;
            actualClient.Address = clientToRestore.Address;
            actualClient.Active = clientToRestore.Active;
        }

        /// <summary>
        /// Create a backup of the client to edit
        /// </summary>
        /// <returns>A copy of the client to edit</returns>
        public Client BackupClient(Client clientToSave)
        {
            Client backupClient = new Client(clientToSave.Name,
                                             clientToSave.Surname,
                                             clientToSave.Address,
                                             clientToSave.Active);
            return backupClient;
        }

        //Commands methods
        private void ExecuteDeleteCommand(object obj)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Voulez-vous vraiment supprimer ce client ?", "Confirmation de suppression", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (cDAO.CheckIfCanBeDelete(ClientToEdit))
                {
                    cDAO.delete(ClientToEdit);
                    CloseWindow();
                }
                else
                {
                    ErrorMessage = "* Ce client ne peut pas être supprimé";
                }
            }
        }

        private void ExecuteSaveCommand(object obj)
        {

            string successMessage = "* Modifications enregistrées";

            ClientToEdit.UpperLowerMethod();
            ErrorMessage = ClientToEdit.CheckNameAndSurname();
            if (ErrorMessage == null)
            {
                cDAO.update(ClientToEdit);
                ErrorMessage = successMessage;
            }
        }

        private void ExecuteCancelCommand(object obj)
        {
            RestoreClient(ClientToEdit, ClientBeforeEdit);
        }

        private void CloseWindow()
        {
            var window = System.Windows.Application.Current.Windows.OfType<EditClientView>().FirstOrDefault();
            if (window != null)
            {
                window.Close();
            }
        }

    }//end class
}//end namespace
