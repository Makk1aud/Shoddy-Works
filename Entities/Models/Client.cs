using System;
using System.Collections.Generic;

namespace ShoddyWorks.WebApi.DbModels;

public partial class Client
{
    public int ClientId { get; set; }

    public string Firstname { get; set; } = null!;

    public string? Lastname { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? RefClientId { get; set; }

    public string? SocMedia { get; set; }

    public virtual ICollection<Clientorder> Clientorders { get; set; } = new List<Clientorder>();

    public virtual ICollection<Client> InverseRefClient { get; set; } = new List<Client>();

    public virtual Client? RefClient { get; set; }
}
