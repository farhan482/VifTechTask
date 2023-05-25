using Microsoft.EntityFrameworkCore.ChangeTracking;
using VifTech.Business.Repositories.Interfaces;
using VifTech.Domain.Contexts;
using VifTech.Domain.Entities;

namespace VifTech.Business.Repositories.Implementations
{
    public class QuotationRepository : IQuotationRepository
    {
        private ApplicationDbContext _context;

        public QuotationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Quotation Add(Quotation entity)
        {
            var record = _context.Add(entity).Entity;
            SaveChanges();
            return record;

        }
        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
