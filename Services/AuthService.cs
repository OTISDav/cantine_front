using FrontendApp.Models;
using System.Threading.Tasks;

namespace FrontendApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApiService _api;
        private readonly StorageService _storage;

        public AuthService(ApiService api, StorageService storage)
        {
            _api = api;
            _storage = storage;
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var loginDto = new UserLoginDto
            {
                Email = email,
                Password = password
            };

            var response = await _api.LoginAsync(loginDto);

            if (response != null && !string.IsNullOrEmpty(response.Token))
            {
                await _storage.SetAsync("auth_token", response.Token);
                return response.Token;
            }

            return null;
        }

        public async Task LogoutAsync()
        {
            await _storage.RemoveAsync("auth_token");
        }
    }
}
