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
}   
