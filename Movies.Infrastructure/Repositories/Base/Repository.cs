using Microsoft.EntityFrameworkCore;
using Movies.Core.Entites;
using Movies.Core.Entites.Base;
using Movies.Core.Repositories.Base;
using Movies.Infrastructure.Data;

namespace Movies.Infrastructure.Repositories.Base;

internal class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly MovieContext _movieContext;

    public Repository(MovieContext movieContext)
    {
        _movieContext = movieContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _movieContext.AddAsync(entity);
        await _movieContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _movieContext.Set<T>().Remove(entity);
        await _movieContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _movieContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid Id)
    {
        return await _movieContext.Set<T>().FindAsync(Id);
    }

    public async Task UpdateAsync(T entity)
    {
        _movieContext.Entry(entity).State = EntityState.Modified;
        await _movieContext.SaveChangesAsync();
    }
}