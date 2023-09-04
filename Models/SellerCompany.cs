using MusicShop.Core;

namespace MusicShop.Models;

public class SellerCompany : DomainObject
{
    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public List<Disk> Disks { get; set; }
}
