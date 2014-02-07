using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;

namespace CQRS.Data.Nh
{
    public class NhUnitOfWork : IUnitOfWork
    {
        public ISession Session { get; private set; }

        public NhUnitOfWork(ISession session)
        {
            Session = session;
            Session.BeginTransaction();
        }

        public void Commit()
        {
            Session.Transaction.Commit();
        }

        public void Dispose()
        {
            Session.Dispose();
        }
    }
}
