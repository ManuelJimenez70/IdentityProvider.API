using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Entities
{
    public class LogUser
    {
        public int id_log { get; init; }
        public UserId id_edit_user { get; private set; }
        public UserId id_manager { get; private set; }
        public Email email { get; private set; }
        public UserName name { get; private set; }
        public UserLastName lastName { get; private set; }
        public UserTypeDocument typeDocument { get; private set; }
        public UserIdentification identification { get; private set; }
        public State state { get; private set; }
        public Direction direction { get; private set; }
        public IP iP { get; private set; }
        public Location location { get; private set;}
        public Coordinate coordinate { get; private set; }
        public CreationDate logDate { get; private set; }
        public Description description { get; private set; }

        public LogUser()
        {
            logDate = CreationDate.create(DateTime.Now);
        }

        public LogUser(int id_log, UserId id_edit_user, UserId id_manager)
        {
            this.id_log = id_log;
            this.id_edit_user = id_edit_user;
            this.id_manager = id_manager;
            logDate = CreationDate.create(DateTime.Now);
        }
        public void setIP(IP iP)
        {
            this.iP = iP;
        }

        public void setLocation(Location location)
        {
            this.location = location;
        }

        public void setIdEditUser(UserId id_edit_user)
        {
            this.id_edit_user = id_edit_user;
        }
        public void setIdManager(UserId id_manager)
        {
            this.id_manager = id_manager;
        }

        public void setDescription(Description description)
        {
            this.description = description;
        }

        public void setCoordinate(Coordinate coordinate)
        {
            this.coordinate = coordinate;
        }

        public void setEmail(Email email)
        {
            this.email = email;
        }

        public void setName(UserName name)
        {
            this.name = name;
        }
        public void setLastName(UserLastName lastName)
        {
            this.lastName = lastName;
        }

        public void setTypeDocument(UserTypeDocument typeDocument)
        {
            this.typeDocument = typeDocument;
        }

        public void setIdentification(UserIdentification identification)
        {
            this.identification = identification;
        }

        public void setDirection(Direction direction)
        {
            this.direction = direction;
        }
        public void setState(State state)
        {
            this.state = state;
        }

        public object getLog()
        {
            return new { id_log = this.id_log, id_manager = this.id_manager , id_edit_user = this.id_edit_user , date = this.logDate, state = this.state , description = this.description };
        }

    }
}
