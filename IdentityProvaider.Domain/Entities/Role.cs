using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Entities
{
    public class Role
    {
        public int id_rol { get; init; }

        public RoleName name { get; private set; }

        public Description description { get; private set; }
        public IList<Rol_User> rol_Users { get; set; }

        public Role()
        {
        }

        public Role(int id_rol)
        {
            this.id_rol = id_rol;
        }

        public void setName(RoleName name)
        {
            this.name = name;
        }

        public void setDescription(Description description)
        {
            this.description = description;
        }
    }
}
