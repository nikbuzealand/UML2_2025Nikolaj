using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Interfaces;

namespace PizzaLibrary.Models
{
    public class MenuItem : IMenuItem
    {
        #region Instance field
        private static int _counter = 0;

        private int _no;
        #endregion

        #region Properties
        public string Description { get; set; }

        public string Name { get; set; }

        public int No { get { return _no; } }

        public double Price { get; set; }

        public MenuType TheMenuType { get; set; }
        #endregion

        #region Constructor
        public MenuItem(string name, double price, string description, MenuType menuType)
        {
            _no = _counter++;
            Name = name;
            Price = price;
            Description = description;
            TheMenuType = menuType;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{No} {Name} {Price} {Description} {TheMenuType}";
        }
        #endregion
    }
}
