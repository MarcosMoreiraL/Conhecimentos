using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> departmentList = new List<Department>();
            departmentList.Add(new Department { Id = 1, Name = "Department1" });
            departmentList.Add(new Department { Id = 2, Name = "Department2" });
            departmentList.Add(new Department { Id = 3, Name = "Department3" });

            return View(departmentList);
        }
    }
}
