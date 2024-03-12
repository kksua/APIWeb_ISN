using System.ComponentModel.DataAnnotations;

namespace SiteWeb_ISN.Models
{
    public class Album
    {
        [Key]
        public int IdAlbum { get; set; }
        public string NomAlbum { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public ICollection<Chanson>? Chansons { get; set; }
        public virtual ICollection<Ouvrage>? Ouvrages { get; set; }
    }
}
