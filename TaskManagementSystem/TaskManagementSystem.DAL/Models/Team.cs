using System;
using System.Collections.Generic;

namespace TaskManagementSystem.DAL.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string? TeamName { get; set; }

    public string? EmpManager { get; set; }
}
