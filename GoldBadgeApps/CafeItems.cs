using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeApps
{
    public class CafeItem
    {
        public int MealNumber{ get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public double Price { get; set; }
        public CafeItem(int mealNumber, string description, List<string> ingredients, double price)
        {
            MealNumber = mealNumber;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
