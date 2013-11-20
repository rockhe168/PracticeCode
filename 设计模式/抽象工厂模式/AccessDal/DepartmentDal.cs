using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractFactory;
using Domain;

namespace AccessDal
{
    class DepartmentDal : IDepartmentDal
    {
        public void Insert(Department user)
        {
            Console.WriteLine("这里是Access Department Inser Method....");
        }

        public Department GetDepartmentById(int departmentId)
        {
            var department = new Department() { DepartmentId = 1, DepartmentName = "技术部" };

            Console.WriteLine("这里是Access Department GetDepartmentById Method....");

            return department;
        }
    }
}
