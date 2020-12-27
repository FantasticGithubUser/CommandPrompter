using CommandPrompterServer.Models.Dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Helpers
{
    /// <summary>
    /// Import configuration from appsettings.json for further use.
    /// </summary>
    public static class GlobalConfiguration
    {
        /// <summary>
        /// The dbcontext connection string;
        /// </summary>
        public static string ConnectionString { get; private set; }

        /// <summary>
        /// Where the log files store.
        /// </summary>
        public static string LogPosition { get; private set; }

        /// <summary>
        /// Jwt configurations property
        /// </summary>
        public static Dictionary<string, string> JwtToken
        {
            get
            {
                return new Dictionary<string, string>(_jwtToken);
            }
        }

        /// <summary>
        /// Jwt configurations field
        /// </summary>
        private static Dictionary<string, string> _jwtToken;

        /// <summary>
        /// Administrator's configurations Property
        /// </summary>
        public static LoginModel Administrator { get { return new LoginModel() { Username = _administrator.Username, Password = _administrator.Password }; } }
        /// <summary>
        /// Administrator's configurations Field
        /// </summary>
        private static LoginModel _administrator;


        /// <summary>
        /// Import further used configuration from appsettings.json
        /// </summary>
        /// <param name="configuration"></param>
        public static void ImportConfiguration(IConfiguration configuration)
        {
            ConnectionString = configuration["ConnectionString"];
            LogPosition = configuration["LogPosition"];
            _jwtToken = new Dictionary<string, string>();
            _jwtToken.Add("SecretKey", configuration["JwtToken:SecretKey"]);
            _jwtToken.Add("Issuer", configuration["JwtToken:Issuer"]);
            _jwtToken.Add("Audience", configuration["JwtToken:Audience"]);
            _jwtToken.Add("TokenExpiry", configuration["JwtToken:TokenExpiry"]);
            _administrator = new LoginModel()
            {
                Username = configuration["Administrator:Username"],
                Password = configuration["Administrator:Password"]
            };
        }
    }
}
