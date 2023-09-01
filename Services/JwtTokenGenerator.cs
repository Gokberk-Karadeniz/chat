using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BASITWEBAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace BASITWEBAPI.Services;

public class JwtTokenGenerator
{
    public const string Secret = "BDCF1693CBBE2BDCF1693CBBE2";
    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
          new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),
          SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
      new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
      new Claim(JwtRegisteredClaimNames.GivenName, user.Name),
      new Claim(JwtRegisteredClaimNames.FamilyName, user.Lastname),
       new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    };



        var securityToken = new JwtSecurityToken(
          issuer: Constants.AppName,
          audience: Constants.AppName,
          claims: claims,
          expires: DateTime.Now.AddDays(1),
          signingCredentials: signingCredentials);



        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}