using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using System;

namespace Tests.Mappers
{
    [TestClass]
    public class AdoptionMapperTests
    {
        [TestMethod]
        public void ToAdoption_ShouldMapCorrectly()
        {
            var adopterDto = new AdopterDto(
                "Mario", "Rossi",
                new PhoneNumber("+399876543217"),
                new Email("mario@example.com"),
                new Address("Via Roma", "1", "Milano", "Italia"),
                new TIN("RSSMRA80A01F205X")
            );

            var catDto = new CatDto(
                "Micio", "Siamese", true,
                DateTime.Now.AddDays(-10),
                null, null, "Dolce", new IdCat(DateTime.Now.AddDays(-10))
            );

            var adoptionDto = new AdoptionDto(catDto, adopterDto, DateTime.Today);
            var adoption = adoptionDto.ToAdoption();

            Assert.AreEqual(adoptionDto.Adopter.Name, adoption.Adopter.Name);
            Assert.AreEqual(adoptionDto.Cat.Name, adoption.Cat.Name);
        }

        [TestMethod]
        public void ToAdoption_ShouldThrow_WhenDtoIsNull()
        {
            AdoptionDto dto = null!;
            Assert.ThrowsException<ArgumentNullException>(() => dto.ToAdoption());
        }

        [TestMethod]
        public void ToAdoptionDto_ShouldMapCorrectly()
        {
            var cat = new Cat("Luna", "Siberiano", false, DateTime.Now.AddDays(-1), null, null, null);
            var adopter = new Adopter("Anna", "Bianchi", new Email("anna@example.com"),
                new PhoneNumber("+399876543217"), new Address("Via Verdi", "2", "Roma", "Italia"), new TIN("BNCHNA80B02F205Z"));
            var adoption = new Adoption(adopter, cat, DateTime.Today);

            var dto = adoption.ToAdoptionDto();

            Assert.AreEqual(adoption.Cat.Name, dto.Cat.Name);
            Assert.AreEqual(adoption.Adopter.Name, dto.Adopter.Name);
        }

        [TestMethod]
        public void ToAdoptionDto_ShouldThrow_WhenEntityIsNull()
        {
            Adoption adoption = null!;
            Assert.ThrowsException<ArgumentNullException>(() => adoption.ToAdoptionDto());
        }
    }
}
