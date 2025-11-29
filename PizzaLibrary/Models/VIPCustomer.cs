using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Exceptions;

namespace PizzaLibrary.Models
{
    public class VIPCustomer:Customer
    {
        #region Instance field
        private int _discount;
        #endregion

        #region Properties
        public int Discount {
            get { return _discount; }
            set { if (value < 1 || value > 25)
                {
                    throw new InvalidDiscountException("Attempted to give a VIPCustomer an illegal discount value.");
                }
                else
                {
                    _discount = value;
                }
            }
        }
        #endregion

        #region Constructor
        public VIPCustomer(string name, string mobile, string address, int discount)
            :base(name, mobile, address)
        {
            if (discount < 1 || discount > 25)
            {
                throw new InvalidDiscountException("Attempted to create a VIPCustomer with an illegal discount argument.");
            }
            Discount = discount;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return (base.ToString() + $". VIP Discount: {Discount}");
        }
        #endregion
    }
}
