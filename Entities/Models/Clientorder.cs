using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Clientorder
{
    public int ClOrderId { get; set; }

    public int ClientId { get; set; }

    public int MentorId { get; set; }

    public int OrderStId { get; set; }

    public int OfferId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Mentor Mentor { get; set; } = null!;

    public virtual Offer Offer { get; set; } = null!;

    public virtual Orderstatus OrderSt { get; set; } = null!;
}
