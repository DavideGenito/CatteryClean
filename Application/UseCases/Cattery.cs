using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interfaces;
using Domain.Model.Entities;

namespace Application.UseCases
{
    public class Cattery
    {
        private readonly ICatteryRepository _catteryRepository;
        public Cattery (ICatteryRepository catteryRepository)
        {
            _catteryRepository = catteryRepository;
        }

        public void AddCat(CatDto catDto)
        {
            if(string.IsNullOrWhiteSpace(catDto.Name))
            {
                throw new ArgumentException("Cat name cannot be null or empty.");
            }
        }

        public Cat? GetCatByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Cat name cannot be null or empty.");
            }
            else
            {
                //TODO: aggiungere mappatura da CatDto a Cat O BOH SMTH
                return _catteryRepository.GetByName(name);
            }
        }
    }
}
