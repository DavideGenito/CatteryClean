using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    internal record AdoptionPersistenceDto(
        CatPersistenceDto Cat,
        AdopterPersistenceDto Adopter,
        DateTime AdoptionDate
        );
}
