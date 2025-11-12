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
        Cat? GetByID(string ID);
        void RegisterAdoption(Adoption adoption);
        void CancelAdoption(string ID);
        List<Cat> GetAllCats();
        List<Cat> GetAllAdoptions();
    }
}
