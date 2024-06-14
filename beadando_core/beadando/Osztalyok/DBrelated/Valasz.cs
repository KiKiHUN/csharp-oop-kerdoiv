using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace beadando.Osztalyok.DBrelated;


public class Valasz
{
    [Key]
    public int ID { get; set; }

    [Required]
    public string szoveg { get; set; }

    [ForeignKey("Kerdes")]
    public Kerdes kerdesID { get; set; }
}
