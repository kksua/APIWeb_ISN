using System.ComponentModel.DataAnnotations;

namespace SiteWeb_ISN.Models
{
    public class Chanteur
    {
        [Key]
        public int IdChanteur { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string nationaliteChanteur { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public ICollection<Chanson>? Chansons { get; set; }
        public ICollection<Album>? Albums { get; set; }
    }
}
