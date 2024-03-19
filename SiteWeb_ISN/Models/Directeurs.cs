
using System.ComponentModel.DataAnnotations;

namespace APIWeb_ISN.Models;
public class Directeurs
{


    
        [Key]
    public int IdDirecteurs { get; set; }

    public string NomSerie { get; set; }

    public string NationaliteDirecteur { get; set; } = string.Empty;

    public string ImageDirecteur { get; set; } = string.Empty;


}