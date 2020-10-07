using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeApps
{
    public class CafeMenuRepo
    {
        protected readonly List<CafeItem> _menu = new List<CafeItem>();
        public bool AddItem(CafeItem item)
        {
            int firstCount = _menu.Count;
            _menu.Add(item);
            bool wasAdded = (_menu.Count > firstCount) ? true : false;
            return wasAdded;
        }
        public List<CafeItem> GetMenu()
        {
            return _menu;
        }
        public bool DeleteItem(int num)
        {
            int firstCount = _menu.Count;
            _menu.RemoveAt(num);
            int secondCount = _menu.Count;
            foreach (CafeItem item in _menu)
            {
                item.MealNumber = _menu.IndexOf(item) + 1;
            }
            bool wasDeleted = (secondCount < firstCount) ? true : false;
            return wasDeleted;
        }
        public int Count()
        {
            return _menu.Count;
        }
    }
}
