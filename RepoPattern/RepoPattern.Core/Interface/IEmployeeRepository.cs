using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoPattern.Core.Models;

namespace RepoPattern.Core.Interface
{
    public interface IEmployeeRepository:IDisposable
    {
        IEnumerable<EmployeeModels> GetAllEmployee();
        IQueryable<EmployeeModels> ShowAllEmployee(string search);
        int? AddEmployee(EmployeeModels employeeModels);
        int? UpdateEmployee(EmployeeModels employeeModels);
        void RemoveEmployee(int? empId);
        EmployeeModels GetEmployeeById(int? empId);

    }
}
