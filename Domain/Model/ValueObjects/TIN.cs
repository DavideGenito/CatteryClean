using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record TIN
    {
        /*
         * Le prime tre lettere del codice fiscale sono prese dal cognome (consonanti solitamente)
         * Le seconde tre dal nome (consonanti)
         * Le ultime due cifre dell'anno di nascita
         * Una lettera per il mese (A = Gennaio, B, C, D, E, H, L, M, P, R, S, T = Dicembre)
         * Il giorno di nascita: in caso di sesso femminile si aggiunge 40 per cui è chiaro che se si trova scritto, ad esempio, 52, non può che trattarsi di una donna nata il 12 del mese.
         * Codice del comune (quattro caratteri)
         * Carattere di controllo, per verificare la correttezza del codice fiscale. 
         */
        public string Value;
        public TIN(string value)
        {
            if(value.Length != 16) throw new ArgumentException("Invalid TIN lenght");
            for(int i = 0; i < 6; i++)
            {
                if (!Char.IsLetter(value[i])) throw new ArgumentException("Invalid TIN format");
            }
            for(int i = 6; i < 8;  i++)
            {
                if(!Char.IsDigit(value[i])) throw new ArgumentException("Invalid TIN format");
            }
            if (!Char.IsLetter(value[8])) throw new ArgumentException("Invalid TIN format");
            for (int i = 9; i < 11; i++)
            {
                if (!Char.IsDigit(value[i])) throw new ArgumentException("Invalid TIN format");
            }
            if (!Char.IsLetter(value[11])) throw new ArgumentException("Invalid TIN format");
            for(int i = 12;  i < 15; i++)
            {
                if (!Char.IsDigit(value[i])) throw new ArgumentException("Invalid TIN format");
            }
            if (!Char.IsLetter(value[15])) throw new ArgumentException("Invalid TIN format");

            Value = value;
        }

        public override string ToString() 
        { 
            return Value; 
        }
    }
}
