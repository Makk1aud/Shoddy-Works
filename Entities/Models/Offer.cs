using System;
using System.Collections.Generic;

namespace ShoddyWorks.WebApi.DbModels;

public partial class Offer
{
    public int OfferId { get; set; }

    public string OfferTitle { get; set; } = null!;

    public string OfferDesc { get; set; } = null!;

    public int OfferTypeId { get; set; }

    public decimal OfferPrice { get; set; }

    public DateTime PublishDate { get; set; }

    public virtual ICollection<Clientorder> Clientorders { get; set; } = new List<Clientorder>();

    public virtual Offertype OfferType { get; set; } = null!;
}
