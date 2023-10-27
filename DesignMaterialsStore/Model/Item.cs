using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesignMaterialsStore.Model
{
    public class Item : ModelBase
    {

        //Fields
        private int _id;
        private string _name;
        private string _description;
        private double _price;
        private bool _active;

        private string itemNamePattern = "^[a-zA-ZÀ-ÖØ-öø-ÿ-]+$";

        //Constructors
        public Item() { } //empty constructor

        public Item(int id, string name, string description, double price, bool active)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Active = active;
        }

        public Item(string name, string description, double price, bool active)
        {
            Name = name;
            Description = description;
            Price = price;
            Active = active;
        }

        public Item(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
            Active = true;
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

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
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
        /// Check if item's name is correct
        /// </summary>
        /// <returns>Null if it's correct, error message if it's not</returns>
        public string CheckName()
        {
            if (Name.Length < 3 && !Regex.IsMatch(Name, itemNamePattern))
            {
                return "* Nom incorrect";
            }
            else
            {
                return null;
            }
        }

    }//end class
}//end namespace
