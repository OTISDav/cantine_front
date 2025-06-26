namespace FrontendApp.Models
{
    public class AnnotationDto
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int Note { get; set; }
        public string Commentaire { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
