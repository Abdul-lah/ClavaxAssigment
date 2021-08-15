using Clavax.Utility.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clavax.Utility.IRepositry
{
    public interface IEmployee
    {
        bool verifyEmployeeid(string Employeeid);
        IGernalResult AddEmployee(EmployeeDto dto);
        IGernalResult GetEmployees(int currentpage);
        IGernalResult GetEmployee(int id);
        IGernalResult EditEmployee(EmployeeDto dto);
        IGernalResult DeleteEmployee(int id);
        IGernalResult DeleteEmployeeHard(int id);
    }
}
