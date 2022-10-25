using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record UserId
    {
        public int value { get; init; }

        internal UserId(int value)
        {
            validate(value);
            this.value = value;
        }

        public static UserId create(int value)
        {
            return new UserId(value);
        }

        public static implicit operator int(UserId userId)
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
