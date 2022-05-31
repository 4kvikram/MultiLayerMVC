using DemoProject.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.BAL.Interface
{
    public interface IEmployeeRepository
    {
        bool AddEmployee(VM_Employee model);
        bool UpdateEmployee(VM_Employee model);
        bool DeleteEmployee(int employeeid);
        VM_Employee GetEmployeeById(int employeeid);
        List<VM_Employee> GetAllEmployee();
    }
}
