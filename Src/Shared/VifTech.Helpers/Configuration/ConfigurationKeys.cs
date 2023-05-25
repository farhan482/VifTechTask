using Microsoft.Extensions.Configuration;

namespace VifTech.Helpers.Configuration
{
    public class ConfigurationKeys
    {
        private readonly IConfiguration _configuration;
        public ConfigurationKeys(IConfiguration configuration)
        {
            _configuration = configuration;
            #region Database Config Key
            ConnectionString = _configuration.GetConnectionString("DbConnection");
            #endregion
            #region Jwt Config Key
            Issuer = _configuration.GetSection("Jwt").GetValue<string>("Issuer");
            Audience = _configuration.GetSection("Jwt").GetValue<string>("Audience");
            SecretKey = _configuration.GetSection("Jwt").GetValue<string>("Key");
            #endregion
        }
        #region Database Config Key
        public static string? ConnectionString { get; set; }
        #endregion
        #region Jwt Config Key
        public static string? Issuer { get; set; }
        public static string? Audience { get; set; }
        public static string? SecretKey { get; set; }
        #endregion
    }
}
