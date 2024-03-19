using System.ComponentModel.DataAnnotations;

namespace SiteWeb_ISN.Models;
public class Series
{

    [Key]
   
    public int IdSeries { get; set; }

    public string NomSerie { get; set; } = string.Empty;


    public int NmbreSeasons { get; set; } 

    public int NmbreEpisode { get; set; } 
}
