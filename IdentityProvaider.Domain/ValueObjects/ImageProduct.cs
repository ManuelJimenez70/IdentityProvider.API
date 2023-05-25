using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record ImageProduct
    {
        public string value { get; init; }

        internal ImageProduct(string value)
        {
            this.value = value;
        }

        public static ImageProduct create(string value)
        {
            validate(value);
            return new ImageProduct(value);
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
