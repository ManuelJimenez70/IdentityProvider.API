using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record Coordinate
    {
        public string value { get; init; }

        internal Coordinate(string value)
        {
            this.value = value;
        }

        public static Coordinate create(string value)
        {
            validate(value);
            return new Coordinate(value);
        }

        private static void validate(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Las Coordenadas no pueden ser nulas");
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Las Coordenadas no pueden ser nulas");
            }
            if (value.Length>100)
            {
                throw new ArgumentNullException("Las Coordenadas supera la longitud máxima");
            }
        }
    }
}
