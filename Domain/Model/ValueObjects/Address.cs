using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record Address
    {
        public Address(string street, string civicNumber, string city, string postalCode)
        {
            Street = street;
            CivicNumber = civicNumber;
            City = city;
            PostalCode = postalCode;
        }

        public Address(string adress)
        {
            /*
             * ?<Street> dà un nome a quel gruppo.
             * . → qualsiasi carattere
             * + → uno o più
             * ? → modalità “non greedy” (prende il meno possibile per permettere agli altri gruppi di funzionare correttamente)
             * \d → cifra da 0 a 9
             * */
            var match = Regex.Match(adress, @"^(?<Street>.+?) (?<CivicNumber>[A-Za-z0-9/-]+), (?<City>.+?) (?<PostalCode>\d+)$");
            if (!match.Success)
            {
                throw new ArgumentException("Address format is invalid.");
            }
            else
            {
                Street = match.Groups["Street"].Value;
                CivicNumber = match.Groups["CivicNumber"].Value;
                City = match.Groups["City"].Value;
                PostalCode = match.Groups["PostalCode"].Value;
            }
        }

        private string _street;
        public string Street
        {
            get
            {
                return _street;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Street cannot be null or empty.");
                }
                _street = value;
            }
        }

        private string _civicNumber;
        public string CivicNumber
        {
            get
            {
                return _civicNumber;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Civic number cannot be null or empty.");
                }
                _civicNumber = value;
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("City cannot be null or empty.");
                }
                _city = value;
            }
        }
        private string _postalCode;
        public string PostalCode
        {
            get
            {
                return _postalCode;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Postal Code cannot be null or empty.");
                }
                _postalCode = value;
            }
        }

        public override string ToString()
        {
            return Street + " " + CivicNumber + ", " + City + " " + PostalCode;
        }
    }
}
