using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.ValueObjects;

namespace Application.Dto
{
    public record CatDto(
        string Name,
        string Breed,
        bool IsMale,
        DateTime ArrivalDate,
        DateTime? AdoptionDate,
        DateTime? BirthDate,
        string? Description,
        IdCat? Id
        );
}
