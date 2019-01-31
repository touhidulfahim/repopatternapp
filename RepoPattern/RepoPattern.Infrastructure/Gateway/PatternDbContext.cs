using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Data.Entity;
using RepoPattern.Core.Models;
namespace RepoPattern.Infrastructure.Gateway
{
    public class PatternDbContext:DbContext
    {
        public PatternDbContext():base("DbConnection")
        {
            
        }

        public DbSet<EmployeeModels> Employees { get; set; }

    }
}
