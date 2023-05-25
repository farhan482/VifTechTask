using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VifTech.Domain.Entities;

namespace VifTech.Business.Repositories.Interfaces
{
    public interface IQuotationRepository
    {
        Quotation Add(Quotation entity);
    }
}
