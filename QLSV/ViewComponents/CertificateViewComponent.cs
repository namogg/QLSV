using Microsoft.AspNetCore.Mvc;
using QLSV.Data;
using QLSV.Models;
namespace QLSV.ViewComponents
{   

    public class CertificateCreateViewComponent : ViewComponent
    {
        public List<Certificate> certificates { get; private set; }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
