using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoldBadgeApps
{
    public class CafeUI
    {
        private readonly CafeMenuRepo _cafeMenu;
        public CafeUI(CafeMenuRepo Menu)
        {
            _cafeMenu = Menu;
        }
        public void Run()
        {
            StockMenu();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            Console.WriteLine("Welcome to the cafe!");
            while (continueToRun)
            {
                Console.WriteLine("How can I help you? \n" +
                    "1) Add to Menu \n" +
                    "2) See Menu \n" +
                    "3) Remove From Menu \n" +
                    "4) Order \n" +
                    "5) Leave");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddToMenu();
                        break;
                    case 2:
                        ShowMenu();
                        break;
                    case 3:
                        Remove();
                        break;
                    case 4:
                        Order();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Thank you for visiting the cafe! Please come again!");
                        Thread.Sleep(1500);
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void ShowMenu()
        {
            Console.Clear();
            List<CafeItem> listOfItems = _cafeMenu.GetMenu();
            foreach (var x in listOfItems)
            {
                Console.WriteLine($"Item number {x.MealNumber}");
                Console.WriteLine(x.Description);
                Console.WriteLine($"{x.Price:C}\n");
                Console.WriteLine("---------------\n");
            }
        }
        public void AddToMenu()
        {
            Console.WriteLine("Enter a description for your addition.");
            string desc = Console.ReadLine();
            Console.WriteLine("Enter the ingredients for the meal seperated by a space.");
            string ingredientsString = Console.ReadLine();
            List<string> ingredients = new List<string>();
            foreach (var x in ingredientsString.Split(' '))
            {
                ingredients.Add(x);
            }
            Console.Write("Please enter the cost of the meal as digits only ");
            double cost = Convert.ToDouble(Console.ReadLine());
            CafeItem cafeItem = new CafeItem(_cafeMenu.Count() +1, desc, ingredients, cost);
            _cafeMenu.AddItem(cafeItem);
            Console.WriteLine("Item was added to menu");
            Thread.Sleep(1250);
            Console.Clear();
        }
        public void Remove()
        {
            Console.WriteLine("Which meal would you like to remove from the menu?");
            int input = Convert.ToInt32(Console.ReadLine());
            _cafeMenu.DeleteItem(input - 1);
            Console.WriteLine("Item was removed from the menu.");
            Thread.Sleep(1500);
        }
        public void Order()
        {
            Console.WriteLine("What meal would you like to order?");
            int input = Convert.ToInt32(Console.ReadLine());
            List<CafeItem> list = _cafeMenu.GetMenu();
            foreach(var x in list)
            {
                if (x.MealNumber == input)
                {
                    Console.WriteLine($"Enjoy your {x.Description}!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }
        private void StockMenu()
        {
            CafeItem number1 = new CafeItem(1, "Hotdog with katsup and mustard and drink", new List<string>{ "beef", "pork", "chicken", "salt" }, 4.50);
            CafeItem number2 = new CafeItem(2, "Classic single patty cheeseburger and drink", new List<string> { "beef", "cheese", "grease" }, 5.50);
            CafeItem number3 = new CafeItem(3, "Double cheeseburger with bacon and drink", new List<string> { "beef", "cheese", "grease", "bacon" }, 7.00);

            _cafeMenu.AddItem(number1);
            _cafeMenu.AddItem(number2);
            _cafeMenu.AddItem(number3);
        }
    }
}
