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
    }
}
