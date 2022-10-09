using System.Security.Cryptography;
using System.Text;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record Hash
    {
        public  byte[] value { get; init; }

        internal Hash(byte[] value)
        {
            this.value = value;
        }

        public static Hash create(string value)
        {            
            validate(value);
            return new Hash(encrypt(value));
        }

        private static byte[] encrypt(string value)
        {
            byte[] hash = SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(value));            
            Console.WriteLine(Convert.ToBase64String(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(value))));            
            return hash;            
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
            //agregar que el valor no puede ser mayor  a 50 caracteres
        }
    }
}
