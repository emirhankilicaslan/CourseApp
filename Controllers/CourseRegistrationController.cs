using CourseApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Controllers
{
    public class CourseRegistrationController : Controller
    {
        private readonly DataContext _context;

        public CourseRegistrationController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var courseRegistrations = await _context.CourseRegistrations.Include(x => x.Student).Include(x => x.Course).ToListAsync();
            return View(courseRegistrations);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Students = new SelectList(await _context.Students.ToListAsync(), "StudentId", "NameSurname");
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId", "CourseName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseRegistration courseRegistration)
        {
            courseRegistration.RegistrationDate = DateTime.Now;
            _context.CourseRegistrations.Add(courseRegistration);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}