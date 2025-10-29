using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using System;

namespace Tests.Mappers
{
    [TestClass]
    public class AdopterMapperTests
    {
        [TestMethod]
        public void ToAdopter_ShouldMapCorrectly()
        {
            var dto = new AdopterDto(
                "Mario", "Rossi",
                new PhoneNumber("+391234567890"),
                new Email("mario@example.com"),
                new Address("Via Roma", "1", "Milano", "Italia"),
                new TIN("RSSMRA80A01F205X")
            );

            var entity = dto.ToAdopter();

            Assert.AreEqual(dto.Name, entity.Name);
            Assert.AreEqual(dto.Surname, entity.Surname);
            Assert.AreEqual(dto.Email, entity.Email);
        }

        [TestMethod]
        public void ToAdopter_ShouldThrow_WhenDtoIsNull()
        {
            AdopterDto dto = null!;
            Assert.ThrowsException<ArgumentNullException>(() => dto.ToAdopter());
        }

        [TestMethod]
        public void ToAdopterDto_ShouldMapCorrectly()
        {
            var adopter = new Adopter(
                "Anna", "Bianchi",
                new Email("anna@example.com"),
                new PhoneNumber("+399876543217"),
                new Address("Via Verdi", "2", "Roma", "Italia"),
                new TIN("BNCHNA80B02F205Z")
            );

            var dto = adopter.ToAdopterDto();

            Assert.AreEqual(adopter.Name, dto.Name);
            Assert.AreEqual(adopter.Email, dto.Email);
        }

        [TestMethod]
        public void ToAdopterDto_ShouldThrow_WhenEntityIsNull()
        {
            Adopter adopter = null!;
            Assert.ThrowsException<ArgumentNullException>(() => adopter.ToAdopterDto());

        }
    }
}
