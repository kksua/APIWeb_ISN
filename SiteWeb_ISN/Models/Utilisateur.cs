using System.ComponentModel.DataAnnotations;

namespace APIWeb_ISN.Models
{
    public class Utilisateur
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? NomUser { get; set; } 
        [Required]
        public string? Email { get; set; } 
        [Required]
        public string? MDP { get; set; } 
        public ICollection<Chanson>? ChansonsPreferee { get; set; }
    }
}
