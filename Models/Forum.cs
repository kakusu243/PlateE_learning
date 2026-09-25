using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlateE_learning.Models
{
    public class Forum
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CoursId { get; set; }
        [ForeignKey("CoursId")]
        public virtual Cours? Cours { get; set; }

        [Required, MaxLength(150)]
        public string Nom { get; set; } = string.Empty; // Ex: "Forum du cours : Blazor Avancé"

        public string Description { get; set; } = string.Empty;

        // Un forum contient directement une liste de messages continus (style WhatsApp)
        public virtual ICollection<MessageForum> Messages { get; set; } = new List<MessageForum>();
    }

    public class MessageForum
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ForumId { get; set; }
        [ForeignKey("ForumId")]
        public virtual Forum? Forum { get; set; }

        [Required]
        public int AuteurId { get; set; }
        [ForeignKey("AuteurId")]
        public virtual Utilisateur? Auteur { get; set; }

        [Required]
        public string Contenu { get; set; } = string.Empty;

        public DateTime DateCreation { get; set; } = DateTime.UtcNow;

        // --- Nouveaux champs pour la réponse ciblée ---
        public string? MessageReponduContenu { get; set; }
        public string? MessageReponduAuteur { get; set; }
    }
}