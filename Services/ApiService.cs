using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FrontendApp.Models;
using System.Collections.Generic;

namespace FrontendApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // 🔐 Connexion
        public async Task<AuthResponseDto?> LoginAsync(UserLoginDto login)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", login);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AuthResponseDto>();
            }
            return null;
        }

        // 👤 Inscription
        public string? LastError { get; private set; }

        public async Task<AuthResponseDto?> RegisterAsync(UserRegisterDto register)
        {
            try
            {
                LastError = null;

                var response = await _httpClient.PostAsJsonAsync("api/Auth/register", register);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<AuthResponseDto>();
                }

                var error = await response.Content.ReadAsStringAsync();
                LastError = $"Erreur {response.StatusCode}: {error}";
                Console.WriteLine("❌ Erreur backend : " + LastError);

                return null;
            }
            catch (Exception ex)
            {
                LastError = $"Exception: {ex.Message}";
                Console.WriteLine("❗ Exception RegisterAsync : " + LastError);
                return null;
            }
        }

        // 🍽️ Obtenir les menus
        public async Task<List<MenuDto>> GetMenusAsync()
        {
            var response = await _httpClient.GetAsync("api/Menu");
            response.EnsureSuccessStatusCode();

            var menus = await response.Content.ReadFromJsonAsync<List<MenuDto>>();
            return menus ?? new List<MenuDto>();
        }

        // 📋 Obtenir les réservations
        public async Task<List<ReservationDto>> GetReservationsAsync()
        {
            var response = await _httpClient.GetAsync("api/Reservation");
            response.EnsureSuccessStatusCode();

            var reservations = await response.Content.ReadFromJsonAsync<List<ReservationDto>>();
            return reservations ?? new List<ReservationDto>();
        }

        // ➕ Créer une réservation
        public async Task<ReservationDto?> CreateReservationAsync(ReservationDto reservation)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Reservation", reservation);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ReservationDto>();
            }
            return null;
        }

        // ❌ Supprimer une réservation
        public async Task<bool> DeleteReservationAsync(string reservationId)
        {
            var response = await _httpClient.DeleteAsync($"api/Reservation/{reservationId}");
            return response.IsSuccessStatusCode;
        }
    }
}
