using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.DAL;
using TaskManagementSystem.DAL.Models;
using Task = TaskManagementSystem.DAL.Models.Task;

namespace TaskManagementSystem.ServiceLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly TaskManagementContext context;
        private readonly TMSRepository repObj;

        public EmployeesController(TaskManagementContext _context)
        {
            context = _context;
            repObj = new TMSRepository();
        }

        [HttpGet]
        public async Task<JsonResult> GetAllTasksByEmpId(int empId)
        {
            List<Task> tasks = new List<Task>();

            tasks = repObj.GetAllTasksbyEmployee(empId);

            return Json(tasks);
        }

        [HttpPut]
        public async Task<JsonResult> AddNotes(int taskId, int empId, string notes)
        {
            string result = repObj.AddNotes(taskId, empId, notes);

            return Json(result);
        }

        [HttpPatch]
        public async Task<JsonResult> UpdateCompletionPercentage(int taskId, int percenatge)
        {
            string result = repObj.AddCompletionPercentage(taskId, percenatge);

            return Json(result);
        }
    }
}
