using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Orderstatus
{
    public int OrderStId { get; set; }

    public string StatusTitle { get; set; } = null!;

    public virtual ICollection<Clientorder> Clientorders { get; set; } = new List<Clientorder>();
}
