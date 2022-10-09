using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record State
    {
        public char value { get; init; }

        internal State(char value)
        {
            this.value = value;
        }

        public static State create(char value)
        {
            validate(value);
            return new State(value);
        }

        private static void validate(char value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("El valor no puede ser nulo");
            }            
            //agregar que el valor no puede ser mayor  a 50 caracteres
        }
    }
}
