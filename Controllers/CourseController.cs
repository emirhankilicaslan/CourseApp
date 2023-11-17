using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Data
{
    public class CourseController : Controller
    {
        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.Include(i => i.Instructor).ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Instructors = new SelectList(await _context.Instructors.ToListAsync(), "InstructorId", "NameSurname");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.
                                                Include(s => s.CourseRegistrations).
                                                ThenInclude(s => s.Student).
                                                Select(s => new CourseViewModel()
                                                {
                                                    CourseId = s.CourseId,
                                                    CourseName = s.CourseName,
                                                    InstructorId = s.InstructorId,
                                                    CourseRegistrations = s.CourseRegistrations
                                                }).
                                                FirstOrDefaultAsync(s => s.CourseId == id);

            if(course == null)
            {
                return NotFound();
            }
            ViewBag.Instructors = new SelectList(await _context.Instructors.ToListAsync(), "InstructorId", "NameSurname");
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CourseViewModel course, int id)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(new Course(){CourseId = course.CourseId, CourseName = course.CourseName, InstructorId = course.InstructorId});
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!_context.Courses.Any(c => c.CourseId == course.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(course);
        }
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if(course == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}