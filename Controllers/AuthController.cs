using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASAG_ILIK_nvOM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public string Get(int UserId, string Username)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, Username),
                new Claim(ClaimTypes.Name, Username)
            };

            var signingKey = "BuBenimSigningKeyim";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "https://www.github.com/leidorf.com",
                audience: "BuBenimKullandigimAudienceDegeri",
                claims: claims,
                expires: DateTime.Now.AddDays(3),
                notBefore: DateTime.Now,
                signingCredentials: credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
