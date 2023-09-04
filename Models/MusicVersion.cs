using MusicShop.Core;

namespace MusicShop.Models;

public class MusicVersion : DomainObject
{
    public int MusicId { get; set; }

    public string Type { get; set; } = null!;

    public int PerformerId { get; set; }

    public List<Disk> Disks { get; set; }
    public Music Music { get; set; } = null!;

    public Ensemble Performer { get; set; } = null!;
}
