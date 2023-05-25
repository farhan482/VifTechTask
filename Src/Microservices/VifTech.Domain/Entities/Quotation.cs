using VifTech.Domain.Entities.Base;

namespace VifTech.Domain.Entities
{
    public class Quotation : BaseEntity
    {
        public string? Age { get; set; }
        public string? Currency_Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
