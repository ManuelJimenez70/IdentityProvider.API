using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record Rating
    {
        public int value { get; init; }

        internal Rating(int value)
        {
            validate(value);
            this.value = value;
        }

        public static Rating create(int value)
        {
            return new Rating(value);
        }

        public static implicit operator int(Rating userId)
        {
            return userId.value;
        }
        private static void validate(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentNullException("El valor del Id tiene que ser mayor a cero");
            }
        }
    }
}
