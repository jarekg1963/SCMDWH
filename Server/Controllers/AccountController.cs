using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Novell.Directory.Ldap;
using NuGet.Common;
using SCMDWH.Server.Data;
using SCMDWH.Shared.DTO;
using SCMDWH.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SCMDWH.Server.Controllers
{
	[Route("api/accounts")]
	[ApiController]
	public class AccountsController : ControllerBase
	{

		private readonly IConfiguration _configuration;
		private readonly IConfigurationSection _jwtSettings;
		

		private readonly PurchasingContext _context;

		public AccountsController(IConfiguration configuration, PurchasingContext context)
		{

			_configuration = configuration;
			_jwtSettings = _configuration.GetSection("JwtSettings");
			_context = context;
		}


		[HttpPost("Login")]
		public async Task<ActionResult<AuthResponseDto>> Login([FromBody] UserForAuthenticationDto userForAuthentication)
		{
			GlobalAppUsers globalUser = new GlobalAppUsers();

			globalUser = await _context.GlobalAppUsers.Include(r=>r.GlobalAppUserRoles).FirstOrDefaultAsync(c => c.UserName == userForAuthentication.Email);

			if (globalUser is null) return Ok(new AuthResponseDto { IsAuthSuccessful = false, ErrorMessage = "No user in database." });

            // podział uzykowanikow na external i LDAPP 
			// Uzytkownicy external 

			if (globalUser.External)
			{
				if (BCrypt.Net.BCrypt.Verify(userForAuthentication.Password, globalUser.Password))
				{
					List<Claim> claims = new List<Claim>();
					claims.Add(new Claim(ClaimTypes.Name, userForAuthentication.Email));

					foreach (var role in globalUser.GlobalAppUserRoles.Select(P => P.RoleName))
					{
						claims.Add( new Claim(ClaimTypes.Role , role));
					}

					var signingCredentials = GetSigningCredentials();
					var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
					var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    _context.LogAppUserActivity.Add(new LogAppUserActivity
                    {
                        AppActivityType = "Login ",
                        AppActivityDetails = "Success",
                        ActivityTime = DateTime.Now,
                        ActivityTriggeredByUser = userForAuthentication.Email
                    });

                    _context.SaveChanges();
					
                    return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
				}
				else
				{
                    return Ok(new AuthResponseDto { IsAuthSuccessful = false, ErrorMessage = "Wrong password" });
				}
			}

			else // internal LDAP User 
			{
				LoginLDAP credentials = new LoginLDAP();
				credentials.UserName = userForAuthentication.Email;
				credentials.PassWord = userForAuthentication.Password;

                if (credentials.LdapCheck(credentials))
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, userForAuthentication.Email));	
					foreach (var role in globalUser.GlobalAppUserRoles.Select(P => P.RoleName))
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }	
                    var signingCredentials = GetSigningCredentials();
                    var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
                    var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
					// wpisujemy do Log-a 
                    _context.LogAppUserActivity.Add(new LogAppUserActivity
                    {
                        AppActivityType = "Login ",
                        AppActivityDetails = "Success",
                        ActivityTime = DateTime.Now,
                        ActivityTriggeredByUser = userForAuthentication.Email
                    });
                    _context.SaveChanges();
                    return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
                }
				else
				{
					return Ok(new AuthResponseDto { IsAuthSuccessful = false, ErrorMessage = "Wrong password" });
                }
            }
		}
			#region SupportedFunctions
			private SigningCredentials GetSigningCredentials()
			{
				var key = Encoding.UTF8.GetBytes(_jwtSettings["securityKey"]);
				var secret = new SymmetricSecurityKey(key);
				return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
			}

			//private List<Claim> GetClaims(IdentityUser user)
			//{
			//	var claims = new List<Claim>
			//	{
			//		new Claim(ClaimTypes.Name, "")
			//	};
			//	return claims;
			//}


			private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
			{
				var tokenOptions = new JwtSecurityToken(
					issuer: _jwtSettings["validIssuer"],
					audience: _jwtSettings["validAudience"],
					claims: claims,
					expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])),
					signingCredentials: signingCredentials);

				return tokenOptions;
			}


        public partial class LoginLDAP
        {
            public string UserName { get; set; }
            public string PassWord { get; set; }
            public bool LdapCheck(LoginLDAP login)
            {
                try
                {
                    using (var cn = new LdapConnection())
                    {
                        cn.Connect("172.17.80.90", 389);
                        cn.Bind("tpvaoc\\" + login.UserName, login.PassWord);
                        return cn.Bound;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        #endregion
    }

	}
