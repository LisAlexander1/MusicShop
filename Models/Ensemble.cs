using MusicShop.Core;

namespace MusicShop.Models;

public class Ensemble : DomainObject
{
    public string Name { get; set; } = null!;

    public List<MusicVersion> MusicVersions { get; set; }

    public List<Music> AuthorsMusic { get; set; }
    public List<EnsembleMembership> Memberships { get; set; }
    
    public byte[]? Avatar { get; set; }
    
}
