using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clavax.Models;
using Clavax.Utility.IRepositry;
using Clavax.Utility.Dto;

namespace Clavax.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployee _employee;
        public HomeController(IEmployee employee)
        {
            _employee = employee;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetEmployees(int? Id)
        {
            
            var result = _employee.GetEmployees(Id ?? 1);
            var data = result.value as EmployeeViewDto;
            EmployeeViewModel model = new EmployeeViewModel
            {
                CurrentPageIndex = data.CurrentPageIndex,
                Employee = data.Employee.Select(s => new EmployeeModel
                {
                    Address = s.Address,
                    EmployeeDob = s.EmployeeDob,
                    EmployeeId = s.EmployeeId,
                    EmployeeName = s.EmployeeName,
                    Gender = s.Gender,
                    Id = s.Id,
                    State = s.State
                }).ToList(),
                PageCount = data.PageCount
            };

            return View(model);
        }
       
        [HttpGet]
        public IActionResult AddEmployee()
        {
            ViewBag.States = GetStates();
            ViewBag.result = null;
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel model)
        {
            ViewBag.States = GetStates();
            if (ModelState.IsValid)
            {
                IGernalResult result = new GernalResult();
                result = _employee.AddEmployee(new EmployeeDto
                {
                    EmployeeDob = model.EmployeeDob,
                    EmployeeName = model.EmployeeName,
                    Address = model.Address,
                    Gender = model.Gender,
                    EmployeeId = model.EmployeeId,
                    State = model.State
                });

                ViewBag.result = result;
            }
            return View();
        }
        /// <summary>
        /// here i am not using it dynamically from table 
        /// </summary>
        /// <returns></returns>
        public List<StateViewModel> GetStates()
        {
            return new List<StateViewModel>
            {
                new StateViewModel{Id="Delhi",State="Delhi"},
                new StateViewModel{Id="UP",State="UP"},
                new StateViewModel{Id="PUNJAB",State="PUNJAB"},
                new StateViewModel{Id="HARYANA",State="HARYANA"},
            };
        }
        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            ViewBag.States = GetStates();
            var result = _employee.GetEmployee(id);
            var data = result.value as EmployeeDto;
            EmployeeModel model = new EmployeeModel
            {

                Address = data.Address,
                EmployeeDob = data.EmployeeDob,
                EmployeeId = data.EmployeeId,
                EmployeeName = data.EmployeeName,
                Gender = data.Gender,
                Id = data.Id,
                State = data.State
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult EditEmployee(EmployeeModel model)
        {
            ViewBag.States = GetStates();
            var result = _employee.EditEmployee(new EmployeeDto
            {
                Address = model.Address,
                EmployeeDob = model.EmployeeDob,
                EmployeeId = model.EmployeeId,
                EmployeeName = model.EmployeeName,
                Gender = model.Gender,
                Id = model.Id,
                State = model.State
            });
            ViewBag.result = result;
            return View();
        }
        [HttpPost]
        public IActionResult DeleteEmployee(int Id)
        {
            ///here i am usind soft delete
            var result = _employee.DeleteEmployee(Id);
            return Json(result.Message.ToString());
        }
        /// <summary>
        /// It is USer for remote validation but i am not using it i will solve it using logic on add time
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmployeeId(string employeeId)
        {
            if (_employee.verifyEmployeeid(employeeId))
            {
                return Json(data: "please eneter anoter employee id this is already exist");
            }
            else
            {

                return Json(true);
            }
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
