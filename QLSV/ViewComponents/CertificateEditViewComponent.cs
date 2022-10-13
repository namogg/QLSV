using Microsoft.AspNetCore.Mvc;
using QLSV.Data;
using QLSV.Models;
namespace QLSV.ViewComponents
{

    public class CertificateEditViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Employee employee)
        {
            return View(employee);
        }
    }
}
