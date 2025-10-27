using System;
using System.Collections.Generic;
using Domain.Model.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestDomain
{
    [TestClass]
    public sealed class IdCatTest
    {
        [TestMethod]
        public void IdCat_WithValidDate_CreatesValidId()
        {
            DateTime date = new DateTime(2023, 7, 13); var idCat = new IdCat(date); string value = idCat.Value;

            Assert.IsNotNull(value);
            Assert.AreEqual(9, value.Length);

            var months = new List<string> { "J", "F", "M", "A", "M", "J", "J", "A", "S", "O", "N", "D" };

            Assert.AreEqual(months[date.Month - 1], value[0].ToString());

            for (int i = 1; i < 4; i++)
            {
                Assert.IsTrue(Char.IsLetter(value[i]), $"Expected letter at position {i}");
            }

            for (int i = 4; i < 9; i++)
            {
                Assert.IsTrue(Char.IsDigit(value[i]), $"Expected digit at position {i}");
            }
        }

        [TestMethod]
        public void IdCat_DifferentDates_GenerateDifferentIds()
        {
            var id1 = new IdCat(new DateTime(2024, 1, 5)); var id2 = new IdCat(new DateTime(2024, 1, 5));
            Assert.AreNotEqual(id1.Value, id2.Value);

        }
    }
}