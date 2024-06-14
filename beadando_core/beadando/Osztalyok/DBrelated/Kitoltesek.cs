using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Windows.Forms.AxHost;

namespace beadando.Osztalyok.DBrelated;


public class Kitoltesek
{
    [Required]
    public string email { get; set; }


    [ForeignKey("Kerdes")]
    public int KerdesID { get; set; }
    public Kerdes kerdes { get; set; }


    [ForeignKey("Kutatas")]
    public Kutatas kutatas { get; set; }

    [Required]
    public string nem { get; set; }

    [Required]
    public string vegzettseg { get; set; }

    [Required]
    public int kor { get; set; }

    [Required]
    public DateTime KitoltesIdo { get; set; }

  

    [ForeignKey("Valasz")]
    public Valasz valaszID { get; set; }
}

