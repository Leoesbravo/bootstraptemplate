using Microsoft.AspNetCore.Mvc;

namespace templatebootstrap.Controllers
{
    public class Empleado : Controller
    {
        public IActionResult Getall()
        {
            return PartialView();
        }
    }
}
