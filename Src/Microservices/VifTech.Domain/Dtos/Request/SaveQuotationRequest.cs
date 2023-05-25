namespace VifTech.Domain.Dtos.Request
{
    public class SaveQuotationRequest
    {
        public string? Age { get; set; }
        public string? Currency_Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
