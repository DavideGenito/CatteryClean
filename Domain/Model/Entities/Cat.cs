using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Cat
    {
        private IdCat _id;
        public IdCat Id
        {
            get
            {
                return _id;
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value.ToString()))
                {
                    throw new ArgumentException("Id cannot be null or empty.");
                }
                _id = value;
            }
        }

        private string _name;
        public string Name
        { 
            get 
            { 
                return _name;
            } 
            private set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                _name = value; 
            }
        }
        private string _breed;
        public string Breed
        {
            get
            {
                return _breed;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("race cannot be null or empty.");
                }
                _breed = value;
            }
        }
        private bool _isMale;
        public bool IsMale
        {
            get
            {
                return _isMale;
            }
            private set
            {
                _isMale = value;
            }
        }
        private DateTime? _birthDate;
        public DateTime? BirthDate
        {
            get
            {
                return _birthDate;
            }
            private set
            {
                if(value != null && value > DateTime.Now)
                {
                    throw new ArgumentException("Birth date cannot be in the future.");
                }
                _birthDate = value;
            }
        }
        private DateTime _arrivalDate;
        public DateTime ArrivalDate
        {
            get
            {
                return _arrivalDate;
            }
            private set
            {
                if(value > DateTime.Now)
                {
                    throw new ArgumentException("Arrival date cannot be in the future.");
                }
                _arrivalDate = value;
            }
        }
        private DateTime? _adoptionDate = null;
        public DateTime? AdoptionDate
        {
            get
            {
                return _adoptionDate;
            }
            set
            {
                if(value != null && value < ArrivalDate)
                {
                    throw new ArgumentException("Adoption date cannot be before arrival date.");
                }
                if(value != null && value > DateTime.Now)
                {
                    throw new ArgumentException("Adoption date cannot be in the future.");
                }
                _adoptionDate = value;
            }
        }
        private string? _description;
        public string? Description
        {
            get
            {
                return _description;
            }
            private set
            {
                _description = value;
            }
        }
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
    }
}