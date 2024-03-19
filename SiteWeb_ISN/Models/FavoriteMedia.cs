using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIWeb_ISN.Models;
public class FavoriteMedia
{


    [Key]
    public int Id { get; set; }

    [Required]
    public int IdFilm { get; set; }
    [Required]
    public int IdUtilisateur { get; set; } 

    [ForeignKey("IdFilm")]
    public Movies Movies { get; set; }

    [ForeignKey("IdUtilisateur")]
    public Utilisateur Utilisateur { get; set; }

    public bool FavoriteMedias { get; set; }


}