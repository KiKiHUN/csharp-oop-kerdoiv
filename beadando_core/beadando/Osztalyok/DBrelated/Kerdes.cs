using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace beadando.Osztalyok.DBrelated;


public class Kerdes
{
    [Key]
    public int ID { get; set; }

    [Required]
    public string szoveg { get; set; }

    [ForeignKey("Kutatas")]
    public Kutatas kutatasID { get; set; }
}
