using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Linq;

namespace CQRS.Data.Nh
{
    public class NhRepository<T> : IRepository<T>
        where T : class
    {
        public NhUnitOfWork UnitOfWork { get; private set; }

        public ISession Session
        {
            get
            {
                return UnitOfWork.Session;
            }
        }

        public NhRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = (NhUnitOfWork)unitOfWork;
        }

        public T GetById(object id)
        {
            return Session.Get<T>(id);
        }

        public IQueryable<T> Query()
        {
            return Session.Query<T>();
        }

        public void Add(T entity)
        {
            Session.Save(entity);
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
        }
    }
}
