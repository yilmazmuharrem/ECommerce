using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Persistence.Context;
using ECommerce.Persistence.Repositories;

namespace ECommerce.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public async ValueTask DisposeAsync() => await _context.DisposeAsync();
       
        public int Save() => _context.SaveChanges();
        
        public async  Task<int> SaveAsync() => await _context.SaveChangesAsync();
        
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_context);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_context);
       
    }
}
