using Microsoft.AspNetCore.Mvc;
using VifTech.Business.Services.Interfaces;
using VifTech.Domain.Dtos.Request;
using VifTech.Domain.Dtos.Response;

namespace VifTech.Api.Controllers
{
    [ApiController]
    public class QuotationController : ControllerBase
    {
        private readonly IQuotationService _quotationService;

        public QuotationController(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }
        [HttpPost("Quotation")]
        public RequestResponse<QuotationResponse> Save(SaveQuotationRequest request)
        {
            return _quotationService.Add(request);
        }
    }
}
