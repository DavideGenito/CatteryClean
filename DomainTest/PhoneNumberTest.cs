using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomain
{
    [TestClass]
    public sealed class PhoneNumberTest
    {
        [TestMethod]
        public void PhoneNumber_NumberIsShorter_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new PhoneNumber("+39218272"));
        }

        [TestMethod]
        public void PhoneNumber_NumberDoesntContainCountryCode_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new PhoneNumber("3453216654"));
        }

        [TestMethod]
        public void PhoneNumber_NumberContainsLetters_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new PhoneNumber("+39fgh439se34"));
        }

        [TestMethod]
        public void PhoneNumber_WithValidValues_CreatesPhoneNumber()
        {
            PhoneNumber phoneNumber = new PhoneNumber("+393453216654");
            Assert.IsNotNull(phoneNumber);
        }
    }
}
