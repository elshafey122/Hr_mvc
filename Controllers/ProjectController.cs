using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc2.Models;
using mvclab2.Models;
using mvclab2.ViewModel;

namespace mvclab2.Controllers
{
    public class ProjectController : Controller
    {
        ApplicationDbContext _context;
        public ProjectController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var project = await _context.projects.ToListAsync();
            return View(project);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _context.projects.SingleOrDefaultAsync(x => x.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            var res = new ProjectViewModel()
            {
                Description= project.Description,
                Name = project.Name,
            };
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> AddProject()
        {
            var res = new ProjectViewModel();
            return View("ProjectForm", res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProject(ProjectViewModel project)
        {
            var result = new Project()
            {
                Name = project.Name,
                Description = project.Description,
            };
            await _context.projects.AddAsync(result);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> edit(int id)
        {
            var project = await _context.projects.SingleOrDefaultAsync(x => x.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            var viewproject = new ProjectViewModel()
            {
                Name=project.Name,
                Description=project.Description,
                Id=project.Id,
            };
            return View("ProjectForm", viewproject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> edit(ProjectViewModel project)
        {
            if (project.Id == null)
            {
                return BadRequest();
            }
            var res = await _context.projects.SingleOrDefaultAsync(x => x.Id == project.Id);
            if (res == null)
            {
                return NotFound();
            }
            res.Name = project.Name;
            res.Description = project.Description;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> delete(int id)
        {
            var project = await _context.projects.SingleOrDefaultAsync(x => x.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            _context.projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
