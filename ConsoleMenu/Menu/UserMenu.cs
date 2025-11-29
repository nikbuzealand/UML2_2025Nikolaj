using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenu.Controllers.Customers;
using ConsoleMenu.Controllers.MenuItems;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

namespace ConsoleMenu.Menu
{
    public class UserMenu
    {
        #region Instance field
        private static string mainMenuChoices = "\t1.Show pizzas\n\t2.Show customers\n\t3.Add customer\n\t4.Add pizza\n\tQ.Quit\n\n\tSelect action:";

        private CustomerRepository _customerRepository = new CustomerRepository();
        private MenuItemRepository _menuItemRepository = new MenuItemRepository();
        private static string ReadChoice(string choices)
        {
            Console.Clear();
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }
        #endregion

        #region Methods
        public void ShowMenu()
        {
            string theChoice = ReadChoice(mainMenuChoices);
            while (theChoice != "q")
            {
                switch (theChoice)
                {
                    case "1":
                        Console.WriteLine("Choice 1");
                        ShowMenuItemController showMenuItemController = new ShowMenuItemController(_menuItemRepository);
                        showMenuItemController.ShowAllMenuItems();
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Choice 2");
                        _customerRepository.PrintAllCustomers();
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Choice 3");
                        Console.WriteLine("Insert customer name:");
                        string name1 = Console.ReadLine();
                        Console.WriteLine("Insert customer phone number:");
                        string mobile1 = Console.ReadLine();
                        Console.WriteLine("Insert customer address:");
                        string address1 = Console.ReadLine();
                        Console.WriteLine("Is this customer a club member? (y/n):");
                        string clubMemberString1 = Console.ReadLine().ToLower();
                        bool isClubMember1 = (clubMemberString1[0] == 'y') ? true : false;
                        Console.WriteLine("Is this customer a VIP? (y/n):");
                        string vipString1 = Console.ReadLine().ToLower();
                        bool isVIP1 = (vipString1[0] == 'y') ? true : false;
                        if (isVIP1 == false)
                        {
                            AddCustomerController addCustomerController = new AddCustomerController(name1, mobile1, address1, isClubMember1, _customerRepository);
                            addCustomerController.AddCustomer();
                        }
                        else
                        {
                            Console.WriteLine("Insert customer VIP discount:");
                            string vipDiscountString1 = Console.ReadLine();
                            int vipDiscount1 = Convert.ToInt32(vipDiscountString1);
                            AddVIPCustomerController addCustomerController = new AddVIPCustomerController(name1, mobile1, address1, isClubMember1, vipDiscount1, _customerRepository);
                            addCustomerController.AddVIPCustomer();
                        }
                        break;
                    case "4":
                        Console.WriteLine("Choice 4");
                        Console.WriteLine("Insert pizza name:");
                        string name2 = Console.ReadLine();
                        Console.WriteLine("Insert pizza price:");
                        string priceString = Console.ReadLine();
                        double price2 = Convert.ToDouble(priceString);
                        Console.WriteLine("Insert pizza description:");
                        string description2 = Console.ReadLine();
                        AddMenuItemController addMenuItemController = new AddMenuItemController(name2, price2, description2, MenuType.PIZZECLASSSICHE, _menuItemRepository);
                        addMenuItemController.AddMenuItem();
                        break;
                    default:
                        Console.WriteLine("Insert 1-4 to select an action, or q to quit.");
                        break;
                }
                theChoice = ReadChoice(mainMenuChoices);
            }
        }
        #endregion
    }
}
