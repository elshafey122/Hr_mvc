using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc2.Models;
using mvclab2.Models;
using mvclab2.ViewModel;

namespace mvclab2.Controllers
{
    public class OfficeController : Controller
    {
        ApplicationDbContext _context;
        public OfficeController()
        {
            _context = new ApplicationDbContext();
        }
        public async Task<IActionResult> Index()
        {
            var offices = await _context.offices.ToListAsync();
            return View(offices);
        }
        public async Task<IActionResult> GetById(int id)
        {
            var office = await _context.offices.Include(x=>x.employees).SingleOrDefaultAsync(x => x.Id == id);
            if(office == null)
            {
                return NotFound();
            }
            var employees = office.employees;
            var res = new OfficeViewModel()
            {
                Location = office.Location,
                Name = office.Name,
                employees = employees
            };
            return View(res);
        }

        public async Task<IActionResult> AddOffice()
        {
            var res = new OfficeViewModel();
            return View("OfficeForm",res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOffice(OfficeViewModel office)
        {
            var result = new Office()
            {
                Name = office.Name,
                Location = office.Location,
            };
            await _context.offices.AddAsync(result);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> edit(int id)
        {
            var office = await _context.offices.SingleOrDefaultAsync(x => x.Id == id);
            if (office == null)
            {
                return NotFound();
            }
            var viewoffice = new OfficeViewModel()
            {
                Id = office.Id,
                Location = office.Location,
                Name=office.Name,
            };
            return View("OfficeForm", viewoffice); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> edit(OfficeViewModel office)
        {
            if(office.Id==null)
            {
                return BadRequest();
            }
            var res = await _context.offices.SingleOrDefaultAsync(x => x.Id == office.Id);
            if (office == null)
            {
                return NotFound();
            }
            res.Name = office.Name;
            res.Location = office.Location;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> delete(int id)
        {
            var office = await _context.offices.SingleOrDefaultAsync(x => x.Id == id);
            if (office == null)
            {
                return NotFound();
            }
            _context.offices.Remove(office);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
