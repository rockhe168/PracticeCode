﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace AbstractFactory
{
    public interface IDepartmentDal
    {
        void Insert(Department user);
        Department GetDepartmentById(int userId);
    }
}
