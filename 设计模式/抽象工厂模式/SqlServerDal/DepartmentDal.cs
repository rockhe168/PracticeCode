using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractFactory;
using Domain;

namespace SqlServerDal
{
    class DepartmentDal:IDepartmentDal
    {
        public void Insert(Department user)
        {
            Console.WriteLine("这里是SqlServer Department Inser Method....");
        }

        public Department GetDepartmentById(int departmentId)
        {
            var department = new Department() { DepartmentId = 1, DepartmentName = "技术部" };

            Console.WriteLine("这里是SqlServer Department GetDepartmentById Method....");

            return department;
        }
    }
}
