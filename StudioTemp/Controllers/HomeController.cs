using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioTemp.DAL;
using StudioTemp.Models;
//using StudioTemp.Models;
using System.Diagnostics;

namespace StudioTemp.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async  Task<IActionResult> Index()
        {   List<Employee> employees = await _context.Employees.Include(p=>p.Team).ToListAsync();   
            return View(employees);
        }

       
    }
}