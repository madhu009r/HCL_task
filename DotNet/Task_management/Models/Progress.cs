using System;
using System.Collections.Generic;

namespace Task_management.Models;

public partial class Progress
{
    public int StatusId { get; set; }

    public int TaskId { get; set; }

    public int? TaskStatus { get; set; }
}
