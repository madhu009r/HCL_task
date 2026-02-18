using System;
using System.Collections.Generic;

namespace FetchApi.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Favouritecountry> Favouritecountries { get; set; } = new List<Favouritecountry>();
}
