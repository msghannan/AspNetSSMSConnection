using AspNetSSMSConnection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AspNetSSMSConnection.Controllers.API
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : ApiController
    {
        private TestMVCConnectDatabaseEntities db;

        public EmployeeController()
        {
            db = new TestMVCConnectDatabaseEntities();
        }

        //GET /API/Employee/GetAllEmployees
        [HttpGet]
        [Route("API/Employee/GetAllEmployees/")]
        public IHttpActionResult GetAllEmployees()
        {
            var allEmployees = db.Employees.ToList();
            return Ok(allEmployees);
        }

        //GET /API/Employee/GetEmployee/id
        [HttpGet]
        [Route("API/Employee/GetEmployee/{id}")]
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = db.Employees.SingleOrDefault(e => e.ID == id);
            return Ok(employee);
        }

        //POST /API/Employee/AddEmployee
        [HttpPost]
        public IHttpActionResult AddEmployee(Employee employee)
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

            return Ok("Employee has been added");
        }

        //POST /API/Employee/EditEmployee/id
        [HttpPost]
        [Route("API/Employee/EditEmployee/{id}")]
        public IHttpActionResult EditEmployee(int id, Employee employee)
        {
            var employeeInDb = db.Employees.Single(e => e.ID == id);

            if (employeeInDb == null)
            {
                return NotFound();
            }

            else
            {
                employeeInDb.EmployeeFullName = employee.EmployeeFullName;
                employeeInDb.EmployeeSalary = employee.EmployeeSalary;
                employeeInDb.EmployeeBirthDate = employee.EmployeeBirthDate;
            }

            db.SaveChanges();
            return Ok("Employee has beed updated!");
        }
    }
}
