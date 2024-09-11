using EmployeeManagementTool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagementTool.Controllers
{
    public class HomeController : Controller
    {
        public UserDbContext _context;

        public HomeController(UserDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        // For POST Request
        [HttpPost]
        public IActionResult Login(string UserId, string Password)
        {
            User obj= _context.Users.Find(int.Parse(UserId));
            if (obj != null)
            {
                if (Password == obj.Password )
                {
                    return RedirectToAction("Index","Employees");
                }
                else
                {
                    ViewData["result"] = "Invalid Password";
                }
            }
            else
            { 
                ViewData["result"] = "Invalid User Id ";
            }


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
