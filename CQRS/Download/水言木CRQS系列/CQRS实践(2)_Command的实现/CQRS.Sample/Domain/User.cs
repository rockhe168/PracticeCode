using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.Sample.Domain
{
    public class User
    {
        public virtual string Id { get; protected set; }

        public virtual string Email { get; set; }

        public virtual string NickName { get; set; }

        public virtual string Password { get; set; }

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
