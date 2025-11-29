using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace PizzaLibrary.Services
{
    public class MenuItemRepository : IMenuItemRepository
    {
        #region Instance field
        private List<MenuItem> _menuItemList;
        #endregion

        #region Properties
        public int Count { get { return GetAll().Count; } }
        #endregion

        #region Constructor
        public MenuItemRepository()
        {
            _menuItemList = MockData.MenuItemData;
        }
        #endregion

        #region Methods
        public void AddMenuItem(MenuItem menuItem)
        {
            _menuItemList.Add(menuItem);
        }

        public List<MenuItem> GetAll()
        {
            return _menuItemList;
        }

        public MenuItem? GetMenuItemByNo(int no)
        {
            foreach (MenuItem item in GetAll())
            {
                if (item.No == no)
                {
                    return item;
                }
            }
            return null;
        }

        public void PrintAllMenuItems()
        {
            foreach (var item in GetAll())
            {
                Console.WriteLine(item);
            }
        }

        public void RemoveMenuItem(int no)
        {
            //Optimal solution, calling GetMenuItemByNo
            if (GetMenuItemByNo(no) != null)
            {
                GetAll().Remove(GetMenuItemByNo(no));
            }
            else
            {
                return;
            }

            //Foreach solution, manual search
            //foreach (var item in GetAll())
            //{
            //    if (item.No == no)
            //    {
            //        GetAll().Remove(item);
            //        return;
            //    }
            //}

            //For solution, manual search
            //for (int i = 0; i < Count; i++)
            //{
            //    if (GetAll()[i].No == no)
            //    {
            //        GetAll().RemoveAt(i);
            //    }
            //}
        }

        public List<MenuItem> GetMenuType(MenuType type)
        {
            List<MenuItem> menuList = new List<MenuItem>();
            foreach (MenuItem mit in GetAll())
            {
                if (mit.TheMenuType == type)
                {
                    menuList.Add(mit);
                }
            }
            return menuList;
        }

        public void PrintMenuType(MenuType type)
        {
            foreach (MenuItem item in GetMenuType(type))
            {
                Console.WriteLine(item);
            }
        }

        public MenuItem? GetMostExpensiveItemOfType(MenuType type)
        {
            List<MenuItem> possibleList = GetMenuType(type);
            if(possibleList != null && possibleList.Count > 0)
            {
                MenuItem mostExpensive = possibleList[0];
                foreach (var item in possibleList)
                {
                    if (item.Price > mostExpensive.Price)
                    {
                        mostExpensive = item;
                    }
                }
                return mostExpensive;
            }
            else
            {
                return null;
            }
        }

        public MenuItem? GetMostExpensivePizza()
        {
            MenuItem mostExpensive = null;
            foreach (MenuItem mi in GetAll())
            {
                if (mi.TheMenuType == MenuType.PIZZECLASSSICHE || mi.TheMenuType == MenuType.PIZZESPECIALI)
                {
                    if (mostExpensive == null || mi.Price > mostExpensive.Price)
                    {
                        mostExpensive = mi;
                    }
                }
            }
            return mostExpensive;
        }

        public void PrintMenu()
        {
            foreach (MenuType mt in Enum.GetValues(typeof(MenuType)))
            {
                Console.WriteLine($"- {mt} -y-");
                List<MenuItem> items = GetMenuType(mt);
                if (items.Count == 0)
                {
                    Console.WriteLine("  (no items)");
                    continue;
                }

                foreach (var item in items)
                {
                    Console.WriteLine($"  {item.No}: {item.Name} - {item.Price:C} - {item.Description}");
                }
            }
        }
        #endregion
    }
}
