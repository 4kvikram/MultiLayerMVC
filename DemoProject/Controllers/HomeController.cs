using DemoProject.BAL.Interface;
using DemoProject.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employee;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employee)
        {
            _logger = logger;
            _employee = employee;
        }

        public IActionResult Index()
        {
            var employee = _employee.GetAllEmployee();
            return View(employee);
        }

        [HttpGet]
        public IActionResult AddEmployee(int id = 0)
        {
            VM_Employee model = new VM_Employee();
            if (id > 0)
            {
                model = _employee.GetEmployeeById(id);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult AddEmployee(VM_Employee model)
        {
            if (model.Id > 0)
            {
                var result = _employee.UpdateEmployee(model);
            }
            else
            {
                var result = _employee.AddEmployee(model);
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult DeleteEmployee(int id = 0)
        {
            if (id > 0)
            {
                var result = _employee.DeleteEmployee(id);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
