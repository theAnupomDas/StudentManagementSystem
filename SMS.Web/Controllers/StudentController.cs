using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.DataAccess;
using SMS.Models.Entities;

using SMS.Service.Contracts;

namespace SMS.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewAllStudents()
        {
            var students =await _studentService.GetAllStudentsAsync();
            return View(students);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentEntity student)
        {
           
            if(ModelState.IsValid)
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
        public async Task<IActionResult> Update(StudentEntity student)
        {
            student.ModifiedBy = "random";
            student.ModifiedAt = DateTime.Now;
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
        public async Task<IActionResult> ConfirmDelete (int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        public async Task<IActionResult> Delete (int id)
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