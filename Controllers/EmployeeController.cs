using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc2.Models;
using mvclab2.Models;
using mvclab2.ViewModel;

namespace mvc2.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext _context;
        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        public async Task<IActionResult>Index()
        {    
            var res = await _context.employees.Include(x=>x.office).ToListAsync();
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> details(int id)
        {
            var res = await _context.employees.Include(x=>x.office).SingleOrDefaultAsync(x => x.Id == id);
            if (res == null)
            {
                return Content("not found");
            }
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            var offices = await _context.offices.ToListAsync();
            var viewmodel = new EmployeeViewModel();
            ViewBag.Offices = new SelectList(offices, "Id", "Name");
            return View("EmployeeForm",viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel emp)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Name = emp.Name,
                    Age = emp.Age,
                    Salary = emp.Salary,
                    Email = emp.Email,
                    Password = emp.Password,
                    OfficeId = emp.OfficeId,
                };
                _context.employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpGet]
        public async Task<IActionResult> edit(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            List<Office> offices = await _context.offices.ToListAsync();
            //ViewBag.Offices = offices;
            ViewBag.Offices = new SelectList(offices, "Id", "Name");
            
            var res = await _context.employees.Include(x=>x.office).SingleOrDefaultAsync(x => x.Id == id);
            if (res == null)
            {
                return NotFound();
            }

            var editemployee = new EmployeeViewModel()
            {
                Age = res.Age,
                Email = res.Email,
                Name = res.Name,
                Salary = res.Salary,
                Id=res.Id,
                OfficeId=res.OfficeId,
            };
            return View("EmployeeForm", editemployee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> edit(EmployeeViewModel emp)
        {
            if (emp.Id == null)
            {
                return BadRequest();
            }
            var res = await _context.employees.Include(x=>x.office).SingleOrDefaultAsync(x => x.Id == emp.Id);
            
            res.Email = emp.Email;
            res.Age = emp.Age;
            res.Name = emp.Name;
            res.Salary = emp.Salary;
            res.OfficeId = emp.OfficeId;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> delete(int id)
        {
            var res = await _context.employees.SingleOrDefaultAsync(x => x.Id == id);
            if (res == null)
            {
                return Content("not found");
            }
            _context.employees.Remove(res);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
