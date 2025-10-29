using Domain.Model.ValueObjects;
using System;
using System.Text.Json.Serialization;

namespace Domain.Model.Entities
{
    public class Adopter
    {
        public Adopter(string name, string surname, Email email, PhoneNumber phoneNumber, Address address, TIN tin)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Address = address;
            TIN = tin;
            Email = email;
        }

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
        private string _name = "";

        public string Surname
        {
            get => _surname;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Surname cannot be null or empty.");
                _surname = value;
            }
        }
        private string _surname = "";

        public PhoneNumber PhoneNumber
        {
            get => _phoneNumber;
            private set => _phoneNumber = value;
        }
        private PhoneNumber _phoneNumber = null!;

        public Address Address
        {
            get => _addres;
            private set => _addres = value;
        }
        private Address _addres = null!;

        public TIN TIN
        {
            get => _tin;
            private set => _tin = value;
        }
        private TIN _tin = null!;

        public Email Email
        {
            get => _email;
            private set => _email = value;
        }
        private Email _email = null!;

        public override string ToString()
        {
            return $"Adopter Details:\nName: {Name} {Surname}\nPhone Number: {PhoneNumber}\nAddress: {Address}\nTIN: {TIN}";
        }
    }
}
