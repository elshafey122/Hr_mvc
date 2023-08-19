using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvc2.Models;
using mvclab2.Models;
using mvclab2.ViewModel;

namespace mvclab2.Controllers
{
    public class RegistrationController : Controller
    {
        ApplicationDbContext _context;
        public RegistrationController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IActionResult Register()
        {
            List<Office> offices = _context.offices.ToList();
            EmployeeViewModel employeeviewmodel = new EmployeeViewModel()
            {
                offices = new SelectList(offices, "Id", "Name"),
            };
            return View("EmployeeForm", employeeviewmodel);
        }

        [HttpPost]
        public IActionResult Register(EmployeeViewModel empvm)
        {
            if (!ModelState.IsValid)
            {
                empvm.offices = new SelectList(_context.offices.ToList(), "Id", "Name");
                return RedirectToAction(nameof(Index), empvm);
            }
            Employee NewEmployee = new Employee()
            {
                Age = empvm.Age,
                Email = empvm.Email,
                Name = empvm.Name,
                Password = empvm.Password,
                OfficeId = empvm.OfficeId,
                Salary = empvm.Salary,
            };
            _context.employees.Add(NewEmployee);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public IActionResult Login(LoginEmployeeViewModel logemp)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Login));
            }
            var employee = _context.employees.FirstOrDefault(x => x.Email == logemp.Email && x.Password == logemp.Password);
            if (employee==null)
            {
                ModelState.AddModelError("", "invalid email or password");
                return RedirectToAction(nameof(Login));
            }
            HttpContext.Session.SetInt32("UserId", employee.Id);
            HttpContext.Session.SetString("UserName", employee.Name);
            HttpContext.Session.SetString("UserType", "Student");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}
