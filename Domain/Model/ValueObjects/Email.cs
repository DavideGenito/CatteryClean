using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record Email
    {
        public string Value;
        public Email(string value)
        {
            if(value.Contains("@") && value.Contains("."))
            {
                this.Value = value;
            }
            else
            {
                throw new ArgumentException("Invalid email format. It should contain '@' and '.' characters.");
            }
        }
    }
}
