using Domain.Model.ValueObjects;
using Domain.Model.Entities;

namespace TestDomain
{
    [TestClass]
    public sealed class EmailTest
    {
        [TestMethod]
        public void EmailConstructor_DoesntContainPeriod_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Email("example@domaincom"));
        }

        [TestMethod]
        public void EmailConstructor_DoesntContainAtSign_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Email("exampledomain.com"));
        }

        [TestMethod]
        public void EmailConstructor_WithValidValues_CreatesEmail()
        {
            Email email = new Email("example@domain.com");
            Assert.IsNotNull(email);
        }
    }
}
