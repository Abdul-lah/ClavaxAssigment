using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clavax.Models
{

    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class EmployeeViewModel
    {
        public List<EmployeeModel> Employee { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Employee Id")]
        //here how we can use remote validation
        //[Remote(action: "VerifyEmployeeId", controller: "Home")]
        public string EmployeeId { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Employee DOB")]
        public DateTime EmployeeDob { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        public string State { get; set; }
      
    }
    public class StateViewModel
    {
        public string Id { get; set; }
        public string State { get; set; }
    }
}