using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetSSMSConnection.Models;
using AspNetSSMSConnection.ViewModel;

namespace AspNetSSMSConnection.Controllers
{
    // Test projekt för att koppla sql databas från ssms till MVC projekt
    public class HomeController : Controller
    {
        TestMVCConnectDatabaseEntities db = new TestMVCConnectDatabaseEntities();

        public HomeController()
        {
            db = new TestMVCConnectDatabaseEntities();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        public ActionResult Index()
        {
            var employees = db.Employees.ToList();

            return View(employees);
        }


        public ActionResult Delete(int id)
        {
            var employee = db.Employees.SingleOrDefault(e => e.ID == id);

            db.Employees.Remove(employee);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            var viewModel = new EmployeeViewModel
            {
                Employee = new Employee()
            };

            return View("EmployeeForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var employee = db.Employees.SingleOrDefault(e => e.ID == id);

            if (employee == null)
            {
                return HttpNotFound("Employee not found!");
            }

            var viewModel = new EmployeeViewModel
            {
                Employee = employee
            };

            return View("EmployeeForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Employee employee)
        {
            int currentEmployeeId = 1;

            if (employee.ID == 0)
            {
                if (db.Employees.Count() > 0)
                {
                    currentEmployeeId = db.Employees.Max(e => e.ID) + 1;

                    employee = new Employee
                    {
                        ID = currentEmployeeId,
                        EmployeeFullName = employee.EmployeeFullName,
                        EmployeeSalary = employee.EmployeeSalary,
                        EmployeeBirthDate = employee.EmployeeBirthDate
                    };

                    db.Employees.Add(employee);
                }

                else
                {
                    employee = new Employee
                    {
                        ID = currentEmployeeId,
                        EmployeeFullName = employee.EmployeeFullName,
                        EmployeeSalary = employee.EmployeeSalary,
                        EmployeeBirthDate = employee.EmployeeBirthDate
                    };

                    db.Employees.Add(employee);
                }
            }

            else
            {
                var employeeInDb = db.Employees.Single(e => e.ID == employee.ID);

                employeeInDb.EmployeeFullName = employee.EmployeeFullName;
                employeeInDb.EmployeeSalary = employee.EmployeeSalary;
                employeeInDb.EmployeeBirthDate = employee.EmployeeBirthDate;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}