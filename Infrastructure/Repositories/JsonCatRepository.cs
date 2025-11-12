using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Domain.Model.Entities;
using Infrastructure.Dto;
using Infrastructure.Mapper;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.Repositories
{
    public class JsonCatRepository : ICatteryRepository
    {
        private readonly string _catFilePath = "cat.json";
        private readonly Dictionary<string, Cat> _cache = new(StringComparer.OrdinalIgnoreCase);
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

            if (File.Exists(_catFilePath))
            {
                //per eventuali errori di lettura/parsing del file
                try
                {
                    var jsonData = File.ReadAllText(_catFilePath);
                    var cats = JsonSerializer.Deserialize<List<CatPersistenceDto>>(jsonData, _jsonOptions);
                    if (cats != null)
                    {
                        foreach (var cat in cats)
                            _cache[cat.id] = cat.ToCat();
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Errore durante il caricamento dei gatti dal file: {ex.Message}", ex);
                }
            }

            _isLoaded = true;
        }

        private void SaveChanges()
        {
            // save cats
            var catsList = _cache.Values.Select(a => a.ToCatPersistenceDto()).ToList();
            var jsonData = JsonSerializer.Serialize(catsList, _jsonOptions);
            File.WriteAllText(_catFilePath, jsonData);
        }

        public void AddCat(Cat cat)
        {
            if (cat == null) throw new ArgumentNullException(nameof(cat));
            EnsureDataLoaded();
            if (_cache.ContainsKey(cat.Id.Value))
                throw new InvalidOperationException($"A cat with the name '{cat.Id.Value}' already exists.");
            _cache[cat.Id.Value] = cat;
            SaveChanges();
        }

        public void UpdateCat(Cat cat)
        {
            if (cat == null) throw new ArgumentNullException(nameof(cat));
            EnsureDataLoaded();
            if (!_cache.ContainsKey(cat.Id.Value))
                throw new InvalidOperationException($"Cat '{cat.Id.Value}' not found.");
            _cache[cat.Id.Value] = cat;
            SaveChanges();
        }

        public void RemoveCat(Cat cat)
        {
            if (cat == null) throw new ArgumentNullException(nameof(cat));
            EnsureDataLoaded();
            if (!_cache.ContainsKey(cat.Id.Value))
                throw new InvalidOperationException($"Cat '{cat.Id.Value}' not found.");
            _cache.Remove(cat.Id.Value);
            SaveChanges();
        }

        public Cat? GetByID(string ID)
        {
            if (string.IsNullOrWhiteSpace(ID)) throw new ArgumentException("name cannot be null or empty.");
            EnsureDataLoaded();
            if (_cache.TryGetValue(ID, out var cat))
                return cat;
            return null;
        }

        public void RegisterAdoption(Adoption adoption)
        {
            if (adoption == null) throw new ArgumentNullException(nameof(adoption));
            EnsureDataLoaded();

            var cat = GetByID(adoption.Cat.Id.Value);
            if (cat == null)
                throw new InvalidOperationException($"Cat '{adoption.Cat.Id.Value}' not found.");

            cat.AdoptionDate = adoption.AdoptionDate;

            SaveChanges();
        }

        public void CancelAdoption(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            EnsureDataLoaded();

            var cat = GetByID(id);
            if (cat == null)
                throw new InvalidOperationException($"Cat '{id}' not found.");

            cat.AdoptionDate = null;
            SaveChanges();
        }

        public List<Cat> GetAllCats()
        {
            EnsureDataLoaded();
            return _cache.Values.ToList();
        }

        public List<Cat> GetAllAdoptions()
        {
            EnsureDataLoaded();
            return _cache.Values.Where(cat => cat.AdoptionDate != null).ToList();
        }
    }
}
