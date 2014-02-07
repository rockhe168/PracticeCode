using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace CQRS.Sample.Data
{
    public static class SessionManager
    {
        public static readonly ISessionFactory SessionFactory;

        static SessionManager()
        {
            var config = new Configuration();
            config.DataBaseIntegration(x =>
            {
                x.Driver<NHibernate.Driver.SqlClientDriver>();
                x.Dialect<NHibernate.Dialect.MsSql2005Dialect>();
                x.ConnectionStringName = "CQRS.Sample";
            });

            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.Load("CQRS.Sample").GetTypes().Where(it => it.Name.EndsWith("Map")));

            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            SessionFactory = config.BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
