using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace GridToData.Data_Model
{
    public class Order : ModelObject
    {
        DateTime date;
        bool shipped;
        Product product;
        int quantity;

        public Order()
        {
            this.date = DateTime.Today;
            this.shipped = false;
            this.product = new Product("", 0);
            this.Quantity = 0;
        }

        public Order(DateTime date, bool shipped, Product product, int quantity)
        {
            this.date = date;
            this.shipped = shipped;
            this.product = product;
            this.quantity = quantity;
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }

        public bool Shipped
        {
            get { return shipped; }
            set
            {
                if (shipped != value)
                {
                    shipped = value;
                    RaisePropertyChanged("Shipped");
                }
            }
        }

        public Product Product
        {
            get { return product; }
            set
            {
                if (product != value)
                {
                    product = value;
                    RaisePropertyChanged("Product");
                }
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    RaisePropertyChanged("Quantity");
                }
            }
        }
    }

    public class Product : ModelObject
    {
        string name;
        int unitPrice;

        public Product(string name, int unitPrice)
        {
            this.name = name;
            this.unitPrice = unitPrice;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
    }

    public class ModelObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}