using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
    {
    public class Products
        {
        public string _product;
        public int _price;

        public string Product
            {
            get { return _product; }
            set { _product = value; }
            }

        public int Price
            {
            get { return _price; }
            set { _price = value; }
            }

        public Products(string product, int price)
            {
            Product = product;
            Price = price;
            }

        }
    }
