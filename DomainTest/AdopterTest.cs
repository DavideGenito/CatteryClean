using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.ValueObjects;
using Domain.Model.Entities;

namespace TestDomain
{
    [TestClass]
    public sealed class AdopterTest
    {
        [TestMethod]
        public void AdopterConstructor_WithValidValue_CreatesObj()
        {
            Address address = new Address("Main St", "555", "Springfield", "62701");
            PhoneNumber phoneNumber = new PhoneNumber("+396543213345");
            Email email = new Email("supernovasasigma@gmail.com");
            TIN tin = new TIN("TSSNNA08R61D704Z");
            Adopter adopter = new Adopter("Anna", "Tassinari", email, phoneNumber, address, tin);

            Assert.AreEqual("Anna", adopter.Name);
            Assert.AreEqual("Tassinari", adopter.Surname);
            Assert.AreEqual(phoneNumber, adopter.PhoneNumber);
            Assert.AreEqual(address, adopter.Address);
            Assert.AreEqual(tin, adopter.TIN);
        }

        [TestMethod]
        public void AdopterToString_WithValidValue_ReturnsString()
        {
            Address address = new Address("Main St", "555", "Springfield", "62701");
            PhoneNumber phoneNumber = new PhoneNumber("+396543213345");
            Email email = new Email("supernovasasigma@gmail.com");
            TIN tin = new TIN("TSSNNA08R61D704Z");
            Adopter adopter = new Adopter("Anna", "Tassinari", email, phoneNumber, address, tin);

            string expectedString = "Adopter Details:\nName: Anna Tassinari\nPhone Number: +396543213345\nAddress: Main St 555, Springfield 62701\nTIN: TSSNNA08R61D704Z";
            Assert.AreEqual(expectedString, adopter.ToString());
        }
    }
}
