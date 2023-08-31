using Core.Entities.Concrete.Users;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.Security.JWT
{
	public class JwtHelper : ITokenHelper
	{
		private TokenOptions? _tokenOptions;
		private IConfiguration Configuration;
		public DateTime _accessTokenExpiration;

		public JwtHelper(IConfiguration configuration)
		{
			Configuration = configuration;
			_tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
		}

		public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
		{
			SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
			SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
			_accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
			JwtSecurityToken jwt = CreateJtwSecurityToken(signingCredentials, _tokenOptions, user, operationClaims);
			string token = new JwtSecurityTokenHandler().WriteToken(jwt);

			return new AccessToken { Token = token, Expiration = _accessTokenExpiration };
		}

		private JwtSecurityToken CreateJtwSecurityToken
			(SigningCredentials signingCredentials, TokenOptions tokenOptions, User user, List<OperationClaim> operationClaims)
		{
			var jwt = new JwtSecurityToken(
				audience: tokenOptions.Audience,
				issuer: tokenOptions.Issuer,
				notBefore: DateTime.Now,
				expires: _accessTokenExpiration,
				signingCredentials: signingCredentials,
				claims: SetClaims(user, operationClaims)
				);
			return jwt;
		}

		private IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationClaims)
		{
			var claims = new List<Claim>();
			claims.AddNameIdentifier(user.Id.ToString());
			claims.AddFullName($"{user.FirstName} {user.LastName}");
			claims.AddEmail(user.Email);
			claims.AddRoles(operationClaims.Select(x => x.Name).ToArray());
			return claims;
		}
	}
}
