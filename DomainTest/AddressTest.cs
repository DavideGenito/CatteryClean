using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomain
{
    [TestClass]
    public sealed class AddressTest
    {
        [TestMethod]
        public void Address_StreetIsEmpty_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Address("","555", "Forlì", "27381"));
        }

        [TestMethod]
        public void Address_CityIsEmpty_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Address("idk Street","555", "", "27381"));
        }

        [TestMethod]
        public void Address_PostalCodeIsEmpty_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Address("idk Street","555","Forlì", " "));
        }

        [TestMethod]
        public void Address_WithValidValues_CreatesAddress()
        {
            var address = new Address("idk Street","555", "Forlì", "27381");
            Assert.AreEqual("idk Street", address.Street);
            Assert.AreEqual("Forlì", address.City);
            Assert.AreEqual("555", address.CivicNumber);
            Assert.AreEqual("27381", address.PostalCode);
        }
    }
}
