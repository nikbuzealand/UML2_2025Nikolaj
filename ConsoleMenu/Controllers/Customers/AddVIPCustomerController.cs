using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace ConsoleMenu.Controllers.Customers
{
    public class AddVIPCustomerController
    {
        ICustomerRepository _customerRepository;
        public Customer Customer { get; set; }

        public AddVIPCustomerController(string name, string mobile, string address, bool clubMember, int discount, ICustomerRepository customerRepository)
        {
            Customer = new VIPCustomer(name, mobile, address, discount);
            Customer.ClubMember = clubMember;
            _customerRepository = customerRepository;
        }

        public void AddVIPCustomer()
        {
            _customerRepository.AddCustomer(Customer);
        }
    }
}
