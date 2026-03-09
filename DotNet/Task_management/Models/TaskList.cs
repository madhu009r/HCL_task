using System;
using System.Collections.Generic;

namespace Task_management.Models;

public partial class TaskList
{
    public int TaskId { get; set; }

    public string? TaskName { get; set; }

    public int AssignTo { get; set; }

    public string? Descrip { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateTime? CreatedAt { get; set; }
}
