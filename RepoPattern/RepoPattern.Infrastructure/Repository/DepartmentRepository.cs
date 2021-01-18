using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using RepoPattern.Core.Interface;
using RepoPattern.Core.Models;
using RepoPattern.Infrastructure.Gateway;

namespace RepoPattern.Infrastructure.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly PatternDbContext _context;
        private bool _disposed = false;

        public DepartmentRepository(PatternDbContext context)
        {
            _context = context;
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

        public IEnumerable<Department> GetAllDepartment()
        {
            try
            {
                return _context.Departments.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public List<Department> GetDepartmentList()
        {

            List<Department> departmentList = _context.Departments.ToList();
            return departmentList;

        }
    }
}
