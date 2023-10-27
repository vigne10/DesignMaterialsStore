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
using System.CodeDom;
using System.Text.RegularExpressions;
using System.Globalization;

namespace DesignMaterialsStore.ViewModel
{
    public class AddItemViewModel : ViewModelBase
    {
        //Fields
        private string _name;
        private string _description;
        private string _price;
        private string _errorMessage;
        private ItemDAO _itemDAO;
        private ObservableCollection<Item> _itemCollection;

        private string pricePattern = "^\\d*([.,]\\d{0,2})?$";

        //Commands
        public ICommand AddItemCommand { get; }

        //Constructor
        public AddItemViewModel(ObservableCollection<Item> iCollection)
        {
            ItemDAO = DAOFactory.getItemDAO();
            AddItemCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
            ItemCollection = iCollection;
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

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
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
                if(Regex.IsMatch(value, pricePattern))
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

        public ItemDAO ItemDAO
        {
            get
            {
                return _itemDAO;
            }
            set
            {
                _itemDAO = value;
                OnPropertyChanged(nameof(ItemDAO));
            }
        }

        public ObservableCollection<Item> ItemCollection
        {
            get
            {
                return _itemCollection;
            }
            set
            {
                _itemCollection = value;
                OnPropertyChanged(nameof(ItemCollection));
            }
        }

        //Methods

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

        //Command methods

        private bool CanExecuteAddCommand(object obj)
        {
            bool validData;

            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Description) || string.IsNullOrWhiteSpace(Price))
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

            Item i = new Item(Name, Description, ParseDouble(Price));
            i.Name = i.Name.ToUpper();
            if (!ItemDAO.CheckIfExist(i.Name))
            {
                string message = i.CheckName();
                if (message == null)
                {
                    ItemDAO.create(i);
                    i = ItemDAO.findByName(i.Name);
                    ItemCollection.Add(i);
                    CloseWindow();
                }
                else
                {
                    ErrorMessage = message;
                }
            }
            else
            {
                ErrorMessage = $"L'article {i.Name} existe déjà !";
            }

        }

        private void CloseWindow()
        {
            var window = System.Windows.Application.Current.Windows.OfType<AddItemView>().FirstOrDefault();
            if (window != null)
            {
                window.Close();
            }
        }

    }//end class
}//end namespace
