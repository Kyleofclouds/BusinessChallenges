using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BadgesConsoleApp
{
    class BadgeUI
    {
        private readonly BadgeRepo _badgeRepo;
        public BadgeUI(BadgeRepo badgeRepo)
        {
            _badgeRepo = badgeRepo;
        }
        public void Run()
        {
            SeedMenu();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            Console.WriteLine("Hello, Security Admin. What would you like to do?");
            while (continueToRun)
            {
                Console.WriteLine("How would you like to proceed? \n" +
                    "1) Add A Badge\n" +
                    "2) Edit A Badge\n" +
                    "3) List All Badges\n" +
                    "4) Log out");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddBadge();
                        break;
                    case 2:
                        EditBadge();
                        break;
                    case 3:
                        ListAllBadges();
                        break;
                    case 4:
                        Console.WriteLine("You have logged out");
                        Thread.Sleep(1250);
                        continueToRun = false;
                        break;
                }
            }
        }
        public void AddBadge()
        {
            Console.Write("What is the number of the badge? ");
            double badgeID = Convert.ToDouble(Console.ReadLine());
            List<string> doors = new List<string>();
            string response = "y";
            string door;
            while (response == "y")
            {
                Console.Write($"List a door that badge {badgeID} needs access to: ");
                door = Console.ReadLine();
                doors.Add(door);
                Console.Write("Any other doors (y/n) ? ");
                response = Console.ReadLine().ToLower();
            }
            Badge badge = new Badge(badgeID, doors);
            _badgeRepo.CreateBadge(badge);
            foreach (KeyValuePair<double, List<string>> badger in _badgeRepo.GetRepo())
            {
                string newDoors = string.Join(", ", badger.Value);
                Console.WriteLine($"Badge # {badger.Key} hass access to doors {newDoors}.");
            }
            Thread.Sleep(2500);
            Console.Clear();
        }
        public void EditBadge()
        {
            Console.Write("What is the badge number to edit? ");
            double badgeID = Convert.ToDouble(Console.ReadLine());
            string doors = string.Join(", ", _badgeRepo.GetRepo()[badgeID]);
            Console.Clear();
            Console.WriteLine($"Badge ID {badgeID} has access to the following doors: {doors}");
            Console.WriteLine("What would you like to do?\n"+
                "1) Remove a door\n"+
                "2) Add a door\n");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Which door would you like to remove? ");
                    string doorToRemove = Console.ReadLine();
                    _badgeRepo.UpdateRemove(badgeID, doorToRemove);
                    Console.WriteLine("Door Removed");
                    string doorAfter = string.Join(", ", _badgeRepo.GetRepo()[badgeID]);
                    Console.WriteLine($"Badge ID {badgeID} has access to the following doors: {doorAfter}");
                    break;
                case 2:
                    Console.WriteLine("What door would you like to add?");
                    string doorToAdd = Console.ReadLine();
                    _badgeRepo.AddDoor(badgeID, doorToAdd);
                    Console.WriteLine("Door Added");
                    string newDoors = string.Join(", ", _badgeRepo.GetRepo()[badgeID]);
                    Console.WriteLine($"Badge ID {badgeID} has access to the following doors: {newDoors}");
                    break;
                default:
                    break;
            }
        }
        public void ListAllBadges()
        {
            Console.Clear();
            Console.WriteLine("Key\n");
            Console.WriteLine("Badge     Door Access");
            foreach (KeyValuePair<double, List<string>> badge in _badgeRepo.GetRepo())
            {
                string doors = string.Join(", ", badge.Value);
                Console.WriteLine($"{badge.Key}     {doors}");
            }
        }
        public void SeedMenu()
        {
            Badge badge1 = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badge badge2 = new Badge(32345, new List<string> { "A4", "A5" });

            _badgeRepo.CreateBadge(badge1);
            _badgeRepo.CreateBadge(badge2);
        }
    }
}
