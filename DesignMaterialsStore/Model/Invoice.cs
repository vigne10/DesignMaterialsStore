using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMaterialsStore.Model
{
    public class Invoice : ModelBase
    {

        //Fields
        private int _id;
        private Worker _worker;
        private Client _client;
        private DateTime _date;
        private double _price;

        //Constructors
        public Invoice() { } //empty constructor

        public Invoice(int id, Worker worker, Client client, DateTime date, double price)
        {
            Id = id;
            Worker = worker;
            Client = client;
            Date = date;
            Price = price;
        }

        public Invoice(Worker worker, Client client, DateTime date, double price)
        {
            Worker = worker;
            Client = client;
            Date = date;
            Price = price;
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

        public Worker Worker
        {
            get { return _worker; }
            set
            {
                _worker = value;
                OnPropertyChanged(nameof(Worker));
            }
        }

        public Client Client
        {
            get { return _client; }
            set
            {
                _client = value;
                OnPropertyChanged(nameof(Client));
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
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

    }//end class
}//end namespace
