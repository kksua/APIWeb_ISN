using System.ComponentModel.DataAnnotations.Schema;

namespace SiteWeb_ISN.Models
{
    public class Ouvrage
    {
        [ForeignKey("IdChanteur")]
        public int ChanteurId1 { get; set; }
        public virtual Chanteur? Chanteur { get; set; }
        [ForeignKey("IdAlbum")]
        public int AlumId2 { get; set; }
        public virtual Album? Album { get; set; }
    }
}
