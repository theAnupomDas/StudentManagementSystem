using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.DataAccess;
using SMS.Models.Entities;

namespace SMS.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewAllStudents()
        {
            var students = await _dbContext.Students.ToListAsync();
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
                await _dbContext.Students.AddAsync(student);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("ViewAllStudents");

            }
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
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
                _dbContext.Students.Update(student);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("ViewAllStudents");
            }
            return View(student);
        }
    }

}