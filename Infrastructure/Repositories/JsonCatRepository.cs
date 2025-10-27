using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Model.Entities;
using System.Text.Json;
/*
namespace Infrastructure.Repositories
{
    public class JsonCatRepository : ICatteryRepository
    {
        private readonly string _filePath = "cat.json";
        private readonly Dictionary<string, Cat> _cache = new(StringComparer.OrdinalIgnoreCase);
        private bool _isLoaded = false;

       TODO : Implement JSON persistence logic
        private void EnsureDataLoading()
        {
            if(_isLoaded) return;

            if(!File.Exists(_filePath))
            {
                _isLoaded = true;
                return;
            }

            var jsonData = File.ReadAllText(_filePath);
        }
        
    }
}
*/