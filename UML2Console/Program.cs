using System.Runtime.Intrinsics.X86;
using PizzaLibrary.Exceptions;
using PizzaLibrary.Models;
using PizzaLibrary.Services;


//Testing of CustomerRepository methods, part 1.

CustomerRepository cr1 = new CustomerRepository();

Console.WriteLine("Here is the mock data for customers:");
cr1.PrintAllCustomers();
Console.WriteLine();

Customer c1 = new Customer("Harald", "17301730", "Primary Street");
cr1.AddCustomer(c1);
Console.WriteLine("Another customer should now be present:");
cr1.PrintAllCustomers();
Console.WriteLine();

cr1.RemoveCustomer("11111111");
Console.WriteLine("This should have failed to remove a customer since the number didn't match:");
cr1.PrintAllCustomers();
Console.WriteLine();

cr1.RemoveCustomer("13131313");
Console.WriteLine("This should have succeeded in removing a customer since the number did match:");
cr1.PrintAllCustomers();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();


//Testing of MenuItemRepository methods, part 1.

MenuItemRepository mir1 = new MenuItemRepository();

Console.WriteLine("Here is the mock data for menu items:");
mir1.PrintAllMenuItems();
Console.WriteLine();

MenuItem mi1 = new MenuItem("Quattro Formaggi", 96, "Tomat, mozzarella, gorgonzola, fontina, parmesan", MenuType.PIZZECLASSSICHE);
mir1.AddMenuItem(mi1);
Console.WriteLine("Another menu item should now be present:");
mir1.PrintAllMenuItems();
Console.WriteLine();

mir1.RemoveMenuItem(10);
Console.WriteLine("This should have failed to remove a menu item since the number didn't match:");
mir1.PrintAllMenuItems();
Console.WriteLine();

mir1.RemoveMenuItem(4);
Console.WriteLine("This should have succeeded in removing a menu item since the number did match:");
mir1.PrintAllMenuItems();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();


//Testing of CustomerRepository methods, part 2.

Customer c2 = new Customer("Kasper", "43214321", "Secondary Road, Roskilde");
c2.ClubMember = true;
cr1.AddCustomer(c2);
Console.WriteLine("This should have succeeded in adding a new customer who is a club member.");
cr1.PrintAllCustomers();
Console.WriteLine();
Console.WriteLine("This should only print Kasper, the only customer who is a club member.");
cr1.PrintAllClubMembers();
Console.WriteLine();
Console.WriteLine("This should only print Kasper, the only customer from Roskilde.");
cr1.PrintAllCustomersFromRoskilde();
Console.WriteLine();
Console.WriteLine("This should print all customers with 'Street' in their address.");
cr1.PrintAllCustomersFromLocation("Street");
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();


//Testing of MenuItemRepository methods, part 2.

MenuItem mi2 = new MenuItem("Giga Deluxe", 97, "Tomat, mozzarella, pepperoni, asparages, majs", MenuType.PIZZESPECIALI);
MenuItem mi3 = new MenuItem("Giga Double Deluxe", 102, "Tomat, mozzarella, pepperoni, asparages, majs, agurk, ketchup", MenuType.PIZZESPECIALI);
mir1.AddMenuItem(mi2);
mir1.AddMenuItem(mi3);
Console.WriteLine("This should print the Giga Deluxe and Giga Double Deluxe, the two menu items with the type PIZZESPECIALI.");
mir1.PrintMenuType(MenuType.PIZZESPECIALI);
Console.WriteLine();
Console.WriteLine("This should return the Capricciosa, the earliest menu item of type PIZZECLASSICHE that is tied for most expensive.");
Console.WriteLine(mir1.GetMostExpensiveItemOfType(MenuType.PIZZECLASSSICHE));
Console.WriteLine();
Console.WriteLine("This should return the Giga Double Deluxe, the most expensive pizza.");
Console.WriteLine(mir1.GetMostExpensivePizza());
Console.WriteLine();
Console.WriteLine("This should print an entire menu.");
mir1.PrintMenu();
Console.WriteLine();
Console.WriteLine("This should add a new beverage to the menu.");
Beverage b1 = new Beverage("Beer", 32, "A 330ml can of Tuborg", true);
mir1.AddMenuItem(b1);
mir1.PrintAllMenuItems();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();


//Testing of Exceptions

Console.WriteLine("This should have failed to add a customer since it is a duplicate entry:");
try
{
    cr1.AddCustomer(c1);
}
catch (CustomerMobileNumberExist cmne)
{
    Console.WriteLine(cmne.Message);
}
catch (Exception exp)
{
    Console.WriteLine(exp.Message);
}
cr1.PrintAllCustomers();
Console.WriteLine();
Console.WriteLine("This should have failed to add a VIP customer since the discount is too high.");
try
{
    VIPCustomer vipc1 = new VIPCustomer("Mads", "21212121", "Vej 321", 26);
}
catch (InvalidDiscountException ide)
{
    Console.WriteLine(ide.Message);
}
catch (Exception exp)
{
    Console.WriteLine(exp.Message);
}
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();


//Testing of company info

Console.WriteLine("This should create a company info object.");
CompanyInfo ci1 = CompanyInfo.Instance;
ci1.Name = "Big Mamma";
ci1.Vat = 100;
ci1.Cvr = "373799985";
ci1.ClubDiscount = true;
Console.WriteLine(ci1);
Console.WriteLine();
Console.WriteLine("Since CompanyInfo is a singleton, attempting to create a second instance will replace the first.");
Console.WriteLine("Therefore the ci1 object points to the same data as ci2 object.");
Console.WriteLine("Which means changing the name of ci1 will also change the name of ci2, since they reference the same object.");
CompanyInfo ci2 = CompanyInfo.Instance;
ci1.Name = "Small Mamma";
Console.WriteLine(ci1);
Console.WriteLine(ci2);


Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

