using Microsoft.AspNetCore.Mvc;
using SMS.Models.Entities;
using SMS.Service.Contracts;

namespace SMS.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartmentsAsync(); 
            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var isCreated = await _departmentService.CreateDepartmentAsync(department);
                if (isCreated)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

    }
}
