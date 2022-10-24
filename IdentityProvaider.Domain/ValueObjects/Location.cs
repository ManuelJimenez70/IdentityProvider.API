using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record Location
    {
        public string value { get; init; }

        internal Location(string value)
        {
            this.value = value;
        }

        public static Location create(string value)
        {
            validate(value);
            return new Location(value);
        }

        private static void validate(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("La Localidad no puede ser nula");
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("La Localidad no puede ser nula");
            }
            if (value.Length > 120)
            {
                throw new ArgumentNullException("La Localidad supera la longitud máxima");
            }

        }
    }
}
