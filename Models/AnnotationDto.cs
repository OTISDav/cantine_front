// FrontendApp/Models/AnnotationDTOs.cs

using System;
using System.ComponentModel.DataAnnotations; // Nécessaire pour [Required], [Range], [MaxLength]

namespace FrontendApp.Models
{
    // DTO pour l'envoi de nouvelles annotations à l'API
    public class AnnotationCreateDTO
    {
        [Required(ErrorMessage = "Le MenuId est requis.")]
        public int MenuId { get; set; }

        [Required(ErrorMessage = "La note est requise.")]
        [Range(1, 5, ErrorMessage = "La note doit être entre 1 et 5.")]
        public int Note { get; set; }

        [MaxLength(500, ErrorMessage = "Le commentaire ne peut pas dépasser 500 caractères.")]
        public string? Commentaire { get; set; } // Peut être null
    }

    // DTO pour l'envoi de mises à jour d'annotations à l'API (si vous implémentez l'édition)
    public class AnnotationUpdateDTO
    {
        [Required(ErrorMessage = "La note est requise.")]
        [Range(1, 5, ErrorMessage = "La note doit être entre 1 et 5.")]
        public int Note { get; set; }

        [MaxLength(500, ErrorMessage = "Le commentaire ne peut pas dépasser 500 caractères.")]
        public string? Commentaire { get; set; } // Peut être null
    }

    // DTO pour recevoir les annotations de l'API et les afficher
    public class AnnotationDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; } = default!;
        public int MenuId { get; set; }
        public int Note { get; set; }
        public string? Commentaire { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}