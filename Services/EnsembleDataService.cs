using Microsoft.EntityFrameworkCore;
using MusicShop.Core;
using MusicShop.Models;
using MusicShop.Services.Common;

namespace MusicShop.Services;

public class EnsembleDataService : NonQueryDataService<Ensemble>
{
    
    private readonly MusicShopDbContext _context;

    public EnsembleDataService(MusicShopDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Ensemble>> GetAll()
    {

            await _context.Musicians.LoadAsync();
            IEnumerable<Ensemble> entities = await _context.Ensembles.Include(m => m.Memberships).ToListAsync();

            return entities;
    }

    public override async Task<Ensemble> Get(int id)
    {
        await _context.Musicians.LoadAsync();
            Ensemble entity = await _context.Ensembles.Include(m => m.Memberships).FirstOrDefaultAsync((e) => e.Id == id);

            return entity;
    }
}