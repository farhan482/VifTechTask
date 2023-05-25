using VifTech.Domain.Dtos.Request;
using VifTech.Domain.Dtos.Response;

namespace VifTech.Business.Services.Interfaces
{
    public interface IQuotationService
    {
        RequestResponse<QuotationResponse> Add(SaveQuotationRequest request);
    }
}
