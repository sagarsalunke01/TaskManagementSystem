using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.DAL.Models
{
    [Keyless]
    public class TaskDetailsByDueDate
    {
        public string TeamName { get; set; }
        public string EmpManager { get; set; }
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public int? TaskCompletionPercentage { get; set; }
        
    }
}
