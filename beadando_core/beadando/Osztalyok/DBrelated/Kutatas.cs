using System;
using System.ComponentModel.DataAnnotations;

namespace beadando.Osztalyok.DBrelated;
public class Kutatas
{
    [Key]
    public int ID { get; set; }

    [Required]
    public string nev { get; set; }
    [Required]
    public DateTime kezdet { get; set; }
    [Required]
    public DateTime veg { get; set; }
    [Required]
    public int elvartKitoltes { get; set; }
    [Required]
    public int kapottKitoltes { get; set; }
    [Required]
    public bool aktivalva { get; set; }

}