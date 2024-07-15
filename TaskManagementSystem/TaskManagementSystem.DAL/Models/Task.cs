using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TaskManagementSystem.DAL.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string? TaskName { get; set; }

    public int? EmpId { get; set; }

    public string? Notes { get; set; }

    public int? TaskCompletionPercentage { get; set; }

    public byte[]? Document { get; set; }

    public DateTime? DueDate { get; set; }

    [JsonIgnore]
    public virtual Employee? Emp { get; set; }
}
