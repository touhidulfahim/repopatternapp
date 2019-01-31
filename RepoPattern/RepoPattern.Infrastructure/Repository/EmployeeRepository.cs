using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoPattern.Core.Interface;
using RepoPattern.Core.Models;

namespace RepoPattern.Infrastructure.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeModels> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public IQueryable<EmployeeModels> ShowEmployee(string search, string sortColumn, string columnDir)
        {
            throw new NotImplementedException();
        }

        public int? AddEmployee(EmployeeModels employeeModels)
        {
            throw new NotImplementedException();
        }

        public int? UpdateEmployee(EmployeeModels employeeModels)
        {
            throw new NotImplementedException();
        }

        public int? RemoveEmployee(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
