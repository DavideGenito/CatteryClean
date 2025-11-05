using Domain.Model.ValueObjects;
using System;
using System.Text.Json.Serialization;

namespace Domain.Model.Entities
{
    public class Cat
    {
        public Cat(string name, string breed, bool isMale, DateTime arrivalDate, DateTime? adoptionDate, DateTime? birthDate, string? description)
        {
            Name = name;
            Breed = breed;
            IsMale = isMale;
            ArrivalDate = arrivalDate;
            AdoptionDate = adoptionDate;
            BirthDate = birthDate;
            Description = description;
            Id = new ValueObjects.IdCat(arrivalDate);
        }

        public IdCat Id { get; private set; }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be null or empty.");
                _name = value;
            }
        }
        private string _name;

        public string Breed
        {
            get => _breed;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("breed cannot be null or empty.");
                _breed = value;
            }
        }
        private string _breed;

        public bool IsMale
        {
            get => _isMale;
            private set => _isMale = value;
        }
        private bool _isMale;

        public DateTime? BirthDate
        {
            get => _birthDate;
            private set
            {
                if (value != null && value > DateTime.Now)
                    throw new ArgumentException("Birth date cannot be in the future.");
                _birthDate = value;
            }
        }
        private DateTime? _birthDate;

        public DateTime ArrivalDate
        {
            get => _arrivalDate;
            private set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Arrival date cannot be in the future.");
                _arrivalDate = value;
            }
        }
        private DateTime _arrivalDate;

        public DateTime? AdoptionDate
        {
            get => _adoptionDate;
            set
            {
                if (value != null && value < ArrivalDate)
                    throw new ArgumentException("Adoption date cannot be before arrival date.");
                if (value != null && value > DateTime.Now)
                    throw new ArgumentException("Adoption date cannot be in the future.");
                _adoptionDate = value;
            }
        }
        private DateTime? _adoptionDate;

        public string? Description
        {
            get => _description;
            private set => _description = value;
        }
        private string? _description;
    }
}
