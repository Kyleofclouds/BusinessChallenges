using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClaimConsoleApp
{
    public class ClaimRepo
    {
        protected readonly List<Claim> _claimRepo = new List<Claim>();
        public bool AddClaim(Claim claim)
        {
            int firstCount = _claimRepo.Count;
            _claimRepo.Add(claim);
            int secondCount = _claimRepo.Count;
            return (secondCount > firstCount) ? true : false;
        }
        public List<Claim> GetClaims()
        {
            return _claimRepo;
        }
        public bool ProcessClaim()
        {
            int firstCount = _claimRepo.Count;
            _claimRepo.RemoveAt(0);
            int secondCount = _claimRepo.Count;
            return (firstCount < secondCount);
        }
        public int Count()
        {
            return _claimRepo.Count;
        }
    }
}
