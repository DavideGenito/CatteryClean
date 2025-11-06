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
        private readonly string _adopterFilePath = "adopters.json";
        private readonly Dictionary<string, Cat> _cache = new(StringComparer.OrdinalIgnoreCase);
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
                            _adopters[a.TIN.ToString()] = a.ToAdopterPersistence();
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
            // save cats
            var catsList = _cache.Values.Select(a => a.ToCatPersistenceDto()).ToList();
            var jsonData = JsonSerializer.Serialize(catsList, _jsonOptions);
            File.WriteAllText(_catFilePath, jsonData);

            // save adopters
            /*
            var adoptersList = _adopters.Values.Select(a => a.ToAdopterPersistenceDto()).ToList();
            var jsonAdopters = JsonSerializer.Serialize(adoptersList, _jsonOptions);
            File.WriteAllText(_adopterFilePath, jsonAdopters);
            */
        }

        public void AddCat(Cat cat)
        {
            if (cat == null) throw new ArgumentNullException(nameof(cat));
            EnsureDataLoaded();
            if (_cache.ContainsKey(cat.Name))
                throw new InvalidOperationException($"A cat with the name '{cat.Name}' already exists.");
            _cache[cat.Id.Value] = cat;
            SaveChanges();
        }

        public void UpdateCat(Cat cat)
        {
            if (cat == null) throw new ArgumentNullException(nameof(cat));
            EnsureDataLoaded();
            if (!_cache.ContainsKey(cat.Name))
                throw new InvalidOperationException($"Cat '{cat.Name}' not found.");
            _cache[cat.Name] = cat;
            SaveChanges();
        }

        public void RemoveCat(Cat cat)
        {
            if (cat == null) throw new ArgumentNullException(nameof(cat));
            EnsureDataLoaded();
            if (!_cache.ContainsKey(cat.Name))
                throw new InvalidOperationException($"Cat '{cat.Name}' not found.");
            _cache.Remove(cat.Name);
            SaveChanges();
        }

        public Cat? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name cannot be null or empty.");
            EnsureDataLoaded();
            _cache.TryGetValue(name, out var cat);
            return cat;
        }

        public void RegisterAdoption(Adoption adoption)
        {
            if (adoption == null) throw new ArgumentNullException(nameof(adoption));
            EnsureDataLoaded();

            var cat = GetByName(adoption.Cat.Name);
            if (cat == null)
                throw new InvalidOperationException($"Cat '{adoption.Cat.Name}' not found.");

            cat.AdoptionDate = adoption.AdoptionDate;

            var tinKey = adoption.Adopter.TIN.ToString();
            if (!_adopters.ContainsKey(tinKey))
            {
                _adopters[tinKey] = adoption.Adopter;
            }

            SaveChanges();
        }

        public void CancelAdoption(Adoption adoption)
        {
            if (adoption == null) throw new ArgumentNullException(nameof(adoption));
            EnsureDataLoaded();

            var cat = GetByName(adoption.Cat.Name);
            if (cat == null)
                throw new InvalidOperationException($"Cat '{adoption.Cat.Name}' not found.");

            cat.AdoptionDate = null;
            SaveChanges();
        }

        public void RegisterAdopter(Adopter adopter)
        {
            if (adopter == null) throw new ArgumentNullException(nameof(adopter));
            EnsureDataLoaded();

            var tinKey = adopter.TIN.ToString();
            if (_adopters.ContainsKey(tinKey))
                throw new InvalidOperationException($"Adopter with TIN '{adopter.TIN}' already registered.");

            _adopters[tinKey] = adopter;
            SaveChanges();
        }

        public Adopter? GetAdopterByTIN(string tin)
        {
            EnsureDataLoaded();
            _adopters.TryGetValue(tin, out var a);
            return a;
        }

        public List<Cat> GetAllCats()
        {
            EnsureDataLoaded();
            return _cache.Values.ToList();
        }
    }
}
