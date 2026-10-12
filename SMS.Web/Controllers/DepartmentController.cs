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
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
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



        public async Task<IActionResult> Update(int id)
        {
            var department = await _departmentService.GetDepartmentAsync(id);
            if (department == null)
            {
                return NotFound();
    }
            return View(department);
}
        [HttpPost]
        public async Task<IActionResult> Update(Department department)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _departmentService.UpdateDepartmentAsync(department);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(department);
        }
    }

}

    
