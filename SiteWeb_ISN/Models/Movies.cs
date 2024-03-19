using System.ComponentModel.DataAnnotations;

namespace SiteWeb_ISN.Models;
public class Movies
{

    [Key]

    public int IdFilm { get; set; }

    public string NomFilm { get; set; }=string.Empty;

    public TimeSpan Duree { get; set; } 




}