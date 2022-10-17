using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_2
    {
    public class Shop
    {

        public Customer? CurrentCustomer = null;

        //LISTOR
        public List<Products> StockList = new List<Products>
        {
            new Products("Banan", 15),
            new Products("Melon", 20),
            new Products("Kiwi", 25),
        };

        public List<Customer> CustomerList = new List<Customer>
        {
            new Customer("Knatte", "123"),
            new Customer("Fnatte", "456"),
            new Customer("Tjatte", "789")
        };

        //FUNKTIONER
        public void FirstMenu()
        {
Console.Clear();
Console.WriteLine("Välkommen till min affär!\n");
            Console.WriteLine("Välj 1 för Ny kund.");
            Console.WriteLine("Välj 2 för Logga in");
            Console.WriteLine("Välj 3 för Avsluta");

            var number = int.Parse(Console.ReadLine());

            if (number == 1)
                {
                    Console.Clear();
                CreateCustomer();
                }
            else if (number == 2)
                {
                    Console.Clear();
                    LogIn();
                }
            else if (number == 3)
            {
                Console.Clear();
                Exit();
            }
        }

        public void CreateCustomer()
            {
            Console.WriteLine("Ny kund\n");
            Console.WriteLine("Namn: ");
            var user = Console.ReadLine();
            Console.WriteLine("Lösenord: ");
            var password = Console.ReadLine();
            var customer = new Customer(user, password);
            CurrentCustomer = customer;

            CustomerList.Add(CurrentCustomer);
            Console.Clear();
            Console.WriteLine($"Välkommen {customer.Name}!");
                    Thread.Sleep(1000);

                    SecondMenu();
            }

        public void CheckForCustomer(string name)
            {
            var result = CustomerList.Find(x => x.Name == name);

            if (result != null)
                {
                PasswordCheck(result);
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
        public void LogOut()
        {
            CurrentCustomer = null;
            Console.Clear();
            Console.WriteLine("Tack för idag!");
            Console.WriteLine("Du är nu utloggad.");
            Thread.Sleep(2000);
            FirstMenu();
        }
        public void Exit()
        {   
            Console.Clear();
            Console.WriteLine("Välkommen åter!");
            Environment.Exit(0);
        }
        public void PasswordCheck(Customer customer)
            {
            Console.WriteLine("Skriv ditt lösenord: ");
            var password = Console.ReadLine();
            
            if (customer.VerifyPassword(password))
                {
                Console.Clear();
                CurrentCustomer = customer;
                Console.WriteLine($"Välkommen tillbaka {CurrentCustomer.Name}!");
                Thread.Sleep(1000);
                SecondMenu();
                }
            else
                {
                Console.Clear();
                Console.WriteLine("Fel lösenord. Försök igen!\n");
                PasswordCheck(customer);
                }
            }
        public void SecondMenu()
            {
                Console.Clear();
                Console.WriteLine("Välj: \n");
            Console.WriteLine("1. Handla");
            Console.WriteLine("2. Se kundvagn");
            Console.WriteLine("3. Gå till kassan");
            Console.WriteLine("4. Avsluta programmet");
            Console.WriteLine("5. Logga ut");

            var input = int.Parse(Console.ReadLine());

            switch (input)
                {
                case 1:
                    Console.Clear();
                    Shopping();
                    break;

                case 2:
                    Console.Clear();
                    ShowCart();
                    break;

                case 3:
                    Console.Clear();
                    CheckOut();
                    break;

                case 4:
                    Console.Clear();
                    Exit();
                    break;
                case 5:
                    Console.Clear();
                    LogOut();
                    break;
                }
            }

        public void Shopping()
            {
            int index = 1;
            Console.WriteLine("Vad vill du handla idag? Välj med siffror.\n");
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
                    CurrentCustomer.Cart.Add(new Products("Banan", 15));
                    Console.WriteLine("Har lagt till en banan till din kundvagn!\n");
                    Console.WriteLine("Vill du handla mer eller gå tillbaka? \n");
                    Console.WriteLine("1.Handla mer");
                    Console.WriteLine("2.Tillbaka");
                    var value1 = int.Parse(Console.ReadLine());

                    if (value1 == 1)
                    {
                        Shopping();
                    }
                    else if (value1 == 2)
                    {
                        SecondMenu();
                    }

                    break;

                case 2:
                    Console.Clear();
                    CurrentCustomer.Cart.Add(new Products("Melon", 20));
                    Console.WriteLine("Har lagt till en melon till din kundvagn!\n");
                    Console.WriteLine("Vill du handla mer eller gå tillbaka? \n");
                    Console.WriteLine("1.Handla mer");
                    Console.WriteLine("2.Tillbaka");
                    var value2 = int.Parse(Console.ReadLine());

                    if (value2 == 1)
                    {
                        Shopping();
                    }
                    else if (value2 == 2)
                    {
                        SecondMenu();
                    }
                    break;

                case 3:
                    Console.Clear();
                    CurrentCustomer.Cart.Add(new Products("Kiwi", 25));
                    Console.WriteLine("Har lagt till en kiwi till din kundvagn!\n");
                    Console.WriteLine("Vill du handla mer eller gå tillbaka? \n");
                    Console.WriteLine("1.Handla mer");
                    Console.WriteLine("2.Tillbaka");
                    var value3 = int.Parse(Console.ReadLine());


                    if (value3 == 1)
                    {
                        Shopping();
                    }
                    else if (value3 == 2)
                    {
                        SecondMenu();
                    }
                    break;
                }
            }
        public void ShowCart()
            {
                Console.Clear();

            var numberOfItems = CurrentCustomer.Cart.Count();
            var sum = 0;
            foreach (var item in CurrentCustomer.Cart)
                {
                sum += item.Price;
                }

            var banan = CurrentCustomer.Cart.Count(x => x.Product == "Banan");
            var melon = CurrentCustomer.Cart.Count(x => x.Product == "Melon");
            var kiwi = CurrentCustomer.Cart.Count(x => x.Product == "Kiwi");

            Console.WriteLine("Produkter i din kundvagn: \n");
            Console.WriteLine($"{banan} st bananer");
            Console.WriteLine($"{melon} st meloner");
            Console.WriteLine($"{kiwi} st kiwi\n");

            Console.WriteLine($"Antal varor: {numberOfItems}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Totalpris: {sum} kr \n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Vill du handla mer eller betala?\n");
            Console.WriteLine("1. Handla mer");
            Console.WriteLine("2. Betala");
            var input = int.Parse(Console.ReadLine());

            if (input == 1)
                {
                Console.Clear();
                Shopping();
                }
            else if (input == 2)
                {
                Console.Clear();
                CheckOut();
                }

            }
        public void CheckOut()
        {
            var numberOfItems = CurrentCustomer.Cart.Count();
            var sum = 0;
            foreach (var item in CurrentCustomer.Cart)
                {
                sum += item.Price;
                }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Totalsumman blev: {sum} kr \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tack för att du handlat!");
            Thread.Sleep(2000);
            Exit();
        }
        }
    }









