using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using Infrastructure.Dto;
using Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    internal static class AdoptionPersistenceMapper
    {
        public static Adoption ToAdoption(this AdoptionPersistenceDto adoptionDto)
        {
            if (adoptionDto == null)
            {
                throw new ArgumentNullException(nameof(adoptionDto), "AdopterDto cannot be null.");
            }
            else return new Adoption(
                adoptionDto.Adopter.ToAdopterPersistence(),
                adoptionDto.Cat.ToPersistenceCat(),
                adoptionDto.AdoptionDate
            );
        }

        public static AdoptionPersistenceDto ToAdoptionDto(this Adoption adoption)
        {
            if (adoption == null)
            {
                throw new ArgumentNullException(nameof(adoption), "Adoption cannot be null.");
            }
            else return new AdoptionPersistenceDto(
                adoption.Cat.ToCatPersistenceDto(),
                adoption.Adopter.ToAdopterPersistenceDto(),
                adoption.AdoptionDate
            );
        }
    }
}
