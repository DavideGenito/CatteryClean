using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    internal record CatPersistenceDto(        
        string name,
        string breed,
        bool isMale,
        DateTime arrivalDate,
        DateTime? adoptionDate,
        DateTime? birthDate,
        string? description,
        string id
        );
}
