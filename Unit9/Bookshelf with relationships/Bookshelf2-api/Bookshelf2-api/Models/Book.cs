using System;
using System.Collections.Generic;

namespace Bookshelf2_api.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public int? Pages { get; set; }

    public bool? LentOut { get; set; }

    public int? OwnerId { get; set; }

    public int? LentOutToId { get; set; }

    public virtual User? LentOutTo { get; set; }

    public virtual User? Owner { get; set; }
}
