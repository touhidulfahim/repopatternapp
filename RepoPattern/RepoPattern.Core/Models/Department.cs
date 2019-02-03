using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern.Core.Models
{
   public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [StringLength(50)]
        public string DepartmentName { get; set; }

    }
}
