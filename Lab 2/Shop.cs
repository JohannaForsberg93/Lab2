using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
    {
    public class Shop
        {

        //LISTOR
        public List<Products> StockList = new List<Products>
        {
            new Products("Banan", 15),
            new Products("Melon", 20),
            new Products("Kiwi", 25),
        };

        public List<Customer> CustomerList = new List<Customer>
        {
            new Customer("Bert", "123"),
            new Customer("Lilo", "456"),
            new Customer("Farmor", "789")
        };

        //METODER
        public void FirstMenu()
            {
            Console.WriteLine("Välkommen till min affär!\n");
            Console.WriteLine("Välj 1 för Ny kund.");
            Console.WriteLine("Välj 2 för Logga in");

            var number = int.Parse(Console.ReadLine());
            Console.Clear();

            if (number == 1)
                {

                CreateCustomer();

                }
            else if (number == 2)
                {
                LogIn();
                }
            Console.ReadKey();
            }

        public void CreateCustomer()
            {
            Console.WriteLine("Ny kund\n");
            Console.WriteLine("Namn: ");
            var inputUser = Console.ReadLine();
            Console.WriteLine("Lösenord: ");
            var inputPassword = Console.ReadLine();
            var customer = new Customer(inputUser, inputPassword);

            CustomerList.Add(customer);
            Console.Clear();
            Console.WriteLine($"Välkommen {customer.Name}!");

            SecondMenu();
            }

        public void CheckForCustomer(string name)
            {
            var result = CustomerList.Find(x => x.Name == name);

            if (result != null)
                {
                PasswordCheck(name);
                }
            else
                {
                Console.WriteLine("Kunde inte hitta dig som kund.");
                Console.WriteLine("Vill du registera dig som ny kund eller försöka igen? Välj 1 eller 2 \n");
                Console.WriteLine("1. Registrera ny kund.");
                Console.WriteLine("2. Försöka igen.");
                var input = int.Parse(Console.ReadLine());

                if (input == 1)
                    {
                    Console.Clear();
                    CreateCustomer();
                    }
                else if (input == 2)
                    {
                    Console.Clear();
                    LogIn();
                    }
                }
            }

        public void LogIn()

            {
            Console.WriteLine($"Skriv ditt namn: ");
            var name = Console.ReadLine();
            CheckForCustomer(name);

            }

        public void PasswordCheck(string name)
            {
            Console.WriteLine("Skriv ditt lösenord: ");
            var password = Console.ReadLine();

            var result = CustomerList.Find(x => x._password == password);

            if (result != null)
                {
                Console.Clear();
                Console.WriteLine($"Välkommen {name}!");
                SecondMenu();
                }
            else
                {
                Console.Clear();
                Console.WriteLine("Fel lösenord. Försök igen!\n");
                PasswordCheck(name);
                }
            }

        public void SecondMenu()
            {
            var cart = new List<Products>();

            Console.WriteLine("Välj alternativ: \n");
            Console.WriteLine("1. Handla");
            Console.WriteLine("2. Se kundvagn");
            Console.WriteLine("3. Gå till kassan \n");

            var input = int.Parse(Console.ReadLine());

            switch (input)
                {
                case 1:

                    Shopping();

                    break;

                case 2:

                    foreach (var products in cart)
                        {
                        Console.WriteLine($"Produkter i kundlistan just nu: {products.Product}");
                        }

                    break;
                case 3:
                    break;
                }

            }

        public void Shopping()
            {
            int index = 1;
            Console.WriteLine("Vad vill du handla idag? Välj med siffror.");
            foreach (var item in StockList)
                {
                Console.WriteLine($" {index}. {item.Product} {item.Price}:-");
                index++;
                }

            var input = int.Parse(Console.ReadLine());

            switch (input)
                {
                case 1:

                    Console.Clear();
                    // .Add(new Products("Banan", 15));
                    Console.WriteLine("Har lagt till en banan till din kundvagn!");
                    Console.Clear();
                    SecondMenu();

                    break;

                case 2:
                    Console.Clear();

                    // .Add(new Products("Melon", 20));
                    Console.WriteLine("Har lagt till en melon till din kundvagn!");
                    SecondMenu();

                    break;

                case 3:
                    Console.Clear();
                    // .Add(new Products("Kiwi", 25));
                    Console.WriteLine("Har lagt till en kiwi till din kundvagn!");
                    SecondMenu();

                    break;
                }
            }
        }
    }









