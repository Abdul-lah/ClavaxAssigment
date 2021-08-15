using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clavax.Utility.Dto
{/// <summary>
/// it is for seprate to make data transfer object
/// </summary>
    public class EmployeeViewDto
    {  
        public List<EmployeeDto> Employee { get; set; }
       
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EmployeeDob { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public bool IsDelete { get; set; }
    }
}
