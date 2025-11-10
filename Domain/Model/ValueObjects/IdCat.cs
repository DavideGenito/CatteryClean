using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record class IdCat
    {
        /*
         * Un numero random di 5 cifre.
         * La prima lettera del mese di registrazione.
         * L'anno della data di registrazione.
         * Tre lettere casuali.
         */
        Random random = new Random();
        public List<string> months = new List<string> { "J", "F", "M", "A", "M", "J", "J", "A", "S", "O", "N", "D" };
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public string Value;
        public IdCat(DateTime arrivalDate)
        {
            int monthIndex = arrivalDate.Month - 1;
            string monthLetter = months[monthIndex];
            string randomChars = "";
            for (int i = 0; i < 3; i++)
            {
                randomChars += chars[random.Next(chars.Length)];
            }
            string randomDigits = random.Next(10000, 99999).ToString();
            Value = $"{monthLetter}{randomChars}{randomDigits}";
        }

        public IdCat(string value) 
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}