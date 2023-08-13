using Models.DTO.AuthDTO;
namespace Services.TokenHandlerService
{
    public interface ITokenHandlerService
    {
        public Task<string> CreateTokenAsync(LoginDTO user);
        public string GetEmailFromJWT(string token);
        public long GetPatientIdFromJWT (string token);
        public long GetStaffIdFromJWT (string token);
        public Task<bool> IsStaff(string email);
    }
}