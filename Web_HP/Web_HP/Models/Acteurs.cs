using System.ComponentModel.DataAnnotations;

namespace Web_HP.Models;
public class Acteur
{
    [Key]
    public int IdActeur { get; set; }

    public string? NomActeur { get; set; }

    public string NationaliteActeur { get; set; } = string.Empty;

    public string? ImageActeur { get; set; } = string.Empty;
}