using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record class RoleName
    {
        public string value { get; init; }

        internal RoleName(string value)
        {
            this.value = value;
        }

        public static RoleName create(string value)
        {
            validate(value);
            return new RoleName(value);
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
        }
    }
}
