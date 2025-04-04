using System.Linq.Expressions;
using System.Threading.Tasks;
using DentalSchedulerAPI.Data;
using DentalSchedulerAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalSchedulerAPI.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext? _context;
    protected readonly DbSet<T>? _dbSet;

    public Repository(ApplicationDbContext? context)
    {
        _context = context;
        _dbSet = _context?.Set<T>();
    }

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

    public void Remove(T entity) => _dbSet.Remove(entity);

    public void Update(T entity) => _dbSet.Update(entity);
}
