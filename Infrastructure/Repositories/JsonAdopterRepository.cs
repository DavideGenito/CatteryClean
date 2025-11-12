using Domain.Model.Entities;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Dto;
using System.Text.Json.Serialization;
using System.Text.Json;
using Infrastructure.Mapper;

namespace Infrastructure.Repositories
{
    public class JsonAdopterRepository : IAdopterRepository
    {
        private readonly string _adopterFilePath = "adopters.json";
        private readonly Dictionary<string, Adopter> _adopters = new(StringComparer.OrdinalIgnoreCase);
        private bool _isLoaded = false;

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            // evita problemi con i riferimenti circolari
            ReferenceHandler = ReferenceHandler.Preserve
        };

        private void EnsureDataLoaded()
        {
            if (_isLoaded) return;

            if (File.Exists(_adopterFilePath))
            {
                //per eventuali errori di lettura/parsing del file
                try
                {
                    var jsonData = File.ReadAllText(_adopterFilePath);
                    var adopters = JsonSerializer.Deserialize<List<AdopterPersistenceDto>>(jsonData, _jsonOptions);
                    if (adopters != null)
                    {
                        foreach (var a in adopters)
                            _adopters[a.TIN.ToString()] = a.ToAdopter();
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Errore durante il caricamento degli adottanti dal file: {ex.Message}", ex);
                }
            }

            _isLoaded = true;
        }

        private void SaveChanges()
        {
            var adoptersList = _adopters.Values.Select(a => a.ToAdopterPersistenceDto()).ToList();
            var jsonAdopters = JsonSerializer.Serialize(adoptersList, _jsonOptions);
            File.WriteAllText(_adopterFilePath, jsonAdopters);
        }  

        public void RegisterAdopter(Adopter adopter)
        {
            if (adopter == null) throw new ArgumentNullException(nameof(adopter));
            EnsureDataLoaded();

            var tinKey = adopter.TIN.ToString();
            if (_adopters.ContainsKey(tinKey))
                return;

            _adopters[tinKey] = adopter;
            SaveChanges();
        }

        public Adopter? GetAdopterByTIN(string tin)
        {
            EnsureDataLoaded();
            _adopters.TryGetValue(tin, out var a);
            return a;
        }

        public List<Adopter> GetAllAdopters()
        {
            EnsureDataLoaded();
            return _adopters.Values.ToList();
        }
    }
}
