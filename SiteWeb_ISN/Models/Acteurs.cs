using System.ComponentModel.DataAnnotations;

namespace SiteWeb_ISN.Models;
public class Acteur
{
    [Key]
    public int IdActeur { get; set; }

    public string? NomActeur { get; set; }

    public string NationaliteActeur { get; set; } = string.Empty;

    public string? ImageActeur { get; set; } = string.Empty;
}