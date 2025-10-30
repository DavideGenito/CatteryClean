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

        public CatDto? GetCatByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Cat name cannot be null or empty.");
            }
            else
            {
                return _catteryRepository.GetByName(name)?.ToCatDto();
            }
        }

        public void RegisterAdoption(AdoptionDto adoptionDto)
        {
            _catteryRepository.RegisterAdoption(adoptionDto.ToAdoption());
        }

        public void CancelAdoption(AdoptionDto adoptionDto)
        {
            _catteryRepository.CancelAdoption(adoptionDto.ToAdoption());
        }

        public void RegisterAdopter(AdopterDto adopterDto)
        {
            _catteryRepository.RegisterAdopter(adopterDto.ToAdopter());
        }

        public List<CatDto> GetAllCats()
        {
            var cats = _catteryRepository.GetAllCats();
            return cats.Select(cat => cat.ToCatDto()).ToList();
        }
    }
}
