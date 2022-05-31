using DemoProject.BAL.Interface;
using DemoProject.DAL.Database;
using DemoProject.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoProject.BAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext context;

        public EmployeeRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public bool AddEmployee(VM_Employee model)
        {
            Employee employee = new Employee()
            {
                Email = model.Email,
                Name = model.Name,
                Phone = model.Phone
            };
            context.Employee.Add(employee);
            int i = context.SaveChanges();
            if (i > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateEmployee(VM_Employee model)
        {
            var emp = context.Employee.Find(model.Id);
            if (emp == null)
            {
                return false;
            }
            emp.Name = model.Name;
            emp.Email = model.Email;
            emp.Phone = model.Phone;
            context.Employee.Update(emp);
            int i = context.SaveChanges();
            if (i > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteEmployee(int employeeid)
        {
            var emp = context.Employee.Find(employeeid);
            if (emp == null)
            {
                return false;
            }
            context.Employee.Remove(emp);
            int i = context.SaveChanges();
            if (i > 0)
            {
                return true;
            }
            return false;
        }

        public List<VM_Employee> GetAllEmployee()
        {
            var employees = context.Employee.Select(
                x =>
                new VM_Employee()
                {
                    Email = x.Email,
                    Id = x.Id,
                    Name = x.Name,
                    Phone = x.Phone
                }
                ).ToList();
            return employees;
        }

        public VM_Employee GetEmployeeById(int employeeid)
        {
            var employees = context.Employee.Where(x => x.Id == employeeid).Select(
               x =>
               new VM_Employee()
               {
                   Email = x.Email,
                   Id = x.Id,
                   Name = x.Name,
                   Phone = x.Phone
               }
               ).FirstOrDefault();
            return employees;
        }


    }
}
