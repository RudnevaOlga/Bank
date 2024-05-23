using DataAccess.AppDbContext;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class EFCardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public EFCardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Card> GetCardAsync(string number)
        {
            return await _context.card.FirstOrDefaultAsync(x => x.number == number);
        }

        public async Task UpdateCardAsync(Card card)
        {
            _context.card.Update(card);

            await _context.SaveChangesAsync();
        }
    }
}
