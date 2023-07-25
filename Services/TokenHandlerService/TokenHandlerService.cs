using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.DTO.AuthDTO;
using server.Database;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.TokenHandlerService
{
    public class TokenHandlerService : ITokenHandlerService
    {
        private readonly IConfiguration _configuration;
        private readonly DentalDBContext _dbContext;

        public TokenHandlerService(IConfiguration configuration, DentalDBContext dbContext)
        {
            this._configuration = configuration;
            this._dbContext = dbContext;
        }
        public async Task<string> CreateTokenAsync(LoginDTO user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, user.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, user.LastName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );
            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
            
        }

        public string GetEmailFromJWT(string token)
        {
            token = token.Remove(0,7);
            var handler = new JwtSecurityTokenHandler();
            var jwtAuth = handler.ReadJwtToken(token);
            var tokenEmail = jwtAuth.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            return tokenEmail;
        }

        public async Task<bool> IsStaff(string email)
        {
            var staff = await _dbContext.Staff.Include(s => s.User).Where(u => u.User.Email == email).AsNoTracking().FirstOrDefaultAsync();
            if(staff != null)
                return true;
            else
                return false;
        }
    }
}