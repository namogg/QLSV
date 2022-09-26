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
                return RedirectToAction("Create","Freshers");
            }
            if (type == "Experience")
            {
                return View();
            }
            if (type == "Intern")
            {
                return View();
            }
            return View();
        }
    }
}
