using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Interfaces;

namespace PizzaLibrary.Models
{
    public class Beverage:MenuItem
    {
        #region Properties
        public bool Alcohol { get; set; }
        #endregion

        #region Constructor
        public Beverage(string name, double price, string description, bool alcoholic)
            :base(name, price, description, MenuType.TILBEHØR)
        {
            Alcohol = alcoholic;
        }
        #endregion

        #region Methods

        public override string ToString()
        {
            return (base.ToString() + $" {Alcohol}");
        }
        #endregion
    }
}
