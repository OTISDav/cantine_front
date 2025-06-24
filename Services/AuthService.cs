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

            // Appelle le LoginAsync de ApiService qui doit retourner AuthResponseDto
            var authResponse = await _api.LoginAsync(loginDto);

            // Vérifie si la réponse n'est pas nulle et si le token et l'UserId sont présents
            if (authResponse != null && !string.IsNullOrEmpty(authResponse.Token) && !string.IsNullOrEmpty(authResponse.UserId))
            {
                // Stocke le token
                await _storage.SetAsync("auth_token", authResponse.Token);
                // Stocke l'ID utilisateur
                await _storage.SetAsync("user_id", authResponse.UserId); // <-- Ajout de cette ligne cruciale

                return authResponse.Token; // Retourne le token comme indiqué par la signature de LoginAsync
            }

            return null; // La connexion a échoué ou les données sont incomplètes
        }

        public async Task LogoutAsync()
        {
            await _storage.RemoveAsync("auth_token");
            await _storage.RemoveAsync("user_id"); // <-- Ajout pour supprimer aussi l'ID utilisateur
            // Si vous avez d'autres données liées à l'utilisateur, supprimez-les ici.
        }
    }
}