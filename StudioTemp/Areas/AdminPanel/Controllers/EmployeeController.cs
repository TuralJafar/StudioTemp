using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using StudioTemp.DAL;
using StudioTemp.Models;

namespace StudioTemp.Areas.AdminPanel.Controllers
{
    [Area("Adminpanel")]
    public class EmployeeController : Controller
    {   private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {   List<Employee>employees=await _context.Employees.Include(p=>p.Team).ToListAsync();
            return View(employees);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Teams = await _context.Teams.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(Employee employee)
        {   bool result = await _context.Teams.AnyAsync(p=>p.Id == employee.TeamId);
            if (!result)
            {
                ModelState.AddModelError("TeamId", "there no team with this id");
                ViewBag.Teams=await _context.Teams.ToListAsync();
                return View();
            }
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            
            
        }
        public async  Task<IActionResult> Update(int? id)
        {   if (id == null) return BadRequest();
        Employee existed=await _context.Employees.FirstOrDefaultAsync(p=>p.Id == id);
            if (existed == null)
            {
                return NotFound();
            }
           
           
                ViewBag.Teams = await _context.Teams.ToListAsync();
                return View(existed);
 
        }
        [HttpPost]
        public async Task<IActionResult>Update(int? id, Employee employee)
        {
            if (id == null) return BadRequest();
            Employee existed = await _context.Employees.FirstOrDefaultAsync(p => p.Id == id);
            if (existed == null) return NotFound();
            if (!ModelState.IsValid)
            {
                ViewBag.Teams=await _context.Teams.ToListAsync();
                return View(existed);
            }
            if (existed.TeamId != employee.TeamId)
            {
                bool result = await _context.Teams.AnyAsync(p=>p.Id==employee.TeamId);
                if(!result) 
                {
                    ModelState.AddModelError("TeamID", "Not found");
                    ViewBag.Teams = await _context.Teams.ToListAsync();
                    return View(existed);
                }
                existed.TeamId = employee.TeamId;
                
            }
            existed.Name = employee.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async  Task<IActionResult> Delete(int? id)
        {   if(id==null||id<1) return BadRequest();
            Employee employee=await _context.Employees.FirstOrDefaultAsync(p=>p.Id== id);
            if (employee == null) return NotFound();
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
