using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Domain.Model.Entities;

namespace Application.UseCases
{
    public class CatteryService
    {
        private readonly ICatteryRepository _catteryRepository;
        private readonly IAdopterRepository _adopterRepository;
        public CatteryService (ICatteryRepository catteryRepository, IAdopterRepository adopterRepository)
        {
            _catteryRepository = catteryRepository;
            _adopterRepository = adopterRepository;
        }

        public void AddCat(CatDto catDto)
        {
            if(string.IsNullOrWhiteSpace(catDto.Name))
            {
                throw new ArgumentException("Cat name cannot be null or empty.");
            }

            _catteryRepository.AddCat(catDto.ToCat());
        }

        public void UpdateCat(CatDto catDto)
        {
            if (string.IsNullOrWhiteSpace(catDto.Name))
            {
                throw new ArgumentException("Cat name cannot be null or empty.");
            }
            _catteryRepository.UpdateCat(catDto.ToCat());
        }

        public void RemoveCat(CatDto catDto)
        {
            if (string.IsNullOrWhiteSpace(catDto.Name))
            {
                throw new ArgumentException("Cat name cannot be null or empty.");
            }
            _catteryRepository.RemoveCat(catDto.ToCat());
        }

        public CatDto? GetCatByID(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Cat name cannot be null or empty.");
            }
            else
            {
                return _catteryRepository.GetByID(id)?.ToCatDto();
            }
        }
        public void RegisterAdoption(AdoptionDto adoptionDto)
        {
            _catteryRepository.RegisterAdoption(adoptionDto.ToAdoption());
            _adopterRepository.RegisterAdopter(adoptionDto.Adopter.ToAdopter());
        }

        public void CancelAdoption(string id)
        {
            _catteryRepository.CancelAdoption(id);
        }

        public List<CatDto> GetAllCats()
        {
            var cats = _catteryRepository.GetAllCats();
            return cats.Select(cat => cat.ToCatDto()).ToList();
        }

        public List<CatDto> GetAllAdoptions()
        {
            var cats = _catteryRepository.GetAllAdoptions();
            return cats.Select(cats => cats.ToCatDto()).ToList();
        }
    }
}
