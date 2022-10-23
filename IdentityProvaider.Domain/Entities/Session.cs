using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Entities
{
    public class Session
    {
        public int id_session { get; init; }

        public UserId id_user   { get; private set; }

        public CreationDate loginDate { get; private set; }

        public Session() {
            loginDate = CreationDate.create(DateTime.Now);
        }

        public Session(UserId id_user)
        {
            this.id_user = id_user;
            loginDate = CreationDate.create(DateTime.Now);
        }

    }
}
