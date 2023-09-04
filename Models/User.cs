using MusicShop.Core;

namespace MusicShop.Models;

public class User : DomainObject
{
    public string Login { get; set; } = null!;

    public string? Name { get; set; }

    public string? Role { get; set; }

    public string Password { get; set; } = null!;
}
