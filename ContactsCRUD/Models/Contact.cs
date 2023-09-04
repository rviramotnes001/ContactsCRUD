using System;
using System.Collections.Generic;

namespace ContactsCRUD.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public string? Fullname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }
}
