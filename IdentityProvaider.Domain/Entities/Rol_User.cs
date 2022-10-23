using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Entities
{
    public class Rol_User
    {
        public int id_user { get; set; }
        public User user { get; private set; }
        public int id_rol { get; set; }
        public Role role { get; private set; }
        public CreationDate  creationDate{ get; private set; }
        public State state { get; private set; }

        public Rol_User()
        {
            creationDate = CreationDate.create(DateTime.Now);
            state = State.create("Activo");
        }
        public Rol_User(int id_user, int id_rol)
        {
            this.id_user = id_user;
            this.id_rol = id_rol;
            creationDate = CreationDate.create(DateTime.Now);
            state = State.create("Activo");
        }

        public void setRoles(Role role)
        {
            this.role = role;
        }

        public void setUser(User user)
        {
            this.user = user;
        }

        public void setCreationDate(CreationDate creationDate)
        {
            this.creationDate = creationDate;
        }

        public void setState(State state)
        {
            this.state = state;
        }

    }
}
