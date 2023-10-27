using DesignMaterialsStore.CustomControls;
using DesignMaterialsStore.DAO;
using DesignMaterialsStore.DAO.implement;
using DesignMaterialsStore.Model;
using DesignMaterialsStore.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DesignMaterialsStore.ViewModel
{
    public class EditWorkerViewModel : ViewModelBase
    {

        //Fields
        private WorkerDAO wDAO;
        private Worker _workerToEdit;
        private Worker _workerBeforeEdit;
        private SecureString _oldPasswordEntryByUser;
        private SecureString _newPasswordEntryByUser;
        private string _errorMessage;

        //Commands
        public ICommand DeleteCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        //Constructor
        public EditWorkerViewModel(Worker wToEdit)
        {
            wDAO = DAOFactory.getWorkerDAO();
            WorkerToEdit = wToEdit;
            WorkerBeforeEdit = BackupWorker(wToEdit);
            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand);
            SaveCommand = new ViewModelCommand(ExecuteSaveCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);
        }

        //Properties
        public Worker WorkerToEdit
        {
            get
            {
                return _workerToEdit;
            }
            set
            {
                _workerToEdit = value;
                OnPropertyChanged(nameof(WorkerToEdit));
            }
        }

        public Worker WorkerBeforeEdit
        {
            get
            {
                return _workerBeforeEdit;
            }
            set
            {
                _workerBeforeEdit = value;
                OnPropertyChanged(nameof(WorkerBeforeEdit));
            }
        }

        public SecureString OldPasswordEntryByUser
        {
            get
            {
                return _oldPasswordEntryByUser;
            }
            set
            {
                _oldPasswordEntryByUser = value;
                OnPropertyChanged(nameof(OldPasswordEntryByUser));
            }
        }
        

        public SecureString NewPasswordEntryByUser
        {
            get
            {
                return _newPasswordEntryByUser;
            }
            set
            {
                _newPasswordEntryByUser = value;
                OnPropertyChanged(nameof(NewPasswordEntryByUser));
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
        /// Restore the worker to edit with the backup
        /// </summary>
        public void RestoreWorker(Worker actualWorker, Worker workerToRestore)
        {
            actualWorker.Name = workerToRestore.Name;
            actualWorker.Surname = workerToRestore.Surname;
            actualWorker.Address = workerToRestore.Address;
            actualWorker.Login = workerToRestore.Login;
            actualWorker.Password = workerToRestore.Password;
            actualWorker.Active = workerToRestore.Active;
        }

        /// <summary>
        /// Change the password of the worker in the program and in the DB
        /// </summary>
        public void ChangePassword()
        {
            WorkerToEdit.Password = NewPasswordEntryByUser;
            wDAO.updatePassword(WorkerToEdit);
        }

        /// <summary>
        /// Create a backup of the worker to edit
        /// </summary>
        /// <returns>A copy of the worker to edit</returns>
        public Worker BackupWorker(Worker workerToSave)
        {
            Worker backupWorker = new Worker(workerToSave.Name,
                                             workerToSave.Surname,
                                             workerToSave.Address,
                                             workerToSave.Login,
                                             workerToSave.Password,
                                             workerToSave.Active);
            return backupWorker;
        }

        //public void ResetPasswordView()
        //{
        //    if (OldPasswordEntryByUser != null)
        //    {

        //        OldPasswordEntryByUser.Clear();
        //        OldPasswordEntryByUser.Dispose();
        //        OldPasswordEntryByUser = new SecureString();
        //        OnPropertyChanged(nameof(OldPasswordEntryByUser));
        //        OnPropertyChanged(nameof(EditWorkerViewModel));
        //    }
        //    if (NewPasswordEntryByUser != null)
        //    {
        //        NewPasswordEntryByUser.Clear();
        //        NewPasswordEntryByUser.Dispose();
        //        NewPasswordEntryByUser = new SecureString();
        //        OnPropertyChanged(nameof(NewPasswordEntryByUser));
        //        OnPropertyChanged(nameof(EditWorkerViewModel));
        //    }
        //}

        //Commands methods
        private void ExecuteDeleteCommand(object obj)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Voulez-vous vraiment supprimer cet employé ?", "Confirmation de suppression", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                if (wDAO.CheckIfCanBeDelete(WorkerToEdit))
                {
                    wDAO.delete(WorkerToEdit);
                    CloseWindow();
                }
                else
                {
                    ErrorMessage = "* Cet employé ne peut pas être supprimé";
                }
            }
        }

        private void ExecuteSaveCommand(object obj)
        {

            string successMessage = "* Modifications enregistrées";

            if (OldPasswordEntryByUser != null && NewPasswordEntryByUser != null)
            {
                if (wDAO.AuthenticateWorker(WorkerToEdit.Login, OldPasswordEntryByUser))
                {
                    if (WorkerToEdit.CheckPassword(NewPasswordEntryByUser))
                    {
                        WorkerToEdit.UpperLowerMethod();
                        ErrorMessage = WorkerToEdit.CheckAllPropertiesWithoutPassword();
                        if (ErrorMessage == null)
                        {
                            wDAO.update(WorkerToEdit);
                            ChangePassword();
                            ErrorMessage = successMessage;
                        }
                        //ResetPasswordView();
                    }
                    else
                    {
                        ErrorMessage = "* Nouveau mot de passe incorrect !";
                        //ResetPasswordView();
                    }
                }
                else
                {
                    ErrorMessage = "* Ancien mot de passe incorrect !";
                    //ResetPasswordView();
                }

            }
            else
            {
                //ResetPasswordView();
                WorkerToEdit.UpperLowerMethod();
                ErrorMessage = WorkerToEdit.CheckAllPropertiesWithoutPassword();
                if (ErrorMessage == null)
                {
                    wDAO.update(WorkerToEdit);
                    ErrorMessage = successMessage;
                }

            }
        }

        private void ExecuteCancelCommand(object obj)
        {
            RestoreWorker(WorkerToEdit, WorkerBeforeEdit);
        }

        private void CloseWindow()
        {
            var window = System.Windows.Application.Current.Windows.OfType<EditWorkerView>().FirstOrDefault();
            if (window != null)
            {
                window.Close();
            }
        }

    }//end class
}//end namespace
