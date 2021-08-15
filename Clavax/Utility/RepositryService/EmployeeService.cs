using Clavax.DAL;
using Clavax.Utility.Dto;
using Clavax.Utility.IRepositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clavax.Utility.RepositryService
{
    public class EmployeeService : IEmployee
    {
        private readonly DrNaazdbContext _context;
        public EmployeeService(DrNaazdbContext context)
        {
            _context = context;
        }
        public IGernalResult AddEmployee(EmployeeDto dto)
        {
            IGernalResult result = new GernalResult();
            try
            {
                bool isexist = _context.TblEmployee.Where(w => w.EmployeeId == dto.EmployeeId && w.IsDelete==false).Any();
                if (!isexist)
                {
                    TblEmployee employee = new TblEmployee
                    {
                        EmployeeDob = dto.EmployeeDob,
                        EmployeeName = dto.EmployeeName,
                        Gender = dto.Gender,
                        Address = dto.Address,
                        State = dto.State==null?"Na":dto.State,
                        IsDelete = false,
                        EmployeeId=dto.EmployeeId
                    };
                    _context.Add(employee);
                    int save = _context.SaveChanges();
                    result.Message = save > 0 ? "Employee added" : "Employee did not add";
                    result.Succsefully = save > 0 ? true : false;
                }
                else
                {
                    result.Message = "Employee alrady added with this Employee Id:-"+dto.EmployeeId;
                    result.Succsefully = false;
                }
            }
            catch
            {
                result.Succsefully = false;
                result.Message = "server error";
            }
            return result;
        }

        /// <summary>
        /// here i am using sot delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IGernalResult DeleteEmployee(int id)
        {
            IGernalResult result = new GernalResult();
            try
            {
                TblEmployee employee = _context.TblEmployee.Where(w => w.Id == id).FirstOrDefault();
                if (employee!=null)
                {
                    employee.IsDelete = true;                   
                    int save = _context.SaveChanges();
                    result.Message = save > 0 ? "Employee deleted" : "Employee did not delete";
                    result.Succsefully = save > 0 ? true : false;
                }
                else
                {
                    result.Message = "Employee did not add";
                    result.Succsefully = false;
                }
            }
            catch
            {
                result.Succsefully = false;
                result.Message = "server error";
            }
            return result;
        }
        /// <summary>
        /// this is code for hard delete permanently from table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IGernalResult DeleteEmployeeHard(int id)
        {
            IGernalResult result = new GernalResult();
            try
            {
                TblEmployee employee = _context.TblEmployee.Where(w => w.Id == id).FirstOrDefault();
                if (employee != null)
                {
                    _context.Remove(employee);
                    int save = _context.SaveChanges();
                    result.Message = save > 0 ? "Employee deleted" : "Employee did not delete";
                    result.Succsefully = save > 0 ? true : false;
                }
                else
                {
                    result.Message = "Employee did not add";
                    result.Succsefully = false;
                }
            }
            catch
            {
                result.Succsefully = false;
                result.Message = "server error";
            }
            return result;
        }

        public IGernalResult EditEmployee(EmployeeDto dto)
        {
            IGernalResult result = new GernalResult();
            try
            {
                TblEmployee employee = _context.TblEmployee.Where(w => w.Id == dto.Id ).FirstOrDefault();
                bool isexist = _context.TblEmployee.Where(w => w.Id !=dto.Id && w.EmployeeId==dto.EmployeeId).Any();
                if (employee != null)
                {
                    if (!isexist)
                    {
                        employee.EmployeeDob = dto.EmployeeDob;
                        employee.EmployeeName = dto.EmployeeName;
                        employee.Gender = dto.Gender;
                        employee.Address = dto.Address;
                        employee.State = dto.State;
                        int save = _context.SaveChanges();
                        result.Message = save > 0 ? "Employee updated" : "Employee did not update no change made";
                        result.Succsefully = save > 0 ? true : false;
                    }
                    else
                    {
                        result.Message =  "Employee id:-("+dto.EmployeeId+") alrady exist";
                        result.Succsefully = false;
                    }
                }
                else
                {
                    result.Message = "Employee not found";
                    result.Succsefully = false;
                }
            }
            catch
            {
                result.Succsefully = false;
                result.Message = "server error";
            }
            return result;
        }


        public IGernalResult GetEmployee(int id)
        {
            IGernalResult result = new GernalResult();
            try
            {
                bool isexist = _context.TblEmployee.Where(w => w.Id ==id).Any();
                if (isexist)
                {
                    result.value = _context.TblEmployee.Select(s=>new EmployeeDto
                    {
                        Address = s.Address,
                        EmployeeDob = s.EmployeeDob,
                        EmployeeId = s.EmployeeId,
                        EmployeeName = s.EmployeeName,
                        Gender = s.Gender,
                        Id = s.Id,
                        State = s.State
                    }).Where(w => w.Id == id).FirstOrDefault();
                }
                else
                {
                    result.Succsefully = false;
                    result.Message = "employee did not found";
                }
            }
            catch
            {
                result.Succsefully = false;
                result.Message = "server error";
            }
            return result;
        }


        public IGernalResult GetEmployees(int currentpage)
        {
            IGernalResult result = new GernalResult();
            try
            {
                int maxRows = 10;
                EmployeeViewDto employeeDto = new EmployeeViewDto();

                employeeDto.Employee = _context.TblEmployee.Select(s => new EmployeeDto
                {
                    Address = s.Address,
                    EmployeeDob = s.EmployeeDob,
                    EmployeeId = s.EmployeeId,
                    EmployeeName = s.EmployeeName,
                    Gender = s.Gender,
                    Id = s.Id,
                    State = s.State,
                    IsDelete=s.IsDelete??true
                }).Where(w=>w.IsDelete==false).OrderBy(o => o.Id).Skip((currentpage - 1) * maxRows).Take(maxRows).ToList();

                double pageCount = (double)((decimal)_context.TblEmployee.Where(w => w.IsDelete == false).Count() / Convert.ToDecimal(maxRows));
                employeeDto.PageCount = (int)Math.Ceiling(pageCount);

                employeeDto.CurrentPageIndex = currentpage;

                result.value = employeeDto;
               
            }
            catch
            {
                result.Succsefully = false;
                result.Message = "server eroor";
            }
            return result;
        }

        public bool verifyEmployeeid(string Employeeid)
        {
            return _context.TblEmployee.Where(w => w.EmployeeId == Employeeid && w.IsDelete == false).Any();
        }
    }
}
