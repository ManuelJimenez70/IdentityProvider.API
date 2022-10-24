﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record Direction
    {
        public string value { get; init; }

        internal Direction(string value)
        {
            this.value = value;
        }

        public static Direction create(string value)
        {
            validate(value);
            return new Direction(value);
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
