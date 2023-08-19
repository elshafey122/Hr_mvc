using Microsoft.AspNetCore.Mvc;

namespace mvclab2.Controllers
{
    public class DifferentdataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetTemp(int age,string name)
        {
            TempData["name"] = name;
            TempData["age"] = age;
            return Content("data saved");
        }
        public IActionResult GetTemp()
        {
            TempData.Keep("name");
            return Content($"data is :\n name={TempData["name"]} , age={TempData.Peek("age")}");
        }
        public IActionResult GetTemp2()
        {
            return Content($"data is :\n name={TempData["name"]} , age={TempData["age"]}");
        }


        public IActionResult SetSession(int age,string name)
        {
            HttpContext.Session.SetString("name", name);
            HttpContext.Session.SetInt32("age", age);
            return Content("data saved");
        }
        public IActionResult GetSession()
        {
            return Content($"data is :\n name={HttpContext.Session.GetString("name")} , age={HttpContext.Session.GetInt32("age")}");

        }
        public IActionResult DeleteSession()
        {
            //HttpContext.Session.Remove("name");
            HttpContext.Session.Clear();
            return Content("data deleted");
        }
    }
}
