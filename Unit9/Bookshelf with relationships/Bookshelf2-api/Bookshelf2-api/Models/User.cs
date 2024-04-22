using System;
using System.Collections.Generic;

namespace Bookshelf2_api.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? DisplayName { get; set; }

    public virtual ICollection<Book> BookLentOutTos { get; set; } = new List<Book>();

    public virtual ICollection<Book> BookOwners { get; set; } = new List<Book>();
}
