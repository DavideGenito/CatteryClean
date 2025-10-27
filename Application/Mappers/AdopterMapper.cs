using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Application.Dto;

namespace Application.Mappers
{
    public static class AdopterMapper
    {
        public static Adopter ToAdopter(this AdopterDto adopterDto)
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

        public static AdopterDto ToAdopterDto(this Adopter adopter)
        {
            if (adopter == null)
            {
                throw new ArgumentNullException(nameof(adopter), "Adopter cannot be null.");
            }
            else return new AdopterDto(
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
