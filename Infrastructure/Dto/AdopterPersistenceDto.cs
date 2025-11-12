using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    internal record AdopterPersistenceDto(
        string Name,
        string Surname,
        string PhoneNumber,
        string Email,
        string Address,
        string TIN
        );
}
