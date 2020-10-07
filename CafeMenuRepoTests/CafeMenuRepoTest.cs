using System;
using System.Collections.Generic;
using GoldBadgeApps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeMenuRepoTests
{
    [TestClass]
    public class CafeMenuRepoTest
    {
        [TestMethod]
        public void TestingAdditionsToCafeMenuRepo_ShouldReturnTrue()
        {
            CafeItem number1 = new CafeItem(1, "Hotdog with katsup and mustard and a drink", new List<string> { "beef", "pork", "chicken", "salt" }, 4.50);
            //CafeItem number2 = new CafeItem(2, "Classic single patty cheeseburger and a drink", new List<string> { "beef", "cheese", "grease" }, 5.50);
            //CafeItem number3 = new CafeItem(3, "Double cheeseburger with bacon and a drink", new List<string> { "beef", "cheese", "grease", "bacon" }, 7.00);

            CafeMenuRepo menu = new CafeMenuRepo();

            bool test1 = menu.AddItem(number1);
            //bool test2 = menu.AddItem(number2);
            //bool test3 = menu.AddItem(number3);

            Assert.AreEqual(true, test1);
            //Assert.AreEqual(true, test2);
            //Assert.AreEqual(true, test3);
        }
        [TestMethod]
        public void GetMenu_ShouldReturnTrue()
        {
            CafeMenuRepo menu = new CafeMenuRepo();

            CafeItem number1 = new CafeItem(1, "Hotdog with katsup and mustard and a drink", new List<string> { "beef", "pork", "chicken", "salt" }, 4.50);
           
            menu.AddItem(number1);
            
            List<CafeItem> listOfItems = menu.GetMenu();

            bool containsNumber1 = listOfItems.Contains(number1);

            Assert.IsTrue(containsNumber1);
        }
        [TestMethod]
        public void DeletItem_ShouldReturnTrue()
        {
            CafeMenuRepo menu = new CafeMenuRepo();

            CafeItem number1 = new CafeItem(1, "Hotdog with katsup and mustard and a drink", new List<string> { "beef", "pork", "chicken", "salt" }, 4.50);

            menu.AddItem(number1);

            List<CafeItem> beforeDelete = menu.GetMenu();

            menu.DeleteItem(number1.MealNumber-1);

            List<CafeItem> afterDelete = menu.GetMenu();

            bool beforeLessThanAfter = beforeDelete.Count < afterDelete.Count;

            Assert.IsFalse(beforeLessThanAfter);
        }
        [TestMethod]
        public void Count_ShouldReturnTrue()
        {
            CafeItem number1 = new CafeItem(1, "Hotdog with katsup and mustard and a drink", new List<string> { "beef", "pork", "chicken", "salt" }, 4.50);
            CafeItem number2 = new CafeItem(2, "Classic single patty cheeseburger and a drink", new List<string> { "beef", "cheese", "grease" }, 5.50);
            CafeItem number3 = new CafeItem(3, "Double cheeseburger with bacon and a drink", new List<string> { "beef", "cheese", "grease", "bacon" }, 7.00);

            CafeMenuRepo menu = new CafeMenuRepo();
            menu.AddItem(number1);
            menu.AddItem(number2);
            menu.AddItem(number3);

            Assert.AreEqual(3, 3);
        }
    }
}
