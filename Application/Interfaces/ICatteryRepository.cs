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
        void UpdateCat (Cat cat);
        void RemoveCat(Cat cat);
        Cat? GetByName(string name);
        void RegisterAdoption (Adoption adoption);
        void CancelAdoption (Adoption adoption);
        void RegisterAdopter (Adopter adopter);
        List<Cat> GetAllCats();
    }
}
