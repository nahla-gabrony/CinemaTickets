using Microsoft.AspNetCore.Mvc;

namespace CinemaTickets.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{StatusCode}")]
        public IActionResult HttpStatusCodeHandler(int StatusCode)
        {
            switch (StatusCode)
            {
                case 404:
                    break;
            }
            return View("NotFound");
        }
    }
}
