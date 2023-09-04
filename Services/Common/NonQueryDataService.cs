using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MusicShop.Core;
using MusicShop.Models;

namespace MusicShop.Services.Common;

public abstract class NonQueryDataService<T> : IDataService<T> where T : DomainObject
{
    private readonly MusicShopDbContext _context;
    
    public NonQueryDataService(MusicShopDbContext context)
    {
        _context = context;
    }

    public abstract Task<IEnumerable<T>> GetAll();
    public abstract Task<T> Get(int id);

    public async Task<T> Create(T entity)
    {

            EntityEntry<T> createdResult = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return createdResult.Entity;

    }

    public async Task<T> Update(int id, T entity)
    {

            entity.Id = id;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;

    }

    public async Task<bool> Delete(int id)
    {

            T entity = await _context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return true;
    }
}