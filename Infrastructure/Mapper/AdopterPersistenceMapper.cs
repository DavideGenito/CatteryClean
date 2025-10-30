using Application.Dto;
using Domain.Model.Entities;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    internal static class AdopterPersistenceMapper
    {
        public static Adopter ToAdopterPersistence(this AdopterPersistenceDto adopterDto)
        {
            if (adopterDto == null)
            {
                throw new ArgumentNullException(nameof(adopterDto), "AdopterDto cannot be null.");
            }
            else return new Adopter(
                adopterDto.Name,
                adopterDto.Surname,
                adopterDto.Email,
                adopterDto.PhoneNumber,
                adopterDto.Address,
                adopterDto.TIN
            );
        }

        public static AdopterPersistenceDto ToAdopterPersistenceDto(this Adopter adopter)
        {
            if (adopter == null)
            {
                throw new ArgumentNullException(nameof(adopter), "Adopter cannot be null.");
            }
            else return new AdopterPersistenceDto(
                adopter.Name,
                adopter.Surname,
                adopter.PhoneNumber,
                adopter.Email,
                adopter.Address,
                adopter.TIN
            );
        }
    }
}
