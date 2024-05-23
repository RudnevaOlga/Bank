using DataAccess.AppDbContext;
using Domain.Entities;
using Domain.Interfaces;

namespace DataAccess.Repository
{
    public class EFOperationRepository : IOperationRepository
    {
        private readonly ApplicationDbContext _context;

        public EFOperationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddOperationAsync(Operation operation)
        {
            await _context.AddAsync(operation);

            await _context.SaveChangesAsync();

        }
    }
}
