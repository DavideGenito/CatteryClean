using System;
using Domain.Model.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestDomain
{
    [TestClass]
    public sealed class TinTest
    {
        [TestMethod]
        public void TIN_NumberIsShorter_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new TIN("1234567"));
        }

        [TestMethod]
        public void TIN_InvalidConsonants_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new TIN("AEIOUA12B45C67D"));
        }

        [TestMethod] public void TIN_InvalidFormat_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new TIN("ABCDEFGH12345678"));
        }


        [TestMethod]
        public void TIN_ValidTIN_DoesNotThrow()
        { 
            string validTIN = "BCDFGH12A34B567C";
            var tin = new TIN(validTIN);
            Assert.AreEqual(validTIN, tin.Value);
        }
    }
}