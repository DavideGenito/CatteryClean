using Application.Dto;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class AdoptionMapper
    {
        public static Adoption ToAdoption(this Adoption adoptionDto)
        {
            if (adoptionDto == null)
            {
                throw new ArgumentNullException(nameof(adoptionDto), "AdopterDto cannot be null.");
            }
            else return new Adoption(
                adoptionDto.Adopter,
                adoptionDto.Cat,
                adoptionDto.AdoptionDate
            );
        }

        public static AdoptionDto ToAdoptionDto(this Adoption adoption)
        {
            if (adoption == null)
            {
                throw new ArgumentNullException(nameof(adoption), "Adoption cannot be null.");
            }
            else return new AdoptionDto(
                adoption.Cat.ToCatDto(),
                adoption.Adopter.ToAdopterDto(),
                adoption.AdoptionDate
            );
        }
    }
}
