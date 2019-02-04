using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
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
            var departmentList=new List<Department>();
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

        [HttpGet]
        public ActionResult EditEmployee(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                EmployeeModels employeeModels = _iEmployeeRepository.GetEmployeeById(id);
                if (employeeModels == null)
                {
                    return HttpNotFound();
                }
                return View(employeeModels);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(EmployeeModels employeeModels)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _iEmployeeRepository.UpdateEmployee(employeeModels);
                    return RedirectToAction("Index");
                }
                return View(employeeModels);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: MenuMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                EmployeeModels emloyeeModels = _iEmployeeRepository.GetEmployeeById(id);
                if (emloyeeModels == null)
                {
                    return HttpNotFound();
                }
                return View(emloyeeModels);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: MenuMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _iEmployeeRepository.RemoveEmployee(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}