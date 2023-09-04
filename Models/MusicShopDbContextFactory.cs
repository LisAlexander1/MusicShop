using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MusicShop.Models;

public class MusicShopDbContextFactory : IDesignTimeDbContextFactory<MusicShopDbContext>
{
    public MusicShopDbContext CreateDbContext(string[] args = null)
    {
        var options = new DbContextOptionsBuilder<MusicShopDbContext>();
        options.UseSqlite("Data Source=.\\..\\..\\..\\musicshop.sqlite");

        return new MusicShopDbContext(options.Options);
    }
}