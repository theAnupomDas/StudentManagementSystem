using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMS.DataAccess;
using SMS.Models.Entities;

using SMS.Service.Contracts;

namespace SMS.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;

        public StudentController(IStudentService studentService, IDepartmentService departmentService)
        {
            _studentService = studentService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return View(students);
        }
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            ViewBag.Departments = new SelectList(
        departments,
        "Id",
        "Name"
        );
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            var department = await _departmentService.GetDepartmentAsync(student.DepartmentId);
            student.Department = department;
            ModelState.Remove(nameof(student.Department));
            //if (!ModelState.IsValid)
            //{
            //    foreach (var item in ModelState)
            //    {
            //        var key = item.Key;
            //        var errors = item.Value.Errors;

            //        foreach (var error in errors)
            //        {
            //            Console.WriteLine(
            //                $"Property: {key}, Error: {error.ErrorMessage}"
            //            );
            //        }
            //    }
            //}

            if (ModelState.IsValid)
            {
                var isCreated = await _studentService.CreateStudentAsync(student);
                if (isCreated)
                {
                    return RedirectToAction("ViewAllStudents");
                }
            }
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Student student)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _studentService.UpdateStudentAsync(student);
                if (isUpdated)
                {
                    return RedirectToAction("ViewAllStudents");
                }
            }
            return View(student);
        }
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _studentService.DeleteStudentAsync(id);
                if (!isDeleted)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting student: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            return RedirectToAction("ViewAllStudents");
        }
    }

}