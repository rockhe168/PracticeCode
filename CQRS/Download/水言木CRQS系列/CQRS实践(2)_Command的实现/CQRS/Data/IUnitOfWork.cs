﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
