using System;
using System.Collections.Generic;

namespace FetchApi.Models;

public partial class Favouritecountry
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? CountryName { get; set; }

    public string? Capital { get; set; }

    public string? Region { get; set; }

    public string? FlagUrl { get; set; }

    public virtual User? User { get; set; }
}
