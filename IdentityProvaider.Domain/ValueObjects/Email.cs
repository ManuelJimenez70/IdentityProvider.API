using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record Email
    {
        public string value { get; init; }

        internal Email(string value)
        {
            this.value = value;
        }

        public static Email create(string value)
        {
            validate(value);
            return new Email(value);
        }

        private static void validate(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("El valor no puede ser nulo");
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("El valor no puede ser nulo");
            }
            //agregar que el valor no puede ser mayor  a 50 caracteres
        }
    }
}
