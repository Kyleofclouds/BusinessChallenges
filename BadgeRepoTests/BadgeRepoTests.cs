using System;
using System.Collections.Generic;
using System.Linq;
using BadgesConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeRepoTests
{
    [TestClass]
    public class BadgeRepoTests
    {
        [TestMethod]
        public void CreateBadge_ShouldReturnTrue()
        {
            BadgeRepo _badgeRepo = new BadgeRepo();
            Badge badge1 = new Badge(12345, new List<string> { "A1", "B2", "C3", "D4" });
            //Badge badge2 = new Badge(22345, new List<string> { "A4", "A5" });

            bool wasCreated =_badgeRepo.CreateBadge(badge1);
            //_badgeRepo.CreateBadge(badge2);

            Assert.IsTrue(wasCreated);

            /*Dictionary<double, List<string>> repo = _badgeRepo.GetRepo();

            foreach (KeyValuePair<double, List<string>> badge in repo)
            {
                string doors = string.Join(", ", badge.Value);
                Console.WriteLine($"Badge # {badge.Key} has access to doors {doors}");
            }*/
        }
        [TestMethod]
        public void GetRepo_ShouldReturnTrue()
        {
            BadgeRepo _badgeRepo = new BadgeRepo();
            Badge badge1 = new Badge(12345, new List<string> { "A1", "B2", "C3", "D4" });
            //Badge badge2 = new Badge(22345, new List<string> { "A4", "A5" });

            _badgeRepo.CreateBadge(badge1);
            //_badgeRepo.CreateBadge(badge2);
            Dictionary<double, List<string>> repo = _badgeRepo.GetRepo();
            bool containsBadge = repo.ContainsKey(badge1.ID);

            Assert.IsTrue(containsBadge);
            //help Is this right?
        }
        [TestMethod]
        public void AddDoor_ShouldReturnTrue()
        {
            BadgeRepo _badgeRepo = new BadgeRepo();
            Badge badge1 = new Badge(12345, new List<string> { "A1", "B2", "C3", "D4" });
            _badgeRepo.CreateBadge(badge1);

            bool wasAdded =_badgeRepo.AddDoor(12345, "E5");

            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void UpdateRemove_ShouldReturnTrue()
        {
            BadgeRepo _badgeRepo = new BadgeRepo();
            Badge badge1 = new Badge(12345, new List<string> { "A1", "B2", "C3", "D4" });
            _badgeRepo.CreateBadge(badge1);

            bool wasRemoved = _badgeRepo.UpdateRemove(12345, "D4");

            Assert.IsTrue(wasRemoved);
        }
    }
}
