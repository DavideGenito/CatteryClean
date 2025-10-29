using System;
using System.Text.Json.Serialization;

namespace Domain.Model.Entities
{
    public class Adoption
    {

        public Adoption(Adopter adopter, Cat cat, DateTime adoptionDate)
        {
            Adopter = adopter;
            Cat = cat;
            AdoptionDate = adoptionDate;
            cat.AdoptionDate = adoptionDate;
        }

        public Adopter Adopter
        {
            get => _adopter;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Adopter), "Adopter cannot be null.");
                _adopter = value;
            }
        }
        private Adopter _adopter = null!;

        public Cat Cat
        {
            get => _cat;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Cat), "Cat cannot be null.");
                _cat = value;
            }
        }
        private Cat _cat = null!;

        public DateTime AdoptionDate
        {
            get => _adoptionDate;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Adoption date cannot be in the future.");
                _adoptionDate = value;
            }
        }
        private DateTime _adoptionDate;

        public override string ToString()
        {
            return $"Adoption Details:\nAdopter: {Adopter.Name} {Adopter.Surname}\nCat: {Cat.Name}\nAdoption Date: {AdoptionDate.ToShortDateString()}";
        }

        public void DeleteAdoption()
        {
            Cat.AdoptionDate = null;
        }
    }
}
