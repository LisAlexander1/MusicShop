using MusicShop.Core;

namespace MusicShop.Models;

public class EnsembleMembership : DomainObject
{
    public int EnsembleId { get; set; }
    public Ensemble Ensemble { get; set; }
    
    public int MusicianId { get; set; }
    public Musician Musician { get; set; }
    
    public string Roles { get; set; }
}