using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CourseApp.Models;
using CourseApp.Data;
using Microsoft.EntityFrameworkCore;


namespace CourseApp.Controllers;

public class StudentController : Controller
{
    private readonly DataContext _context;

    public StudentController(DataContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.Students.ToListAsync());
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Edit(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }
        var student = await _context.Students.Include(x => x.CourseRegistrations).ThenInclude(x => x.Course).FirstOrDefaultAsync(x => x.StudentId == id);

        if(student == null)
        {
            return NotFound();
        }
        return View(student);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Student student)
    {
        if (id != student.StudentId)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!_context.Students.Any(stu => stu.StudentId == student.StudentId))
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
        return View(student);
    }

    public async Task<IActionResult> Delete (int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var student = await _context.Students.FindAsync(id);

        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] int id)
    {
        var student = await _context.Students.FindAsync(id);
        if(student == null)
        {
            return NotFound();
        }
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}   
