namespace FrontendApp.Models
{
    public class MenuDto
    {
        public int Id { get; set; } // ✅ Ajout nécessaire
        public DateTime Date { get; set; }
        public string PlatPrincipal { get; set; } = string.Empty;
        public string Dessert { get; set; } = string.Empty;
        public string Boisson { get; set; } = string.Empty;
    }

}
