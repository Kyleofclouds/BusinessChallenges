using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BadgesConsoleApp
{
    public class BadgeRepo
    {
        private readonly Dictionary<double, List<string>> _badgeRepo = new Dictionary<double, List<string>>();
        public bool CreateBadge(Badge badge)
        {
            int count1 = _badgeRepo.Count;
            _badgeRepo.Add(badge.ID, badge.AccessibleDoors);
            int count2 = _badgeRepo.Count;
            bool wasCreated = count2 > count1;
            return wasCreated;
        }
        public Dictionary<double, List<string>> GetRepo()
        {
            return _badgeRepo;
        }
        public bool AddDoor(double badgeID, string door)
        {
            int count1 =_badgeRepo[badgeID].Count;
            _badgeRepo[badgeID].Add(door);
            int count2 = _badgeRepo[badgeID].Count;
            return (count2 > count1);
        }
        public bool UpdateRemove(double badgeID, string door)
        {
            int count1 = _badgeRepo[badgeID].Count;
            _badgeRepo[badgeID].Remove(door);
            int count2 = _badgeRepo[badgeID].Count;
            return (count1 > count2);
        }
    }
}
