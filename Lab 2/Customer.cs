using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
    {
    public class Customer
        {
        public string _name;
        public string _password;
        public List<Products> _cart;


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
            set { _cart = new List<Products>(); }
            }

        public Customer(string name, string password)
            {
            Name = name;
            Password = password;
            }

        public override string ToString()
            {
            return $"Namn: {Name} Lösenord: {Password} Kundvagn: {Cart}";
            }
        }


    }
