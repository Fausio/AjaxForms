using Microsoft.AspNetCore.Mvc;

namespace AjaxForms.Controllers
{
    public class FormController : Controller
    {
        public IActionResult form()
        {
            return View();
        }
    }
}
