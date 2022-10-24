using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record CreationDate
    {
        public DateTime value { get; set; }
        internal CreationDate(DateTime value)
        {
            this.value = value;
        }

        public static CreationDate create(DateTime value)
        {
            validate(value);
            return new CreationDate(value);
        }

        private static void validate(DateTime value)
        {
            
            if (value == new DateTime())
            {
                throw new ArgumentNullException("La fecha no puede ser la default");
            
            }else if (!(value <= DateTime.Now)) { 
                throw new ArgumentException("La fecha ingresada supera a la fecha actual");
            }
        }
    }
}
