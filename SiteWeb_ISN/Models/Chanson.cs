using System.ComponentModel.DataAnnotations;

namespace SiteWeb_ISN.Models
{
    public class Chanson
    {
        [Key]
        public int  IdChanson { get; set; }
        public string NomChanson { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Langue { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public string Lien { get; set; } = string.Empty;
    }
}
