using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoPattern.Core.Interface;
using RepoPattern.Infrastructure.Repository;

namespace RepoPatternApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _iDepartmentRepository;

        public DepartmentController(IDepartmentRepository iDepartmentRepository)
        {
            _iDepartmentRepository = iDepartmentRepository;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoadDepartment()
        {  
            try
            {
                int recordsTotal = 0;

                var department = _iDepartmentRepository.GetAllDepartment();
                recordsTotal = department.Count();
                var data = department.ToList();
                return Json(new { recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}