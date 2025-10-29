using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using System;

namespace Tests.Mappers
{
    [TestClass]
    public class CatMapperTests
    {
        [TestMethod]
        public void ToCat_ShouldMapCorrectly()
        {
            var dto = new CatDto(
                "Micio", "Siamese", true,
                DateTime.Now.AddDays(-10),
                null, null, "Dolce gatto", new IdCat(DateTime.Now.AddDays(-10))
            );

            var cat = dto.ToCat();

            Assert.AreEqual(dto.Name, cat.Name);
            Assert.AreEqual(dto.Breed, cat.Breed);
        }

        [TestMethod]
        public void ToCat_ShouldThrow_WhenDtoIsNull()
        {
            CatDto dto = null!;
            Assert.ThrowsException<ArgumentNullException>(() => dto.ToCat());
        }

        [TestMethod]
        public void ToCatDto_ShouldMapCorrectly()
        {
            var cat = new Cat(
                "Luna", "Persiano", false,
                DateTime.Now.AddMonths(-1),
                null, DateTime.Now.AddYears(-2), "Tranquilla"
            );

            var dto = cat.ToCatDto();

            Assert.AreEqual(cat.Name, dto.Name);
            Assert.AreEqual(cat.Breed, dto.Breed);
        }

        [TestMethod]
        public void ToCatDto_ShouldThrow_WhenEntityIsNull()
        {
            Cat cat = null!;
            Assert.ThrowsException<ArgumentNullException>(() => cat.ToCatDto());
        }
    }
}
