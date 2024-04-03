using System.ComponentModel.DataAnnotations;

namespace APIWeb_ISN.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        [Required]
        public string NomUser { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string MDP { get; set; } = string.Empty;
        public ICollection<Chanson>? ChansonsPreferee { get; set; }
    }
}
