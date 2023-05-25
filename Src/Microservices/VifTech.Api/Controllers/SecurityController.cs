using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;
using VifTech.Business.Services.Interfaces;
using VifTech.Domain.Dtos.Response;
using VifTech.Helpers.Configuration;

namespace VifTech.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [AllowAnonymous]
        [HttpPost("Token")]
        public RequestResponse<string> CreateToken()
        {
            return _securityService.Token();
        }
    }
}
