using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using VifTech.Business.Services.Interfaces;
using VifTech.Domain.Dtos.Response;
using VifTech.Helpers.Configuration;

namespace VifTech.Business.Services.Implementations
{
    public class SecurityService : ISecurityService
    {
        public RequestResponse<string> Token()
        {
            var response = new RequestResponse<string>();

            try
			{
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationKeys.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var tokenValues = new JwtSecurityToken(
                    issuer: ConfigurationKeys.Issuer,
                    audience: ConfigurationKeys.Audience,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: creds
                );
                response.Data = new JwtSecurityTokenHandler().WriteToken(tokenValues);
                response.Message = "Token Created Successfully !";
                response.StatusCode = HttpStatusCode.OK;
            }
			catch (Exception ex)
			{
                response.Message = ex.StackTrace;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
			}
            return response;
        }
    }
}
