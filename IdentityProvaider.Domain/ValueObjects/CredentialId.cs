using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record CredentialId
    {
        public int value { get; init; }

        internal CredentialId(int value)
        {
            this.value = value;
        }

        public static CredentialId create(int value)
        {
            validate(value);
            return new CredentialId(value);
        }

        public static implicit operator int(CredentialId credentialId)
        {
            return credentialId.value;
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
