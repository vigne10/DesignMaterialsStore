using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesignMaterialsStore.Model
{
    public class Worker : ModelBase
    {

        //Fields
        private int _id;
        private string _name;
        private string _surname;
        private string _address;
        private string _login;
        private SecureString _password;
        private Boolean _active;

        private string nameAndSurnamePattern = "^[a-zA-ZÀ-ÖØ-öø-ÿ-]+$";
        private string loginPattern = "^[a-zA-Z][a-zA-Z0-9]*$";
        private string passwordPattern = "^\\S+$";

        //Constructors
        public Worker() { }

        public Worker(int id, string name, string surname, string address, string login, SecureString password, bool active)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            Login = login;
            Password = password;
            Active = active;
        }

        public Worker(string name, string surname, string address, string login, SecureString password)
        {
            Name = name;
            Surname = surname;
            Address = address;
            Login = login;
            Password = password;
            Active = true;
        }

        public Worker(string name, string surname, string address, string login, SecureString password, bool active)
        {
            Name = name;
            Surname = surname;
            Address = address;
            Login = login;
            Password = password;
            Active = active;
        }

        //Properties
        public int Id
        {
            get 
            { 
                return _id; 
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

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

        public bool Active
        {
            get 
            { 
                return _active; 
            }
            set
            {
                _active = value;
                OnPropertyChanged(nameof(Active));
            }
        }

        //Methods

        /// <summary>
        /// Check if the string match with the nameAndSurname regex
        /// </summary>
        /// <param name="str">String to check</param>
        /// <returns>true if it's ok, false if it's not</returns>
        public bool CheckNameAndSurname(string str)
        {
            if (str.Length > 3 && Regex.IsMatch(str, nameAndSurnamePattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if the login match with the login regex
        /// </summary>
        /// <param name="str">login to check</param>
        /// <returns>true if it's ok, false if it's not</returns>
        public bool CheckLogin(string str)
        {
            if (str.Length > 3 && Regex.IsMatch(str, loginPattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if the password match with the password regex
        /// </summary>
        /// <param name="str">Password to check</param>
        /// <returns>True if it's ok, false if it's not</returns>
        public bool CheckPassword(SecureString str)
        {
            IntPtr bstr = Marshal.SecureStringToBSTR(str);
            try
            {
                string plainString = Marshal.PtrToStringBSTR(bstr);
                if (plainString.Length > 5 && Regex.IsMatch(plainString, passwordPattern))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                Marshal.ZeroFreeBSTR(bstr);
            }
        }

        /// <summary>
        /// Check all the properties of a worker
        /// </summary>
        /// <returns>Null if it's ok, error message if it's not</returns>
        public string CheckAllProperties()
        {
            if (!CheckNameAndSurname(Name) || !CheckNameAndSurname(Surname))
            {
                return "* Nom ou prénom incorrect";
            }
            else if (!CheckLogin(Login))
            {
                return "* Nom d'utilisateur incorrect";
            }
            else if (!CheckPassword(Password))
            {
                return "* Mot de passe incorrect";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Check all the properties of a worker except the password
        /// </summary>
        /// <returns>Null if it's ok, error message if it's not</returns>
        public string CheckAllPropertiesWithoutPassword()
        {
            if (!CheckNameAndSurname(Name) || !CheckNameAndSurname(Surname))
            {
                return "* Nom ou prénom incorrect";
            }
            else if (!CheckLogin(Login))
            {
                return "* Nom d'utilisateur incorrect";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Method that puts name and surname in uppercase and the login in lowercase
        /// </summary>
        public void UpperLowerMethod() 
        {
            Name = Name.ToUpper();
            Surname = Surname.ToUpper();
            Login = Login.ToLower();
        }

    }//end class
}//end namespace
