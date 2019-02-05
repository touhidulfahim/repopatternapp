using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoPattern.Core.Models;

namespace RepoPattern.Core.Interface
{
    public interface IDepartmentRepository:IDisposable
    {
        IEnumerable<Department> GetAllDepartment();
        List<Department> GetDepartmentList();
    }
}
