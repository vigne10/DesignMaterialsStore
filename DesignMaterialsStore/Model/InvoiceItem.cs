using DesignMaterialsStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMaterialsStore.Model
{
    public class InvoiceItem : ModelBase
    {

        //Fields
        private Invoice _invoice;
        private Item _item;
        private int _quantity;
        private double _price;

        //Constructors
        public InvoiceItem() { } // empty constructor

        public InvoiceItem(Invoice invoice, Item item, int quantity)
        {
            Invoice = invoice;
            Item = item;
            Quantity = quantity;
            ComputePrice();
        }

        public InvoiceItem(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
            ComputePrice();
        }

        //Properties
        public Invoice Invoice
        {
            get { return _invoice; }
            set
            {
                _invoice = value;
                OnPropertyChanged(nameof(Invoice));
            }
        }

        public Item Item
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged(nameof(Item));
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        //Methods

        /// <summary>
        /// Compute the total price of an item based on the desired quantity. The price is rounded to 2 decimal places
        /// </summary>
        public void ComputePrice()
        {
            double unroundedPrice = Quantity * Item.Price;
            Price = Math.Round(unroundedPrice, 2);
        }

    }//end class
}//end namespace
