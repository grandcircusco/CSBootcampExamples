using System;
using System.Collections.Generic;

namespace Bookshelf2_api.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? DisplayName { get; set; }

    // This property was removed.
    // public virtual ICollection<Book> BookLentOutTos { get; set; } = new List<Book>();

    // This property was removed.
    // public virtual ICollection<Book> BookOwners { get; set; } = new List<Book>();
}
