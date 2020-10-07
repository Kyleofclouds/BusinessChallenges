using System;
using System.Collections.Generic;
using ClaimConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsAppTests
{
    [TestClass]
    public class ClaimRepoTests
    {
        [TestMethod]
        public void AddClaim_ShouldReturnTrue()
        {
            ClaimRepo repo = new ClaimRepo();
            Claim claim = new Claim(1, "Home", "Tree Damaged to Kitchen", 7500, "10/10/2020", "10/20/2020");

            bool wasAdded = repo.AddClaim(claim);

            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void MyTestMethod()
        {
            ClaimRepo repo = new ClaimRepo();
            Claim claim = new Claim(1, "Home", "Tree Damaged to Kitchen", 7500, "10/10/2020", "10/20/2020");

            repo.AddClaim(claim);
            List<Claim> claimRepo = repo.GetClaims();

            Assert.IsTrue(claimRepo.Contains(claim));
        }
        [TestMethod]
        public void Count_ShouldReturnTrue()
        {
            ClaimRepo repo = new ClaimRepo();
            Claim claim = new Claim(1, "Home", "Tree Damaged to Kitchen", 7500, "10/10/2020", "10/20/2020");
            bool isGreaterThan;

            int count1 = repo.Count();
            repo.AddClaim(claim);
            int count2 = repo.Count();
            isGreaterThan = count1 < count2;

            Assert.IsTrue(isGreaterThan);
        }
    }
}
