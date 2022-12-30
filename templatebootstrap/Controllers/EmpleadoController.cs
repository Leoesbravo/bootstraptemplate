using Microsoft.AspNetCore.Mvc;

namespace templatebootstrap.Controllers
{
    public class EmpleadoController : Controller
    {
        public ActionResult Getall()
        {
            ML.Result result = new ML.Result();
            ML.Empleado empleado = new ML.Empleado();
            result = BL.Empleado.GetAll();

            return Json(result);
        }
    }
}
