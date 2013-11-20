using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Service
{
    public interface IService
    {
        IList FindAll();

        void Save(object entity);
    }
}
