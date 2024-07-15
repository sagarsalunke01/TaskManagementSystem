using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TaskManagementSystem.DAL.Models;
using Task = TaskManagementSystem.DAL.Models.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data.Entity;

namespace TaskManagementSystem.DAL
{
    public class TMSRepository
    {
        public TaskManagementContext context;
        public TMSRepository()
        {
            context = new TaskManagementContext();
        }

        public List<Task> GetAllTasksbyEmployee(int empId)
        {
            List<Task> tasks = new List<Task>();

            try
            {
                tasks = (from t in context.Tasks where t.EmpId == empId select t).ToList();

                return tasks;
            }
            catch (Exception ex)
            {
                return  tasks;
            }
        }

        public string AddNotes(int taskId, int EmpId, string notes)
        {
            Task task = new Task();

            try
            {
                task = context.Tasks.Find(taskId);

                if (task.Notes != null)
                {
                    task.Notes = task.Notes + "\n " + notes;
                }
                else
                {
                    task.Notes = notes;
                }
                context.SaveChanges();
                return "Notes added successfully...!!!";
            }
            catch (Exception ex)
            {
                return "Something went wrong.";
            }
        }


        public string AddCompletionPercentage(int taskId, int completionPercentage)
        {
            Task task = new Task();

            try
            {
                task = context.Tasks.Find(taskId);

                task.TaskCompletionPercentage = completionPercentage;
                context.SaveChanges();
                return "Task Completion Percentage updated successfully...!!!";
            }
            catch (Exception ex)
            {
                return "Something went wrong.";
            }
        }

        public List<Task> GetTasksByEmpManager(string empManager)
        {
            List<Task> lstTasks = new List<Task>();

            try
            {
                lstTasks = (from t in context.Tasks join e in context.Employees on t.EmpId equals e.EmpId
                               where e.EmpManager == empManager select t).ToList();

                return lstTasks;
            }
            catch (Exception ex)
            {
                return lstTasks;
            }
        }

        public List<TaskDetailsByDueDate> GetTasksByDueDate(string due)
        {
            List <TaskDetailsByDueDate> lstTasks = new List<TaskDetailsByDueDate>();
            try
            {
                string query = "EXEC USP_GetTaskDetailsByDueDate @DueIn";

                SqlParameter prmDueIn = new SqlParameter("@DueIn", SqlDbType.VarChar, 10);
                prmDueIn.Value = due.ToLower();

                lstTasks = context.TaskDetailsByDueDates.FromSqlRaw(query, prmDueIn).ToList();

                return lstTasks;
                
            }
            catch (Exception ex)
            {
                return lstTasks;
            }
        }
    }
}
