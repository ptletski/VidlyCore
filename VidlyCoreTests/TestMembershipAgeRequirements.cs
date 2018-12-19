using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VidlyCoreApp.Models;
using VidlyCoreApp.BusinessRules;

namespace VidlyCoreTests
{
    [TestClass]
    public class TestMembershipAgeRequirements
    {
        [TestMethod]
        public void NotRequired()
        {
            int membershipType = MembershipType.PayAsYouGo;
            MembershipAgeRequirements requirements = new MembershipAgeRequirements();
            BusinessRulesResult result = requirements.IsCustomerAgeAcceptable(membershipType, null);
           
            Assert.IsFalse(result.IsErrored);

            DateTime customerBirthDate = new DateTime(2018, 8, 28);
            result = requirements.IsCustomerAgeAcceptable(membershipType, customerBirthDate);

            Assert.IsFalse(result.IsErrored);

            customerBirthDate = new DateTime(1960, 8, 28);
            result = requirements.IsCustomerAgeAcceptable(membershipType, customerBirthDate);

            Assert.IsFalse(result.IsErrored);
        }

        [TestMethod]
        public void RequiredButAcceptableAge()
        {
            int membershipType = MembershipType.PayAsYouGo;
            DateTime customerBirthDate = new DateTime(1960, 8, 28);
            MembershipAgeRequirements requirements = new MembershipAgeRequirements();
            BusinessRulesResult result = requirements.IsCustomerAgeAcceptable(membershipType, customerBirthDate);

            Assert.IsFalse(result.IsErrored);

            membershipType = MembershipType.Monthly;
            result = requirements.IsCustomerAgeAcceptable(membershipType, customerBirthDate);

            Assert.IsFalse(result.IsErrored);

            membershipType = MembershipType.Quarterly;
            result = requirements.IsCustomerAgeAcceptable(membershipType, customerBirthDate);

            Assert.IsFalse(result.IsErrored);

            membershipType = MembershipType.Yearly;
            result = requirements.IsCustomerAgeAcceptable(membershipType, customerBirthDate);

            Assert.IsFalse(result.IsErrored);
        }

        [TestMethod]
        public void RequiredAndUnacceptableAge()
        {
            int membershipType = MembershipType.Monthly;
            DateTime customerBirthDate = new DateTime(2018, 8, 28);
            MembershipAgeRequirements requirements = new MembershipAgeRequirements();
            BusinessRulesResult result = requirements.IsCustomerAgeAcceptable(membershipType, customerBirthDate);

            Assert.IsTrue(result.IsErrored);

            membershipType = MembershipType.Quarterly;
            result = requirements.IsCustomerAgeAcceptable(membershipType, customerBirthDate);

            Assert.IsTrue(result.IsErrored);

            membershipType = MembershipType.Yearly;
            result = requirements.IsCustomerAgeAcceptable(membershipType, customerBirthDate);

            Assert.IsTrue(result.IsErrored);
        }
    }
}
