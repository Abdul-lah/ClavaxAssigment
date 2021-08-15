using System;
using System.Collections.Generic;

namespace Clavax.DAL
{
    public partial class TblEmployee
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EmployeeDob { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public bool? IsDelete { get; set; }
    }
}
