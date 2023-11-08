using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Data
{
    public class CourseController : Controller
    {
        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            _context = context;
        }
        
    }
}