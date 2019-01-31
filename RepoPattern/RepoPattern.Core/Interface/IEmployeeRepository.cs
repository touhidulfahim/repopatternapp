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
        IQueryable<EmployeeModels> ShowEmployee(string search, string sortColumn, string columnDir);
        int? AddEmployee(EmployeeModels employeeModels);
        int? UpdateEmployee(EmployeeModels employeeModels);
        int? RemoveEmployee(int? id);

    }
}
