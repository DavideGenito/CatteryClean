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
    public sealed class AdoptionTest
    {
        [TestMethod]
        public void AdoptionConstructor_WithValidValue_CreatesObj()
        {
            Cat cat = new Cat("Kiwi", "Maine coon", true, new DateTime(2009, 07, 13, 6, 8, 5), null, new DateTime(2009, 07, 13, 6, 8, 5), null);

            Assert.AreEqual("Kiwi", cat.Name);
            Assert.AreEqual("Maine coon", cat.Breed);
            Assert.AreEqual(true, cat.IsMale);
            Assert.AreEqual(new DateTime(2009, 07, 13, 6, 8, 5), cat.ArrivalDate);
            Assert.AreEqual(null, cat.AdoptionDate);
            Assert.AreEqual(new DateTime(2009, 07, 13, 6, 8, 5), cat.BirthDate);
            Assert.AreEqual(null, cat.Description);
        }

        [TestMethod]
        public void DeleteAdoption_WithValidValue_DeletesAdoption()
        {
            Cat cat = new Cat("Kiwi", "Maine coon", true, new DateTime(2009, 07, 13, 6, 8, 5), null, new DateTime(2009, 07, 13, 6, 8, 5), null);
            Address address = new Address("Main St","555", "Springfield", "62701");
            PhoneNumber phoneNumber = new PhoneNumber("+396543213345");
            Email email = new Email("supernovasasigma@gmail.com");
            TIN tin = new TIN("TSSNNA08R61D704Z");
            Adopter adopter = new Adopter("Anna", "Tassinari", email, phoneNumber, address, tin);
            Adoption adoption = new Adoption(adopter, cat, new DateTime(2020, 05, 20));

            adoption.DeleteAdoption();
            Assert.AreEqual(null, cat.AdoptionDate);
        }

        [TestMethod]
        public void AdoptionConstructor_WithValidValue_AdoptionDateIsNotNull()
        {
            Cat cat = new Cat("Kiwi", "Maine coon", true, new DateTime(2009, 07, 13, 6, 8, 5), null, new DateTime(2009, 07, 13, 6, 8, 5), null);
            Address address = new Address("Main St", "555", "Springfield", "62701");
            PhoneNumber phoneNumber = new PhoneNumber("+396543213345");
            Email email = new Email("supernovasasigma@gmail.com");
            TIN tin = new TIN("TSSNNA08R61D704Z");
            Adopter adopter = new Adopter("Anna", "Tassinari", email, phoneNumber, address, tin);
            Adoption adoption = new Adoption(adopter, cat, new DateTime(2020, 05, 20));

            Assert.AreEqual(new DateTime(2020, 05, 20), adoption.AdoptionDate);
        }

        [TestMethod]
        public void AdoptionToString_WithValidValue_ReturnsString()
        {

            Cat cat = new Cat("Kiwi", "Maine coon", true, new DateTime(2009, 07, 13, 6, 8, 5), null, new DateTime(2009, 07, 13, 6, 8, 5), null);
            Address address = new Address("Main St", "555","Springfield", "62701");
            PhoneNumber phoneNumber = new PhoneNumber("+396543213345");
            Email email = new Email("supernovasasigma@gmail.com");
            TIN tin = new TIN("TSSNNA08R61D704Z");
            Adopter adopter = new Adopter("Anna", "Tassinari", email, phoneNumber, address, tin);
            Adoption adoption = new Adoption(adopter, cat, new DateTime(2020, 05, 20));

            string expectedString = "Adoption Details:\nAdopter: Anna Tassinari\nCat: Kiwi\nAdoption Date: 5/20/2020";
            Assert.AreEqual(expectedString, adoption.ToString());
        }
    }
}
