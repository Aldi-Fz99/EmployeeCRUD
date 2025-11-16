using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeCRUD.Models;

namespace EmployeeCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository repo = new EmployeeRepository();

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // Get: Get All Employees
        public JsonResult GetAll()
        {
            var data = repo.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        // POST: Add Employee
        [HttpPost]
        public JsonResult Add(Employee emp)
        {
            bool result = repo.Add(emp);
            return Json(result);
            
        }
        // GET: Employee Get By Id
        public JsonResult GetById(int id) 
        {
            var emp = repo.GetById(id);
            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        // POST: Employee Update
        [HttpPost]
        public JsonResult Update(Employee emp)
        {
            bool result = repo.Update(emp);
            return Json(result);
        }

        // POST: Employee/Delete
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = repo.Delete(id);
            return Json(new { success = result });
        }

    }
}