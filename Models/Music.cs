using MusicShop.Core;

namespace MusicShop.Models;

public class Music : DomainObject
{
    public string Name { get; set; } = null!;

    public string? MusicDuration { get; set; }

    public byte[]? Artwork { get; set; }

    public List<Ensemble> Authors { get; set; }

    public List<MusicVersion> MusicVersions { get; set; }
}
