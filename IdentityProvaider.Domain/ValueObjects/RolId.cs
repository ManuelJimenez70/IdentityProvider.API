using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public class RolId
    {
        public int value { get; init; }

        internal RolId(int value)
        {
            this.value = value;
        }

        public static RolId create(int value)
        {
            return new RolId(value);
        }

        public static implicit operator int(RolId credentialId)
        {
            return credentialId.value;
        }
    }
}
