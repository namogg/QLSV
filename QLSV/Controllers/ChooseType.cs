using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSV.Models;

namespace QLSV.Controllers
{
    public class ChooseType : Controller
    {
        // GET: ChooseType
        public ActionResult Index(string type)
        {
            if (type == "Fresher")
            {
                return RedirectToAction("Create","FresherDTO");
            }
            if (type == "Experience")
            {
                return RedirectToAction("Create", "ExperienceDTO");
            }
            if (type == "Intern")
            {
                return RedirectToAction("Create", "InternDTO");
            }
            return View();
        }
    }
}
