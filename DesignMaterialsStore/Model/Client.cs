using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesignMaterialsStore.Model
{
    public class Client : ModelBase
    {

        //Fields
        private int _id;
        private string _name;
        private string _surname;
        private string _address;
        private bool _active;

        private string nameAndSurnamePattern = "^[a-zA-ZÀ-ÖØ-öø-ÿ-]+$";

        //Constructors
        public Client() { } //empty constructor

        public Client(int id, string name, string surname, string address, bool active)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            Active = active;
        }

        public Client(string name, string surname, string address)
        {
            Name = name;
            Surname = surname;
            Address = address;
            Active = true;
        }

        public Client(string name, string surname, string address, bool active)
        {
            Name = name;
            Surname = surname;
            Address = address;
            Active = active;
        }

        //Properties
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public bool Active
        {
            get { return _active; }
            set
            {
                _active = value;
                OnPropertyChanged(nameof(Active));
            }
        }

        //Methods

        /// <summary>
        /// Method that puts name and surname in uppercase and the login in lowercase
        /// </summary>
        public void UpperLowerMethod()
        {
            Name = Name.ToUpper();
            Surname = Surname.ToUpper();
        }

        /// <summary>
        /// Check if the name and the surname are correct
        /// </summary>
        /// <returns>Null if it's correct, error message if it's not</returns>
        public string CheckNameAndSurname()
        {
            if (Name.Length < 3 && !Regex.IsMatch(Name, nameAndSurnamePattern))
            {
                return "* Nom incorrect";
            }
            if(Surname.Length < 3 && !Regex.IsMatch(Surname, nameAndSurnamePattern))
            {
                return "* Prénom incorrect";
            }
            else
            {
                return null;
            }
        }

    }//end class
}//end namespace
