using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.DAL;
using TaskManagementSystem.DAL.Models;

namespace TaskManagementSystem.ServiceLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyAdminController : Controller
    {
        private readonly TMSRepository repObj;

        public CompanyAdminController()
        {
            repObj = new TMSRepository();
        }

        [HttpGet]
        public async Task<JsonResult> GetTaskDetailsByDueDate(string tasksDueIn)
        {
            List<TaskDetailsByDueDate> lstResult = new List<TaskDetailsByDueDate>();

            lstResult = repObj.GetTasksByDueDate(tasksDueIn);

            return Json(lstResult);
        }
    }
}
