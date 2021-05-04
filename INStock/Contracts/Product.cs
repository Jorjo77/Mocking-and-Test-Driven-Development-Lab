
using System;

namespace INStock.Contracts
{
    public class Product : IProduct, IComparable
    {
        private string label;
        private decimal price;

        public Product(string label, decimal price)
        {
            Label = label;
            Price = price;
        }

        public string Label 
        {
            get
            {
                return this.label;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.label = value;
            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0 )
                {
                    throw new ArgumentException();
                }
                this.price = value;
            }
        }

        public int CompareTo(object obj)
        {
            var otherProduct = obj as IProduct;
            if (this.Price > otherProduct.Price)
            {
                return 1;
            }
            else if (this.Price < otherProduct.Price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

    }
}
