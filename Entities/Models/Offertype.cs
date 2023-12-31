﻿using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Offertype
{
    public int OfferTypeId { get; set; }

    public string TypeTitle { get; set; } = null!;

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
