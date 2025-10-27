using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Adopter
    {
        string _name;
        public string Name
        {
            get 
            { 
                return _name; 
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                _name = value;
            }
        }

        private string _surname;
        public string Surname
        {
            get 
            { 
                return _surname; 
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Surname cannot be null or empty.");
                }
                _surname = value;
            }
        }

        private PhoneNumber _phoneNumber;
        public PhoneNumber PhoneNumber
        {
            get 
            { 
                return _phoneNumber;
            }
            private set
            {
                _phoneNumber = value;
            }
        }

        private Address _addres;
        public Address Address
        {
            get
            { 
                return _addres;
            }
            private set
            {
                _addres = value;
            }
        }

        private TIN _tin;
        public TIN TIN
        {
            get
            {
                return _tin;
            }
            private set
            {
                _tin = value;
            }
        }

        private Email _email;
        public Email Email
        {
            get
            {
                return _email;
            }
            private set
            {
                _email = value;
            }
        }

        public Adopter(string name, string surname, Email email, PhoneNumber phoneNumber, Address address, TIN tin)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Address = address;
            TIN = tin;
            Email = email;
        }

        public override string ToString()
        {
            return $"Adopter Details:\nName: {Name} {Surname}\nPhone Number: {PhoneNumber}\nAddress: {Address}\nTIN: {TIN}";
        }
    }
}
