using System;
using System.Collections.Generic;

namespace Task_management.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastLogin { get; set; }
}
