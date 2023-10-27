using DesignMaterialsStore.DAO.implement;
using DesignMaterialsStore.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using DesignMaterialsStore.Model;
using DesignMaterialsStore.View;
using System.Text.RegularExpressions;
using System.Globalization;

namespace DesignMaterialsStore.ViewModel
{
    public class EditItemViewModel : ViewModelBase
    {

        //Fields
        private ItemDAO iDAO;
        private Item _itemToEdit;
        private Item _itemBeforeEdit;
        private string _price;
        private string _errorMessage;

        private string pricePattern = "^\\d*([.,]\\d{0,2})?$";

        //Commands
        public ICommand DeleteCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        //Constructor
        public EditItemViewModel(Item iToEdit)
        {
            iDAO = DAOFactory.getItemDAO();
            ItemToEdit = iToEdit;
            ItemBeforeEdit = BackupItem(iToEdit);
            Price = ItemToEdit.Price.ToString();
            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand);
            SaveCommand = new ViewModelCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);
        }

        //Properties
        public Item ItemToEdit
        {
            get
            {
                return _itemToEdit;
            }
            set
            {
                _itemToEdit = value;
                OnPropertyChanged(nameof(ItemToEdit));
            }
        }

        public Item ItemBeforeEdit
        {
            get
            {
                return _itemBeforeEdit;
            }
            set
            {
                _itemBeforeEdit = value;
                OnPropertyChanged(nameof(ItemBeforeEdit));
            }
        }

        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (Regex.IsMatch(value, pricePattern))
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
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
        /// Create a backup of the item to edit
        /// </summary>
        /// <returns>A copy of the item to edit</returns>
        public Item BackupItem(Item itemToSave)
        {
            Item backupItem = new Item(itemToSave.Name,
                                             itemToSave.Description,
                                             itemToSave.Price,
                                             itemToSave.Active);
            return backupItem;
        }

        /// <summary>
        /// Restore the item to edit with the backup
        /// </summary>
        public void RestoreItem(Item actualItem, Item itemToRestore)
        {
            actualItem.Name = itemToRestore.Name;
            actualItem.Description = itemToRestore.Description;
            actualItem.Price = itemToRestore.Price;
            actualItem.Active = itemToRestore.Active;
        }

        /// <summary>
        /// Method to convert a string in double
        /// </summary>
        /// <param name="input">String to convert</param>
        /// <returns>Converted string</returns>
        public static double ParseDouble(string input)
        {
            // Replace the comma with the dot to ensure that the current culture does not affect the result
            input = input.Replace(',', '.');

            // Finding the first occurrence of the dot in the string
            int dotIndex = input.IndexOf('.');

            // If the dot is the last character, it is removed
            if (dotIndex == input.Length - 1)
            {
                input = input.Substring(0, dotIndex);
            }
            else if (dotIndex != -1) // If the dot is present in the string, we extract the decimal part
            {
                string decimalPart = input.Substring(dotIndex + 1);
                // If the decimal part is empty, we delete the dot
                if (string.IsNullOrWhiteSpace(decimalPart))
                {
                    input = input.Substring(0, dotIndex);
                }
                else // Otherwise, we keep only two digits after the comma
                {
                    decimalPart = decimalPart.Substring(0, Math.Min(decimalPart.Length, 2));
                    input = input.Substring(0, dotIndex + 1) + decimalPart;
                }
            }

            // Use the double.TryParse method to convert the string to a floating number
            double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double result);

            return result;
        }

        //Commands methods
        private void ExecuteDeleteCommand(object obj)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Voulez-vous vraiment supprimer cet article ?", "Confirmation de suppression", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (iDAO.CheckIfCanBeDelete(ItemToEdit))
                {
                    iDAO.delete(ItemToEdit);
                    CloseWindow();
                }
                else
                {
                    ErrorMessage = "* Cet article ne peut pas être supprimé";
                }
            }
        }

        private bool CanExecuteSaveCommand(object obj)
        {
            bool validData;

            if (string.IsNullOrWhiteSpace(ItemToEdit.Name) || string.IsNullOrEmpty(ItemToEdit.Description) || string.IsNullOrWhiteSpace(Price))
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        private void ExecuteSaveCommand(object obj)
        {

            string successMessage = "* Modifications enregistrées";

            ItemToEdit.Name = ItemToEdit.Name.ToUpper();
            ErrorMessage = ItemToEdit.CheckName();
            if (ErrorMessage == null)
            {
                ItemToEdit.Price = ParseDouble(Price);
                iDAO.update(ItemToEdit);
                ErrorMessage = successMessage;
            }
        }

        private void ExecuteCancelCommand(object obj)
        {
            RestoreItem(ItemToEdit, ItemBeforeEdit);
            Price = ItemBeforeEdit.Price.ToString();
        }

        

        private void CloseWindow()
        {
            var window = System.Windows.Application.Current.Windows.OfType<EditItemView>().FirstOrDefault();
            if (window != null)
            {
                window.Close();
            }
        }

    }//end class
}//end namespace
