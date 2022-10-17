using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
    {
    public class Customer
        {
        private string _name;
        private string _password;
        private List<Products> _cart;


        public string Name
            {
            get { return _name; }
            set { _name = value; }
            }

        private string Password
            {
            get { return _password; }
            set { _password = value; }
            }

        public List<Products> Cart
            {
            get { return _cart; }
            private set { _cart = value; }
            }

        public Customer(string name, string password)
            {
            Name = name;
            Password = password;
            Cart = new List<Products>();
            }

        public override string ToString()
            {
            string products = string.Empty;

            foreach (var product in Cart)
                {
                products += product.Product;
                }

            return $"{Name}\n{Password}\n{products}";
            }

        public bool VerifyPassword(string password)
        {
            if (password == _password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        }

    }
