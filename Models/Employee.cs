//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspNetSSMSConnection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Employee fullname")]
        public string EmployeeFullName { get; set; }

        [Display(Name = "Employee salary")]
        public Nullable<double> EmployeeSalary { get; set; }

        [Display(Name = "Employee birthdate")]
        public Nullable<System.DateTime> EmployeeBirthDate { get; set; }
    }
}
