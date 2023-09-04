using MusicShop.Core;

namespace MusicShop.Models;

public class Disk : DomainObject
{
    public string? Name { get; set; }

    public int SellerCompanyId { get; set; }

    public int ManufacturerId { get; set; }

    public long? LastYearSells { get; set; }

    public long? CurrentYearSells { get; set; }

    public double WholesalePrice { get; set; }

    public double RetailPrice { get; set; }

    public string? DateRelease { get; set; }

    public byte[]? Artwork { get; set; }
    
    public List<MusicVersion> Records { get; set; }

    public Manufacturer Manufacturer { get; set; } = null!;

    public SellerCompany SellerCompany { get; set; } = null!;
}
