using System;
using System.Collections.Generic;

namespace BookAPI.Models;

public  class Book
{
    public int Id { get; set; }

    public string BookName { get; set; }

    public string AuthorName { get; set; }

    public DateOnly PublicationYear { get; set; }

    public string Genre { get; set; }
}
