using System.ComponentModel.DataAnnotations;

namespace APIWeb_ISN.Models
{
    public class Utilisateur
    {
        [Key]
        public int IdUtilisateur { get; set; }
        public string NomUser { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MDP { get; set; } = string.Empty;
        public ICollection<Chanson>? ChansonsPreferee { get; set; }
    }
}
