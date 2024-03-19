

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace APIWeb_ISN.Models;
public class Media
{
    private DateTime DateDeSortie1;


    [Key]
    public int IdMedia { get; set; }
        
    public string Title { get; set; } = string.Empty;


    public string Genre { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime DateDeSortie { get => DateDeSortie1; set => DateDeSortie1 = value; }

    public string Lien { get; set; } = string.Empty;



}
