using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Mentor
{
    public int MentorId { get; set; }

    public string Firstname { get; set; } = null!;

    public string? Lastname { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? SocMedia { get; set; }

    public virtual ICollection<Clientorder> Clientorders { get; set; } = new List<Clientorder>();
}
