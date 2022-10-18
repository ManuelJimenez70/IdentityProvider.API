using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record LogUserId
    {

        public int value { get; init; }

        internal LogUserId(int value)
        {
            this.value = value;
        }

        public static LogUserId create(int value)
        {
            return new LogUserId(value);
        }

        public static implicit operator int(LogUserId logUserId)
        {
            return logUserId.value;
        }
    }
}
