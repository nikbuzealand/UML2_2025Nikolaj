using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Services;

namespace PizzaLibrary.Models
{
    public class Customer:ICustomer
    {
        #region Instance field
        private static int _counter = 0;

        private int _id;
        #endregion

        #region Properties
        public string Address { get; set; }

        public bool ClubMember { get; set; }

        public int Id { get { return _id; } }

        public string Mobile { get; set; }

        public string Name { get; set; }
        #endregion

        #region Constructor
        public Customer(string name, string mobile, string address)
        {
            _id = _counter++;
            Name = name;
            Mobile = mobile;
            Address = address;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Id} {Name} {Mobile} {Address} {ClubMember}";
        }
        #endregion
    }
}
