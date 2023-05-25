using VifTech.Domain.Dtos.Response;

namespace VifTech.Business.Services.Interfaces
{
    public interface ISecurityService
    {
        RequestResponse<string> Token();
    }
}
