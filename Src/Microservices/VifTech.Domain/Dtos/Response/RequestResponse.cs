using System.Net;

namespace VifTech.Domain.Dtos.Response
{
    public class RequestResponse<T>
    {
        public string? Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
}
