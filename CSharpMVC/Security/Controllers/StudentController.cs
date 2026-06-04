using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Security.Controllers
{
    [Authorize(Roles = "Student, Leraar")]
    public class StudentController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
