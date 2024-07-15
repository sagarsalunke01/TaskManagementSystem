using System;
using System.Collections.Generic;

namespace TaskManagementSystem.DAL.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public string? EmpManager { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
