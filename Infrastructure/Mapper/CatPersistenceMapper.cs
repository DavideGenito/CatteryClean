using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Dto;
using Domain.Model.Entities;

namespace Infrastructure.Mapper
{
    internal static class CatPersistenceMapper
    {
        public static CatPersistenceDto ToCatPersistenceDto(this Cat cat)
        {
            return new Dto.CatPersistenceDto(
                name: cat.Name,
                breed: cat.Breed,
                isMale: cat.IsMale,
                arrivalDate: cat.ArrivalDate,
                adoptionDate: cat.AdoptionDate,
                birthDate: cat.BirthDate,
                description: cat.Description
                );
        }

        public static Cat ToPersistenceCat(this CatPersistenceDto catPersistenceDto)
        {
            if (catPersistenceDto == null)
            {
                throw new ArgumentNullException(nameof(catPersistenceDto), "CatPersistenceDto cannot be null.");
            }
            else return new Cat(
                catPersistenceDto.name,
                catPersistenceDto.breed,
                catPersistenceDto.isMale,
                catPersistenceDto.arrivalDate,
                catPersistenceDto.adoptionDate,
                catPersistenceDto.birthDate,
                catPersistenceDto.description
            );
        }
    }
}