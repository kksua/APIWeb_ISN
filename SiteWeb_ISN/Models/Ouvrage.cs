using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIWeb_ISN.Models
{
    public class Ouvrage
    {
        [Key]
        public int IdOuvrage { get; set; }
        [ForeignKey("IdChanteur")]
        public int ChanteurId1 { get; set; }
        public virtual Chanteur? Chanteur { get; set; }
        [ForeignKey("IdAlbum")]
        public int AlumId2 { get; set; }
        public virtual Album? Album { get; set; }
    }
}
