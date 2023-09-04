using Microsoft.EntityFrameworkCore;
using MusicShop.Core;
using MusicShop.Models;
using MusicShop.Services.Common;

namespace MusicShop.Services;

public class MusicianDataService : NonQueryDataService<Musician>
{
    
    private readonly MusicShopDbContext _context;

    public MusicianDataService(MusicShopDbContext context) : base(context)
    {
        _context= context;
    }

    public override async Task<IEnumerable<Musician>> GetAll()
    {
            await _context.Ensembles.LoadAsync();
            IEnumerable<Musician> entities = await _context.Musicians.Include(m => m.Memberships).ToListAsync();

            return entities;
    }

    public override async Task<Musician> Get(int id)
    {
            await _context.Ensembles.LoadAsync();
            Musician entity = await _context.Musicians.Include(m => m.Memberships).FirstOrDefaultAsync((e) => e.Id == id);

            return entity;
    }
}