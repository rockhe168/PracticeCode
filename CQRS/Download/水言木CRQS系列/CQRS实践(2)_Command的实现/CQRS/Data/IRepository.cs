using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.Data
{
    public interface IRepository<T>
        where T : class
    {
        T GetById(object id);

        IQueryable<T> Query();

        void Add(T entity);

        void Delete(T entity);
    }
}
