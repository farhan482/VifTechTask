using System.Net;
using VifTech.Business.Repositories.Interfaces;
using VifTech.Business.Services.Interfaces;
using VifTech.Domain.Dtos.Request;
using VifTech.Domain.Dtos.Response;
using VifTech.Domain.Entities;

namespace VifTech.Business.Services.Implementations
{
    public class QuotationService : IQuotationService
    {
        private readonly IQuotationRepository _quotationRepository;

        public QuotationService(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }

        public RequestResponse<QuotationResponse> Add(SaveQuotationRequest request)
        {
            var response = new RequestResponse<QuotationResponse>();

            try
            {
                #region Some Validation Case
                if (request?.Age == "0")
                {
                    response.Message = "Age is invalid !";
                    response.StatusCode = HttpStatusCode.BadRequest;
                    return response;
                }
                var ages = request?.Age.Split(",");
                int firstValue = int.Parse(ages[0]);
                if (firstValue < 18)
                {
                    response.Message = "Age is invalid !";
                    response.StatusCode = HttpStatusCode.BadRequest;
                    return response;
                }
                #endregion
                var entity = new Quotation()
                {
                    Age = request.Age,
                    Currency_Id = request?.Currency_Id,
                    StartDate = request?.StartDate,
                    EndDate = request?.EndDate
                };
                var addedEntity = _quotationRepository.Add(entity);
                if (addedEntity != null)
                {
                    response.Data = new();

                    if (addedEntity?.Currency_Id.Trim().ToLower() == "eur")
                        response.Data.Currency_Id = "Currency code in ISO 4217 format.";

                    int tripLength = (addedEntity?.EndDate - addedEntity?.StartDate).Value.Days;
                    int total = 0;
                    foreach (var age in addedEntity.Age.Split(","))
                    {
                        total += 3 * int.Parse(age) * tripLength;
                    }
                    response.Data.Total = total.ToString("C");
                    response.Data.Quotation_Id = addedEntity.Id;

                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Request Proccessed Successfully !";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }
    }
}
