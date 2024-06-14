using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beadando.Osztalyok
{
    public enum hibakodok
    {
        semmi = 0,
        config_nincs = 69,
        config_hibashianyos = 70,
        config_nincskitoltva=71,
        DB_uj_letrehozva = 72,
        DB_nincs_kapcsolat=73,
        DB_siker=74,
        DB_nincs_adatbazis=75,
        DB_nincs_ID=76,
        db_sikertelen=77,
        db_van=78,
        db_nincs=79
    }
   
}
