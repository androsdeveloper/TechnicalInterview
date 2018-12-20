
namespace TechnicalInterview.Controllers
{
    using Dto;
    using MasGlobal.Interview.Interfaces;
    using System.Collections.Generic;
    using System.Web.Mvc;
    public class GetEmployeesController : Controller
    {
        IBlEmployees blEmployees;       
        public GetEmployeesController(IBlEmployees blEmployees)
        {
            this.blEmployees = blEmployees;     
        }
        // GET: GetEmployees
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllEmployees(int? id)
        {           
            List<DtoEmployees> lstEmployees = new List<DtoEmployees>();

            lstEmployees = this.blEmployees.GetEmployees(id);
            return Json(lstEmployees, JsonRequestBehavior.AllowGet);
        }
    }
}