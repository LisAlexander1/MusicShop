using MusicShop.Core;

namespace MusicShop.Models;

public class Manufacturer : DomainObject
{
    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;
    public List<Disk> Disks { get; set; }
}
