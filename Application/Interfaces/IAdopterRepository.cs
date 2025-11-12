using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdopterRepository
    {
        void RegisterAdopter(Adopter adopter);
        List<Adopter> GetAllAdopters();
    }
}
