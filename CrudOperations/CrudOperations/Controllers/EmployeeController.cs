using CrudOperations.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperations.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;
        public EmployeeController(EmployeeContext context)
        { 
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddEmployee(Employee employee)
        {
            _context.Employee.Add(employee); 
            _context.SaveChanges();
            return new JsonResult("data is saved succesfully");
        }

        [HttpGet]
        public JsonResult GetEmployee()
        {
            var employeesList = _context.Employee.ToList();
            return Json(employeesList);
        }

        public JsonResult Edit(int id)
        {
           var result =  _context.Employee.Find(id);
            if(result !=  null)
            {
                return Json(result);
            }
            else return Json(null);
        }

        [HttpPost]
        public JsonResult UpdateEmployee(Employee employee)
        {
            _context.Employee.Update(employee);
            _context.SaveChanges();
            return new JsonResult("Updated successfully");
        }
        [HttpDelete]
        public JsonResult DeleteEmployee(int id)
        {
            var result = _context.Employee.Find(id);
            if (result != null)
            {
                _context.Employee.Remove(result);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            else return Json(null);
        }

    }
}
