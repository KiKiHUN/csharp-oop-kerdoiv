using beadando.Osztalyok.DBrelated;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;


namespace beadando.Osztalyok
{
    public class Funkciok
    {

        public string[] Stringsplitter(string bestring, char elvalaszto)
        {
            return bestring.Split(elvalaszto);
        }

        public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
        {
            MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }



    }


    public class ToltoFunkcio : Funkciok
    {
        private void remainOpen(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }
        loadingWindow loading=null;
        public void ShowLoading(bool open = true)
        {
            if (loading == null)
            {
                loading = new loadingWindow();
            }
            if (open)
            {
                loading.Show();
                loading.Closing += remainOpen;

            }
            else
            {
                loading.Closing -= remainOpen;
                loading.Close();
                loading = null;
            }
        }
        
    }
    public class XMLfunkciok : Funkciok
    {

        public void WriteXML(string path, string fajlnevKiterjesztes, string tipus, string email, string nem, int kor, string vegzettseg)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(path + "\\" + fajlnevKiterjesztes, settings);

            writer.WriteStartDocument();

            writer.WriteComment("Itt lehet jogosultságot és bejelentkezést megadni.");


            writer.WriteStartElement("Adatok");
            writer.WriteStartElement("BejelentkezesTipus");
            writer.WriteElementString("tipus", tipus);
            writer.WriteEndElement();

            writer.WriteStartElement("SzemelyiAdatok");
            writer.WriteElementString("email", email);
            writer.WriteElementString("nem", nem);
            writer.WriteElementString("kor", kor.ToString());
            writer.WriteElementString("vegzettseg", vegzettseg);
            writer.WriteEndElement();
            writer.WriteEndDocument();


