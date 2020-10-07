using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimConsoleApp
{
    public class Claim
    {
        public enum ClaimType { Car, Home, Theft }
        public int ID { get; set; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime ClaimDate { get; set; }
        public bool isValid
        {
            get
            {
                double daysBetween = (ClaimDate - IncidentDate).TotalDays;
                return (daysBetween <= 30);
            }
        }
        public Claim() { }
        public Claim(int claimID, string type, string description, double amount, string incidentDate, string claimDate)
        {
            ID = claimID;
            Type = (ClaimType)Enum.Parse(typeof(ClaimType), type);
            Description = description;
            Amount = amount;
            IncidentDate = DateTime.Parse(incidentDate);
            ClaimDate = DateTime.Parse(claimDate);
        }
    }
}
