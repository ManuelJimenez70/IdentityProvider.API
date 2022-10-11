using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityProvaider.Domain.ValueObjects;

namespace IdentityProvaider.Domain.Entities
{
    public class Password
    {
        public byte[] hash { get; init; }
        public Hash password { get; private set; }


        public Password()
        {

        }
        public Password(string data)
        {
            this.hash = Hash.create(data).value;
        }

        public Password(byte[] user_hash)
        {
            this.hash = user_hash;
        }

        public void setPassword(Hash password)
        {
            this.password = password;
        }
    }
}
