using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;

namespace TestDomain
{
    [TestClass]
    public sealed class CatTest
    {
        [TestMethod]
        public void CatConstructor_WithValidValue_CreatesObj()
        {
            Cat cat = new Cat("Kiwi", "Maine coon", true, new DateTime(2009, 07, 13, 6, 8, 5), null, new DateTime(2009, 07, 13, 6, 8, 5), null );

            Assert.AreEqual("Kiwi", cat.Name);
            Assert.AreEqual("Maine coon", cat.Breed);
            Assert.AreEqual(true, cat.IsMale);
            Assert.AreEqual(new DateTime(2009, 07, 13, 6, 8, 5), cat.ArrivalDate);
            Assert.AreEqual(null, cat.AdoptionDate);
            Assert.AreEqual(new DateTime(2009, 07, 13, 6, 8, 5), cat.BirthDate);
            Assert.AreEqual(null, cat.Description);
        }
    }
}
