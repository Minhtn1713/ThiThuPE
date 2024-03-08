using Microsoft.AspNetCore.Mvc;
using Q3.Models;

namespace Q3.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult List()
        {
            List<Employee> list = new List<Employee>();
            using var context = new PeFall21B5Context();
            list = context.Employees.ToList();
            ViewBag.emp = list;
            return View("List");
        }

        public ActionResult Remove(int id)
        {
            using var context = new PeFall21B5Context();
            Employee emp = context.Employees.Find(id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            List<Employee> list = new List<Employee>();
            list = context.Employees.ToList();
            ViewBag.emp = list;
            return View("List");
        }
    }
}
