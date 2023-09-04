using MusicShop.Core;

namespace MusicShop.Models;

public class Musician : DomainObject
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Surname { get; set; }

    public byte[]? Avatar { get; set; }

    public List<EnsembleMembership> Memberships { get; set; }


}
