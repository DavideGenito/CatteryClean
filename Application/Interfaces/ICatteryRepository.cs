using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace Application.Interfaces
{
    public interface ICatteryRepository
    {
        void AddCat (Cat cat);
        void RegisterAdoption (Adoption adoption);
        void CancelAdoption (Adoption adoption);
        void RegisterAdopter (Adopter adopter);
        Cat? GetByName (string name);
    }
}
