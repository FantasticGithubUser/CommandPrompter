using CommandPrompterServer.Helpers;
using CommandPrompterServer.Models.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompterServer.Controllers
{
    public class LoginController : BaseController
    {
        private string BuildJWTToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GlobalConfiguration.JwtToken["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuer = GlobalConfiguration.JwtToken["Issuer"];
            var audience = GlobalConfiguration.JwtToken["Audience"];
            var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(GlobalConfiguration.JwtToken["TokenExpiry"]));

            var token = new JwtSecurityToken(issuer,
              audience,
              expires: jwtValidity,
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private bool Authenticate(LoginModel login)
        {
            Models.Dao.User validUser = null;
            if (login.Username == GlobalConfiguration.Administrator.Username && login.Password == GlobalConfiguration.Administrator.Password)
            {
                AccountHolder.isAdmin.Value = true;
                AccountHolder.user.Value = new Models.Dao.User()
                {
                    Id = "Administrator",
                    Username = GlobalConfiguration.Administrator.Username,
                    Password = GlobalConfiguration.Administrator.Password
                };
                validUser = AccountHolder.User;
            }
            else
            {
                validUser = _userService.ValidateUser(login.Username, login.Password);
                if (validUser != null)
                {
                    AccountHolder.user.Value = validUser;
                }
            }
           
            return validUser!=null;
        }

        /// <summary>
        /// User login interface, return the jwt token with prefix "Bearer "
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModel login)
        {
            if (login == null) return Unauthorized();
            string tokenString = string.Empty;
            bool validUser = Authenticate(login);
            if (validUser)
            {
                tokenString = BuildJWTToken();
                AccountHolder.token.Value = tokenString;
            }
            else
            {
                return Unauthorized();
            }
            return Ok(new { Token = "Bearer "+tokenString });
        }

        /// <summary>
        /// Clear the whole database for test.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ClearDatabase")]
        [AllowAnonymous]
        public IActionResult ClearDatabase()
        {
            DbContextHolder.Context.Database.EnsureDeleted();
            return Ok("Database Cleared");
        }

        /// <summary>
        /// Create the whole database for test.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("CreateDatabase")]
        [AllowAnonymous]
        public IActionResult CreateDatabase()
        {
            DbContextHolder.Context.Database.EnsureCreated();
            //Initial Test data.
            InitialData();
            return Ok("Database Created");
        }

        /// <summary>
        /// Initial Test Data
        /// </summary>
        private void InitialData()
        {
            var context = DbContextHolder.Context;

            var user = _userService.AddNewEntity(new Models.Dao.User
            {
                Username = "test",
                Password = "test"
            });
            AccountHolder.user.Value = user;
            Models.Dao.Plateform cur = null, last = null;
            
            var action = new Action(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    cur = _plateformService.AddNewEntity(new Models.Dao.Plateform
                    {
                        Name = "testForm" + i,
                        PlateformVersion = "newVersion" + i
                    });
                    if (last != null)
                    {
                        cur.PlateformId = last.Id;
                        _plateformService.UpdateEntity(cur);
                    }
                    last = cur;
                }
            });
            Parallel.Invoke(action);

        }
        /// <summary>
        /// Get tokens
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetToken")]
        [Authorize]
        public async Task<IEnumerable<string>> Get()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            return new string[] { accessToken, "Successed!" };
        }
    }
}
