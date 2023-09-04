using Microsoft.EntityFrameworkCore;
using MusicShop.Core;
using MusicShop.Models;
using MusicShop.Services.Common;

namespace MusicShop.Services;

public class GenericDataService<T> : NonQueryDataService<T> where T : DomainObject
{
    private readonly MusicShopDbContext _context;
    
    public GenericDataService(MusicShopDbContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<T>> GetAll()
    {
            IEnumerable<T> entities = await _context.Set<T>().ToListAsync();

            return entities;
    }

    public override async Task<T> Get(int id)
    {
            T entity = await _context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);

            return entity;
    }

    
}