            writer.Flush();
            writer.Close();
        }
        public void WriteTemlplateXML(string path)
        {
            WriteXML(path, "config.xml", "admin/nemadmin", "alma@alma.alma", "kartonpapir", 69, "ovoda");
        }
    }
    public class DBFunkciok : Funkciok
    {
        public hibakodok FindDB()
        {
            var adatbazis = new Adatbazis();
            try
            {
                if (!adatbazis.Database.CanConnect())
                {
                    return hibakodok.DB_nincs_kapcsolat;
                }
                else
                {
                    adatbazis.Database.OpenConnection();
                    adatbazis.Database.CloseConnection();
                    return hibakodok.DB_siker;
                }
            }
            catch
            {
                return hibakodok.DB_nincs_kapcsolat;
            }
        }
        public hibakodok FinOrCreateDB()
        {
            switch (FindDB())
            {
                case hibakodok.DB_nincs_kapcsolat:
                    try
                    {
                        var adatbazis = new Adatbazis();

                        adatbazis.Database.EnsureDeleted();
                        adatbazis.Database.Migrate();
                    }
                    catch
                    {
                        return hibakodok.DB_nincs_kapcsolat;
                    }
                    return hibakodok.DB_uj_letrehozva;


                default:
                    return hibakodok.DB_siker;
            }






            //adatbazis.Add(new Kutatasok { nev = "hali", kezdet = "20200810", veg = "20200810", elvartKitoltes = 2 });
            //adatbazis.SaveChanges();
            //MySql.Data.MySqlClient.MySqlConnection conn;
            //string myConnectionString;

            //myConnectionString = "server=192.168.0.5,3306;uid=myadmin;pwd=incidens123;database=kerdoivek";

            //try
            //{
            //    conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
            //    conn.Open();
            //}
            //catch (MySql.Data.MySqlClient.MySqlException ex)
            //{

            //}

        }

        #region kutatások
            public List<Kutatas> getAllKutatas()
            {
                List<Kutatas> kutatasok=null;
                if (FindDB() != hibakodok.DB_siker)
                {
                    return kutatasok;
                }
                var adatbazis = new Adatbazis();
                kutatasok = adatbazis.kutatasok.ToList();
                return kutatasok;
            }

            public List<Kutatas> getNotStartedKutatas()
            {
                List<Kutatas> kutatasok = null;
                if (FindDB() != hibakodok.DB_siker)
                {
                    return kutatasok;
                }
                var adatbazis = new Adatbazis();
                kutatasok=new List<Kutatas>();
                foreach (Kutatas kut in getAllKutatas())
                {
                    if (kut.kezdet>DateTime.Now)
                    {
                        kutatasok.Add(kut);
                    }
                }
            
           
           
                return kutatasok;
            }

            public List<Kutatas> getStartedKutatas()
            {
                List<Kutatas> kutatasok = null;
                if (FindDB() != hibakodok.DB_siker)
                {
                    return kutatasok;
                }
                var adatbazis = new Adatbazis();
                kutatasok = new List<Kutatas>();
                foreach (Kutatas kut in getAllKutatas())
                {
                    if (kut.kezdet <= DateTime.Now&&kut.veg>DateTime.Now)
                    {
                        kutatasok.Add(kut);
                    }
                }
                return kutatasok;
            }

            public List<Kutatas> getLejartKutatas()
            {
                List<Kutatas> kutatasok = null;
                if (FindDB() != hibakodok.DB_siker)
                {
                    return kutatasok;
                }
                var adatbazis = new Adatbazis();
                kutatasok = new List<Kutatas>();
                foreach (Kutatas kut in getAllKutatas())
                {
                    if (kut.veg <= DateTime.Now)
                    {
                        kutatasok.Add(kut);
                    }
                }
                return kutatasok;
            }

            public hibakodok editKutatas(int ID, string nev, int elvart, DateTime kezdet, DateTime veg, bool aktivalva)
            {
                if (FindDB() != hibakodok.DB_siker)
                {
                    return hibakodok.DB_nincs_kapcsolat;
                }
                Adatbazis adatbazis = new Adatbazis();
                var item = adatbazis.kutatasok.Where(x => x.ID == ID).First();
                if (item != null)
                {
                    item.nev = nev;
                    item.veg = veg;
                    item.kezdet = kezdet;
                    item.elvartKitoltes = elvart;
                    item.aktivalva = aktivalva;
                    adatbazis.SaveChanges();
                    return hibakodok.DB_siker;
                }
                return hibakodok.db_sikertelen;
            }
            public hibakodok editKutatasEnd(int ID, DateTime veg)
            {
                if (FindDB() !=hibakodok.DB_siker)
                {
                    return hibakodok.DB_nincs_kapcsolat;
                }
                Adatbazis adatbazis = new Adatbazis();
                var item = adatbazis.kutatasok.Where(x => x.ID == ID).First();
                if (item != null)
                {
                    item.veg = veg;
                    adatbazis.SaveChanges();
                    return hibakodok.DB_siker;
                }
                return 0;
            }

            public hibakodok addKutatas(string nev, int elvart, DateTime kezdet, DateTime veg, bool aktivalva)
            {
                if (FindDB() != hibakodok.DB_siker)
                {
                    return hibakodok.DB_nincs_kapcsolat;
                }
                Kutatas k = new Kutatas();
                k.nev = nev;
                k.elvartKitoltes = elvart;
                k.kezdet = kezdet;
                k.veg = veg;
                k.aktivalva = aktivalva;
                try
                {
                    Adatbazis adatbazis = new Adatbazis();
                    adatbazis.kutatasok.Add(k);
                    adatbazis.SaveChanges();
                    return hibakodok.DB_siker;
                }
                catch
                {
                    return hibakodok.db_sikertelen;

                }


            }
            public hibakodok RemoveKutatas(int ID)
            {
          
                if (FindDB()!=hibakodok.DB_siker)
                {
                    return hibakodok.DB_nincs_kapcsolat;
                }
                var adatbazis = new Adatbazis();
                try
                {
                    var a = adatbazis.kutatasok.Remove(adatbazis.kutatasok.Where(x => x.ID == ID).First());
                    if (a.State.ToString() == "Deleted")
                    {
                        adatbazis.SaveChanges();
                        return hibakodok.DB_siker;
                    }
                    else
                    {
                        return hibakodok.db_sikertelen;
                    }
                }
                catch (Exception)
                {

                    return hibakodok.DB_nincs_ID;
                }

            }

            public hibakodok checkIfKitoltottKutatasByEmailByID(string email,int kutatasID)
            {
                if (FindDB() != hibakodok.DB_siker)
                {
                    return hibakodok.DB_nincs_kapcsolat;
                }
                Adatbazis adatbazis=new Adatbazis();
            
                if (adatbazis.kitoltesek.Where(x=>x.kutatas.ID==kutatasID).Where(x=>x.email==email).Count()>0)
                {
                    return hibakodok.db_van;
                }else
                {
                    return hibakodok.db_nincs;
                }
            }
            public int getLastKutatasID() 
            {
                int szam = -1;
                if (FindDB() != hibakodok.DB_siker)
                {
                    return szam;
                }
                Adatbazis adatbazis = new Adatbazis();
                szam = adatbazis.kutatasok.OrderBy(x=>x.ID).Last().ID;
                return szam;
            }

        #endregion

        #region kérdések

            public int getLastKerdesID()
            {
                int szam = -1;
                if (FindDB() != hibakodok.DB_siker)
                {
                    return szam;
                }
                Adatbazis adatbazis = new Adatbazis();
                szam = adatbazis.kerdesek.OrderBy(x => x.ID).Last().ID;
                return szam;
            }
            public List<Kerdes> getAllKerdesByID(int id)
            {
                List<Kerdes> kerdesek = null;
                if (FindDB() != hibakodok.DB_siker)
                {
                    return kerdesek;
                }
                Adatbazis adatbazis = new Adatbazis();
                kerdesek = adatbazis.kerdesek.Where(x => x.kutatasID.ID == id).ToList();
                return kerdesek;
            }
            public int getValaszokSzama(int kerdesId)
            {
                int szam = -1;
                if (FindDB() != hibakodok.DB_siker)
                {
                    return szam;
                }
                Adatbazis adatbazis = new Adatbazis();
                szam = adatbazis.valaszok.Where(x => x.kerdesID.ID==kerdesId).Count();
                return szam;
            }

            public hibakodok RemoveKerdes(int id)
            {
                if (FindDB() !=hibakodok.DB_siker)
                {
                    return hibakodok.DB_nincs_kapcsolat;
                }
                var adatbazis = new Adatbazis();
                try
                { 
                    var a = adatbazis.kerdesek.Remove(adatbazis.kerdesek.Where(x => x.ID == id).First());
                    if (a.State.ToString() == "Deleted")
                    {
                        adatbazis.SaveChanges();
                        return hibakodok.DB_siker;
                    }
                    else
                    {
                        return hibakodok.db_sikertelen;
                    }
                }
                catch (Exception)
                {

                    return hibakodok.DB_nincs_ID;
                }
           
            }

            public hibakodok addKerdes(int kutatasId,string szoveg)
            {
                if (FindDB() != hibakodok.DB_siker)
                {
                    return hibakodok.DB_nincs_kapcsolat;
                }
                try
                {
                    Adatbazis adatbazis = new Adatbazis();
                    Kerdes kerdes = new Kerdes();
                    var kut=adatbazis.kutatasok.Where(x => x.ID==kutatasId).First();
                    kerdes.kutatasID = kut;
                    kerdes.szoveg = szoveg;
                    adatbazis.kerdesek.Add(kerdes);
                    adatbazis.SaveChanges();
                }
                catch 
                {
                    return hibakodok.db_sikertelen;
                }
            
                return hibakodok.DB_siker;
            }

            public hibakodok EditKerdes(int kerdesID, string szoveg)
            {
                if (FindDB() != hibakodok.DB_siker)
                {
                    return hibakodok.DB_nincs_kapcsolat;
                }
                try
                {
                    Adatbazis adatbazis = new Adatbazis();
                    var a = adatbazis.kerdesek.Where(x => x.ID == kerdesID).First();
                    a.szoveg = szoveg;
                    adatbazis.SaveChanges();
                }
                catch 
                {
                    return hibakodok.db_sikertelen;
                }
            
                return hibakodok.DB_siker;
            }
        #endregion

        #region válaszok

            public List<Valasz> getAllValaszByID(int id)
            {
                List<Valasz> valaszok = null;
                if (FindDB() != hibakodok.DB_siker)
                {
                    return valaszok;
                }
                Adatbazis adatbazis = new Adatbazis();
                valaszok = adatbazis.valaszok.Where(x => x.kerdesID.ID == id).ToList();
                return valaszok;
            }
            public hibakodok RemoveValasz(int id)
            {
                if (FindDB() != hibakodok.DB_siker)
                {
                    return hibakodok.DB_nincs_kapcsolat;
                }
                var adatbazis = new Adatbazis();
                try
                {
                    var a = adatbazis.valaszok.Remove(adatbazis.valaszok.Where(x => x.ID == id).First());
                    if (a.State.ToString() == "Deleted")
                    {
                        adatbazis.SaveChanges();
                        return hibakodok.DB_siker;
                    }
                    else
                    {
                        return hibakodok.db_sikertelen;
                    }
                }
                catch (Exception)
                {

                    return hibakodok.DB_nincs_ID;
                }

            }

            public hibakodok addValasz(int KerdesID, string szoveg)
            {
                if (FindDB() != hibakodok.DB_siker)
                {
                    return hibakodok.DB_nincs_kapcsolat;
                }
                try
                {
                    Adatbazis adatbazis = new Adatbazis();
                    Valasz valasz= new Valasz();
                    var kerd = adatbazis.kerdesek.Where(x => x.ID == KerdesID).First();
                    valasz.kerdesID = kerd;
                    valasz.szoveg = szoveg;
                    adatbazis.valaszok.Add(valasz);
                    adatbazis.SaveChanges();
                }
                catch
                {
                    return hibakodok.db_sikertelen;
                }

                return hibakodok.DB_siker;
            }

            public hibakodok EditValasz(int ValaszID, string szoveg)
            {
                if (FindDB() != hibakodok.DB_siker)
                {
                    return hibakodok.DB_nincs_kapcsolat;
                }
                try
                {
                    Adatbazis adatbazis = new Adatbazis();
                    var a = adatbazis.valaszok.Where(x => x.ID == ValaszID).First();
                    a.szoveg = szoveg;
                    adatbazis.SaveChanges();
                }
                catch
                {
                    return hibakodok.db_sikertelen;
                }

                return hibakodok.DB_siker;
            }

        #endregion

        #region kitoltesek
            public hibakodok AddKitoltes(string email,int kutatasID,string nem,string vegzettseg,int kor, List<Tuple<int, Tuple<int, int>>> kerdes_valasz)
            {
            //kerdesID, (valaszID, valaszComboIndex)
            if (FindDB() != hibakodok.DB_siker)
                {
                    return hibakodok.DB_nincs_kapcsolat;
                }
           

                Adatbazis adatbazis = new Adatbazis();


                Kutatas kut = adatbazis.kutatasok.Where(x => x.ID == kutatasID).FirstOrDefault();
                for (int i = 0; i < kerdes_valasz.Count; i++)
                {
                    Valasz val = adatbazis.valaszok.Where(x => x.ID == kerdes_valasz[i].Item2.Item1).FirstOrDefault();
                    Kerdes ker = adatbazis.kerdesek.Where(x => x.ID == kerdes_valasz[i].Item1).FirstOrDefault();
                   

                    Kitoltesek kitoltes = new Kitoltesek
                    {
                        KitoltesIdo = DateTime.Now,
                        email = email,
                        nem = nem,
                        vegzettseg = vegzettseg,
                        kor = kor,
                        kerdes = ker,
                        valaszID = val,
                        kutatas = kut

                    };
                   
                    adatbazis.kitoltesek.Add(kitoltes);
                }
                kut.kapottKitoltes = kut.kapottKitoltes + 1;
                try
                {
                   
                    adatbazis.SaveChanges();
                }
                catch
                {
                    return hibakodok.db_sikertelen;
                }
            
                return hibakodok.DB_siker;
            }

            public List<Kitoltesek> getAlKitoltesByKutatasID(int id)
            {
                List<Kitoltesek> kerdesek = null;
                if (FindDB() != hibakodok.DB_siker)
                {
                    return kerdesek;
                }
                Adatbazis adatbazis = new Adatbazis();
                kerdesek = adatbazis.kitoltesek.Where(x => x.kutatas.ID==id).ToList();
                return kerdesek;
            }

            public List<Tuple<Valasz, int>> getKitoltesValaszokCountByKerdesID(int kerdesid) //valaszid,darab
            {
                List<Tuple<Valasz, int>> ja=null;
                if (FindDB() != hibakodok.DB_siker)
                {
                    return ja;
                }
                ja = new List<Tuple<Valasz, int>>();

                Adatbazis adatbazis = new Adatbazis();
                var a=adatbazis.kitoltesek.Where(x=>x.kerdes.ID== kerdesid).GroupBy(x=>x.valaszID).Select(g => new { valaszID = g.Key, darab = g.Count() }).ToDictionary(k => k.valaszID, i => i.darab).ToArray();
                foreach (var item in a)
                {
                    ja.Add( Tuple.Create(item.Key, item.Value));
                };
                return ja;
            }

            public List<Tuple<string,int>> getKitoltesNemByKutatasID(int kutatasID)
            {
                List<Tuple<string, int>> ja = null;
                if (FindDB() != hibakodok.DB_siker)
                {
                    return ja;
                }
                ja = new List<Tuple<string, int>>();

                Adatbazis adatbazis = new Adatbazis();
                var a = adatbazis.kitoltesek.Where(x => x.kutatas.ID == kutatasID).GroupBy(x => x.nem).Select(g => new { nem = g.Key, darab = g.Count() }).ToDictionary(k => k.nem, i => i.darab).ToArray();
                foreach (var item in a)
                {
                    ja.Add(Tuple.Create(item.Key, item.Value));
                };
                return ja;
            }

            public List<Tuple<int, int>> getKitoltesKorByKutatasID(int kutatasID)
            {
                List<Tuple<int, int>> ja = null;
                if (FindDB() != hibakodok.DB_siker)
                {
                    return ja;
                }
                ja = new List<Tuple<int, int>>();

                Adatbazis adatbazis = new Adatbazis();
                var a = adatbazis.kitoltesek.Where(x => x.kutatas.ID == kutatasID).GroupBy(x => x.kor).Select(g => new { kor = g.Key, darab = g.Count() }).ToDictionary(k => k.kor, i => i.darab).ToArray();
                foreach (var item in a)
                {
                    ja.Add(Tuple.Create(item.Key, item.Value));
                };
                return ja;
            }

            public List<Tuple<string, int>> getKitoltesVegzettsegByKutatasID(int kutatasID)
            {
                List<Tuple<string, int>> ja = null;
                if (FindDB() != hibakodok.DB_siker)
                {
                    return ja;
                }
                ja = new List<Tuple<string, int>>();

                Adatbazis adatbazis = new Adatbazis();
                var a = adatbazis.kitoltesek.Where(x => x.kutatas.ID == kutatasID).GroupBy(x => x.vegzettseg).Select(g => new { vegzettseg = g.Key, darab = g.Count() }).ToDictionary(k => k.vegzettseg, i => i.darab).ToArray();
                foreach (var item in a)
                {
                    ja.Add(Tuple.Create(item.Key, item.Value));
                };
                return ja;
            }
        #endregion
    }
}
