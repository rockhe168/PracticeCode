using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

using CQRS.Sample.Domain;

namespace CQRS.Sample.Data.Mapping
{
    class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("`User`");

            Id(c => c.Id, m => m.Generator(Generators.Assigned));

            Property(c => c.Email);
            Property(c => c.NickName);
            Property(c => c.Password);
        }
    }
}
