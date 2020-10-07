using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClaimConsoleApp
{
    class ClaimUI
    {
        private readonly ClaimRepo _claimRepo;
        public ClaimUI(ClaimRepo claimRepo)
        {
            _claimRepo = claimRepo;
        }
        public void Run()
        {
            SeedMenu();
            RunMenu();
        }
        private void RunMenu()
        {
            Console.WriteLine("Enter Name:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your (fake) password:");
            Console.ReadLine();

            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("How would you like to proceed?\n" +
                    "1) See all claims \n" +
                    "2) Take care of next claim \n" +
                    "3) Enter a new claim \n" +
                    "4) Log out");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        ShowClaims();
                        break;
                    case 2:
                        Console.Clear();
                        ProcessClaim();
                        break;
                    case 3:
                        Console.Clear();
                        AddClaim();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"{username} has logged out. Have a nice day.");
                        Thread.Sleep(2000);
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void ShowClaims()
        {
            List<Claim> claims = _claimRepo.GetClaims();
            Console.WriteLine("{0,-8}{1,-6}{2,-25}{3,-12}{4,-18}{5,-18}{6,-10}\n","ClaimID","Type","Description","Amount","Date of Accident","Date of Claim","IsValid");
            //Console.WriteLine("ClaimID        Type        Desctiption        Amount       DateOfAccident           DateOfClaim          IsValid");
            foreach (var x in claims)
            {
                Console.WriteLine("{0,-8}{1,-6}{2,-25}{3,-12}{4,-18}{5,-18}{6,-10}", $"{x.ID}",$"{ x.Type}",$"{ x.Description}",$"{ x.Amount:C2}",$"{ x.IncidentDate:d}",$"{ x.ClaimDate:d}",$"{ x.isValid}");
                //Console.WriteLine($"      {x.ID}        {x.Type}       {x.Description}      {x.Amount:C2}   {x.IncidentDate:d}     {x.ClaimDate:d}       {x.isValid}");
            }
            Console.WriteLine("\n");
        }
        private void AddClaim()
        {
            Console.WriteLine("Enter the claim ID:");
            int claimID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What type of claim is it: Car Home or Theft?");
            string type = Console.ReadLine();
            Console.WriteLine("Enter a brief description of the claim");
            string desc = Console.ReadLine();
            Console.WriteLine("How much is the insured claiming?");
            double amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the date of the incident in the following format: mm/dd/yyyy");
            string dateStringI = Console.ReadLine();
            Console.WriteLine("Enter the date of the claim in the following format: mm/dd/yyyy");
            string dateStringC = Console.ReadLine();
            Claim claim = new Claim(claimID, type, desc, amount, dateStringI, dateStringC);
            _claimRepo.AddClaim(claim);
            Console.WriteLine("The claim was added to the queue");
            Thread.Sleep(2000);
            Console.Clear();
        }
        private void ProcessClaim()
        {
            Console.WriteLine("Here are the details for the next claim to be handled:");
            List<Claim> claims = _claimRepo.GetClaims();
            int claimID = claims[0].ID;
            Console.WriteLine($"Claim ID {claimID}");
            //string type = claim.Type.ToString();
            Console.WriteLine($"Type: {claims[0].Type.ToString()}");
            Console.WriteLine($"Description: {claims[0].Description}");
            Console.WriteLine($"Amount: {claims[0].Amount}");
            Console.WriteLine($"Date of Accident: {claims[0].IncidentDate:d}");
            Console.WriteLine($"Date of claim: {claims[0].ClaimDate:d}");
            Console.WriteLine($"IsValid: {claims[0].isValid}");
            Console.WriteLine("Would you like to process the claim now(y/n)?");
            string input = Console.ReadLine();
            while (input != "y" && input != "n")
            {
                Console.WriteLine("Please inter a valid response. Would you like to process the claim now(y/n)?");
                input = Console.ReadLine().ToLower();
            }
            if (input == "y")
            {
                _claimRepo.ProcessClaim();
                Console.WriteLine($"Claim ID {claimID} has been processed.");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                Console.Clear();
            }
        }
        private void SeedMenu()
        {
            Claim claim1 = new Claim(1, "Car", "Car accident on 465", 400, "04/25/2018", "04/27/2018");
            Claim claim2 = new Claim(2, "Home", "House fire in kitchen", 4000, "04/11/2018", "04/12/2018");
            Claim claim3 = new Claim(3, "Theft", "Stolen Pancakes", 4, "04/27/2018", "06/01/2018");

            _claimRepo.AddClaim(claim1);
            _claimRepo.AddClaim(claim2);
            _claimRepo.AddClaim(claim3);
        }
    }
}
