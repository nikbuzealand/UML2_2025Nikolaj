using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class CompanyInfo
    { // Vat, Cvr, Name, ClubDiscount
        #region Instance field
        private static CompanyInfo _instance = null;
        #endregion

        #region Properties
        public int Vat { get; set; }

        public string Cvr { get; set; }

        public string Name { get; set; }

        public bool ClubDiscount { get; set; }

        public static CompanyInfo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CompanyInfo();
                }
                return _instance;
            }
        }
        #endregion

        #region Constructor
        private CompanyInfo()
        {
            
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return ($"{Name} {Vat} {Cvr} {ClubDiscount}");
        }
        #endregion
    }
}
