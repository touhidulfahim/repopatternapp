using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using Dapper;
using System.Web.Mvc;
using RepoPattern.Core.Interface;
using RepoPattern.Core.Models;
using RepoPattern.Infrastructure.Repository;

namespace RepoPatternApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _iEmployeeRepository;

        public EmployeeController()
        {
            _iEmployeeRepository = new EmployeeRepository();
        }
        public ActionResult Index()
        {
            var employeeList = _iEmployeeRepository.GetAllEmployee();
            return View(employeeList);
        }

        public ActionResult LoadEmployee()
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;

                int recordsTotal = 0;

                var employeeData = _iEmployeeRepository.ShowAllEmployee(searchValue);
                recordsTotal = employeeData.Count();
                var data = employeeData.ToList();
                return Json(new {recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult SaveEmployee()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEmployee(EmployeeModels employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _iEmployeeRepository.AddEmployee(employee);
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}