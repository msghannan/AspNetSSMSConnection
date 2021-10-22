using AspNetSSMSConnection.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetSSMSConnection.ViewModel
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }

        [Display(Name = "Employee fullname")]
        public string EmployeeFullName { get; set; }

        [Display(Name = "Employee salary")]
        public Nullable<double> EmployeeSalary { get; set; }

        [Display(Name = "Employee birthdate")]
        public Nullable<System.DateTime> EmployeeBirthDate { get; set; }

        public EmployeeViewModel()
        {

        }

        public EmployeeViewModel(Employee employee)
        {
            ID = employee.ID;
            EmployeeFullName = employee.EmployeeFullName;
            EmployeeSalary = employee.EmployeeSalary;
            EmployeeBirthDate = employee.EmployeeBirthDate;
        }
    }
}