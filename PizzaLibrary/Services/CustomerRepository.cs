using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Data;
using PizzaLibrary.Exceptions;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace PizzaLibrary.Services
{
    public class CustomerRepository:ICustomerRepository
    {
        #region Instance field
        private Dictionary<string, Customer> _customers;
        #endregion

        #region Properties
        public int Count { get { return GetAll().Count; } }
        #endregion

        #region Constructor
        public CustomerRepository()
        {
            _customers = MockData.CustomerData;
        }
        #endregion

        #region Methods
        //Adds a customer to the list.
        public void AddCustomer(Customer customer)
        {
            //Check for duplicate entries before adding
            if (_customers.ContainsKey(customer.Mobile))
            {
                throw new CustomerMobileNumberExist("Attempted to add a customer with an already registered phone number.");
            }
            else
            {
                _customers.Add(customer.Mobile, customer);
            }

        }

        //Returns a list of all customers.
        public List<Customer> GetAll()
        {
            return _customers.Values.ToList();
        }

        //Returns the customer whose "mobile" value matches the input parameter, or null if no customer is found.
        public Customer? GetCustomerByMobile(string mobile)
        {
            if (_customers.TryGetValue(mobile, out Customer? value))
            {
                return value;
            }
            return null;
        }

        //Prints all customers at one line per customer.
        public void PrintAllCustomers()
        {
            foreach (Customer item in GetAll())
            {
                Console.WriteLine(item);
            }
        }

        //Removes a customer whose "mobile" value matches the input parameter.
        public void RemoveCustomer(string mobile)
        {
            if (_customers.TryGetValue(mobile, out Customer? value))
            {
                _customers.Remove(mobile);
            }
        }

        //Returns a list of customers who are club members.
        public List<Customer> GetClubMembers()
        {
            List<Customer> clubMembers = new List<Customer>();
            foreach (Customer customer in _customers.Values)
            {
                if (customer.ClubMember == true)
                {
                    clubMembers.Add(customer);
                }
            }
            return clubMembers;
        }

        //Prints all club membrs at one line per customer.
        public void PrintAllClubMembers()
        {
            foreach (Customer item in GetClubMembers())
            {
                Console.WriteLine(item);
            }
        }

        //Returns a list of customers whose address contains "Roskilde".
        public List<Customer> GetAllCustomersFromRoskilde()
        {
            List<Customer> customerList = new List<Customer>();
            foreach (Customer c in _customers.Values)
            {
                if (c.Address.Contains("Roskilde"))
                {
                    customerList.Add(c);
                }
            }
            return customerList;
        }

        //Prints a list of customers whose address contains "Roskilde".
        public void PrintAllCustomersFromRoskilde()
        {
            foreach (Customer item in GetAllCustomersFromRoskilde())
            {
                Console.WriteLine(item);
            }
        }

        //Version of the Roskilde function that accepts any location as input.
        public List<Customer> GetAllCustomersFromLocation(string location)
        {
            List<Customer> customerList = new List<Customer>();
            foreach (Customer c in _customers.Values)
            {
                if (c.Address.Contains(location))
                {
                    customerList.Add(c);
                }
            }
            return customerList;
        }

        //Prints a list of customers whose address contains the parameter.
        public void PrintAllCustomersFromLocation(string location)
        {
            foreach (Customer item in GetAllCustomersFromLocation(location))
            {
                Console.WriteLine(item);
            }
        }
        #endregion
    }
}
