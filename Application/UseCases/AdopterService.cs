using Application.Dto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mappers;

namespace Application.UseCases
{
    public class AdopterService
    {
        private readonly IAdopterRepository _adopterRepository;
        public AdopterService(IAdopterRepository adopterRepository)
        {
            _adopterRepository = adopterRepository;
        }


        public void RegisterAdopter(AdopterDto adopterDto)
        {
            _adopterRepository.RegisterAdopter(adopterDto.ToAdopter());
        }

        public List<AdopterDto> GetAllAdopters()
        {
            var adopters = _adopterRepository.GetAllAdopters();
            return adopters.Select(a => a.ToAdopterDto()).ToList();
        }
    }
}
