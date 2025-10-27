using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record PhoneNumber
    {
        const int ItalianPhoneNumberLength = 13; 
        const string CountryCode = "+39";
        public string Value;

        public PhoneNumber(string value)
        {
            if(value.Contains(CountryCode) && value.Length == ItalianPhoneNumberLength)
            {
                for(int i = 1; i < value.Length; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new ArgumentException("Invalid phone number format. There shouldn't be any letters.");
                    }
                    else
                    {
                        Value = value;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Invalid phone number format. It should start with +39 and be 13 characters long.");
            }

            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
