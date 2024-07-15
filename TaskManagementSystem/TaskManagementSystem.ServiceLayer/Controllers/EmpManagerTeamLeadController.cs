using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.DAL;
using Task = TaskManagementSystem.DAL.Models.Task;

namespace TaskManagementSystem.ServiceLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmpManagerTeamLeadController : Controller
    {
        private readonly TMSRepository repObj;

        public EmpManagerTeamLeadController()
        {
                repObj = new TMSRepository();
        }

        [HttpGet]
        public async Task<JsonResult> GetTasksByEmpManager(string empManager)
        {
            List<Task> tasks = new List<Task>();

            tasks = repObj.GetTasksByEmpManager(empManager);

            return Json(tasks);
        }
    }
}
