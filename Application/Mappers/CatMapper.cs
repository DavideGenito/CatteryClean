using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace Application.Mappers
{
    public static class CatMapper
    {
        public static Cat ToCat(this CatDto catDto)
        {
            if (catDto == null)
            {
                throw new ArgumentNullException(nameof(catDto), "CatDto cannot be null.");
            }
            else return new Cat(
                catDto.Name,
                catDto.Breed,
                catDto.IsMale,
                catDto.ArrivalDate,
                catDto.AdoptionDate,
                catDto.BirthDate,
                catDto.Description
            );
        }
        
        public static CatDto ToCatDto(this Cat cat)
        {
            if (cat == null)
            {
                throw new ArgumentNullException(nameof(cat), "Cat cannot be null.");
            }
            else return new CatDto(
                cat.Name,
                cat.Breed,
                cat.IsMale,
                cat.ArrivalDate,
                cat.AdoptionDate,
                cat.BirthDate,
                cat.Description,
                cat.Id
            );
        }
    }
}
