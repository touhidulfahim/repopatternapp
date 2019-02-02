using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using Dapper;
using RepoPattern.Core.Interface;
using RepoPattern.Core.Models;
using RepoPattern.Infrastructure.Gateway;

namespace RepoPattern.Infrastructure.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly PatternDbContext _context;
        private bool _disposed = false;

        public EmployeeRepository()
        {
            _context=new PatternDbContext();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        
        public IEnumerable<EmployeeModels> GetAllEmployee()
        {
            try
            {
                return _context.Employees.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<EmployeeModels> ShowAllEmployee(string search)
        {
            try
            {
                var employee = (from e in _context.Employees select e);

                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                //{
                //    employee = employee.OrderBy(sortColumn + "" + sortColumnDir);
                //}
                if (!string.IsNullOrEmpty(search))
                {
                    employee = employee.Where(e =>
                                                e.EmployeeName.Contains(search) || 
                                                e.Email.Contains(search) || 
                                                e.Phone.Contains(search));
                }
                

                return employee;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public EmployeeModels GetEmployeeById(int? empId)
        {
            try
            {
                return _context.Employees.Find(empId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int? AddEmployee(EmployeeModels employeeModels)
        {
            try
            {
                int? result = -1;

                if (employeeModels != null)
                {
                    _context.Employees.Add(employeeModels);
                    _context.SaveChanges();
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int? UpdateEmployee(EmployeeModels employeeModels)
        {
            try
            {
                int? emp = -1;
                if (employeeModels !=null)
                {
                    _context.Entry(employeeModels).State = EntityState.Modified;
                    _context.SaveChanges();
                }

                return emp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveEmployee(int? empId)
        {
            try
            {
                EmployeeModels employeeModels = _context.Employees.Find(empId);
                if (employeeModels != null) _context.Employees.Remove(employeeModels);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
